using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Visual;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Strategy;
using BlockGameSolver.Utility.Hooks;
using Microsoft.DirectX.DirectDraw;
using Timer=System.Timers.Timer;

namespace BlockGameSolver.GamePlayer.Core
{
    public class GameManager : IDisposable
    {
        private const int maximumLevels = 3;
        private static readonly Keys startStopKey = Keys.F3;
        private static int currentMove;
        private readonly Analyzer analyzer;
        private readonly AutoResetEvent nextMoveTurnstile = new AutoResetEvent(false);
        private readonly object stateLocker = new object();
        private readonly Timer timer = new Timer();
        private UserActivityHook activityHook;
        private Genome bestGenome;
        private Board currentBoard;
        private int currentLevel = 1;
        private RowColumnPoint currentRowColumnPoint;
        private GameFlowState flowState = GameFlowState.Invalid;
        private bool isActing;
        private OverlayManager overlayManager;
        private PopulationMultiRun population;
        private AutoResetEvent readyToReturn = new AutoResetEvent(false);
        private bool shouldContinue = true;
        private bool shouldReturn;

        public GameManager()
        {
            analyzer = new Analyzer(ImageSettings.LoadDataFromResource());

            timer.Elapsed += timer_Tick;
            timer.Interval = 1000;
        }

        private GameFlowState FlowState
        {
            get { return flowState; }
            set
            {
                lock (stateLocker)
                {
                    flowState = value;
                }
            }
        }

        public AutoResetEvent ReadyToReturn
        {
            get { return readyToReturn; }
            set { readyToReturn = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (overlayManager != null) overlayManager.Dispose();
            if (activityHook != null) activityHook.Stop(true, true, false);
            activityHook = null;
        }

        #endregion

        public void Start()
        {
            shouldContinue = true;
            try
            {
                activityHook = new UserActivityHook();
                activityHook.KeyDown += activityHook_KeyDown;
                activityHook.KeyUp += activityHook_KeyUp;
                activityHook.OnMouseActivity += activityHook_OnMouseActivity;

                FlowState = GameFlowState.ReadyToFindBoard;

                ThreadPool.QueueUserWorkItem(ActOnGameState);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ActOnGameState(object state)
        {
            while (shouldContinue)
            {
                if (!isActing)
                {
                    isActing = true;

                    if (FlowState == GameFlowState.Invalid) throw new ArgumentException("The game state is invalid for some reason.  Must exit.");
                    if (FlowState == GameFlowState.ReadyToFindBoard) BeginReadingScreenForBoard();
                    else if (FlowState == GameFlowState.ReadyToInitializeAnalysis) CreatePopulationFromBoard();
                    else if (FlowState == GameFlowState.ReadyToAnalyze) AnalyzeCurrentBoard();
                    else if (FlowState == GameFlowState.ReadyToPlay) BeginShowingMoveForms();
                    else if (FlowState == GameFlowState.ReadyToQuitOrStartAgain) DetermineQuitOrStartOver();
                    else shouldContinue = false;
                    isActing = false;
                }
            }

            if (shouldReturn) readyToReturn.Set();
        }

        private void BeginReadingScreenForBoard()
        {
            Console.WriteLine("checking the screen for a board.");
            analyzer.SetScreenshot();

            if (analyzer.IsValidBoard)
            {
                currentBoard = Board.FromIBoardSource(analyzer);
                MessageBox.Show("valid board was created.");
                FlowState = GameFlowState.ReadyToInitializeAnalysis;
            }
            else
            {
                Console.WriteLine("board not found.");
                shouldContinue = false;
                timer.Start();
            }
        }

        private void AnalyzeCurrentBoard()
        {
            bestGenome = population.GetBestGenome();
            MessageBox.Show("best plays were determined.");
            FlowState = GameFlowState.ReadyToPlay;
        }

        private void CreatePopulationFromBoard()
        {
            population = new PopulationMultiRun(currentBoard);
            MessageBox.Show("board is ready to be analyzed.");
            FlowState = GameFlowState.ReadyToAnalyze;
        }

        private void BeginShowingMoveForms()
        {
            currentMove = 0;
            //activityHook.Start(true, false);
            MessageBox.Show("about to start showing forms.");

            while (currentMove < bestGenome.MoveCount && shouldContinue)
            {
                ShowOverlay();
                Console.WriteLine("changing to WaitingForClick");
                FlowState = GameFlowState.WaitingForClick;
                nextMoveTurnstile.WaitOne();
                FlowState = GameFlowState.Playing;
                HideOverlay();
                currentMove++;
            }
            //activityHook.Stop(true, false, true);
            FlowState = GameFlowState.ReadyToQuitOrStartAgain;
        }

        private static void DrawOverlayCallback(Device device, Surface overlaySurface)
        {
            IntPtr dc = overlaySurface.GetDc();
            try
            {
                Graphics graphics = Graphics.FromHdc(dc);
                graphics.FillRectangle(Brushes.Tomato, 0, 0, 30, 30);
                graphics.DrawString(currentMove.ToString(), new Font("Arial", 18.0f), Brushes.White, 0, 0);
            }
            finally
            {
                overlaySurface.ReleaseDc(dc);
            }
        }

        private void HideOverlay()
        {
            Console.WriteLine("hiding overlay.");
            if (overlayManager != null)
            {
                overlayManager.Dispose();
                overlayManager = null;
            }
        }

        private void ShowOverlay()
        {
            Console.WriteLine("showing overlay.");
            overlayManager = new OverlayManager(DrawOverlayCallback);
            currentRowColumnPoint = GameSettings.GetLocationFromNumber(bestGenome.Moves[currentMove].Value);
            Point location = analyzer.GetPixelForPieceLocation(currentRowColumnPoint.Row, currentRowColumnPoint.Column);
            overlayManager.OverlayPosition = location;
            overlayManager.Initialize(analyzer.Settings.PieceWidth, analyzer.Settings.PieceHeight, BitsPerPixel.Bpp32);
            overlayManager.Update();
        }

        private void DetermineQuitOrStartOver()
        {
            if (++currentLevel <= maximumLevels) FlowState = GameFlowState.ReadyToFindBoard;
            else
            {
                FlowState = GameFlowState.Finished;
                shouldReturn = true;
            }
        }

        private void activityHook_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == startStopKey)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void activityHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == startStopKey)
            {
                //TODO:Add start/stop logic
                shouldContinue = false;
                shouldReturn = true;
                FlowState = GameFlowState.ForciblyQuit;
                MessageBox.Show("Stop key pressed.");
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void activityHook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 0 && FlowState == GameFlowState.WaitingForClick)
            {
                Console.WriteLine("checking if the click was in teh right area");
                Rectangle rectanlge = analyzer.GetPieceRectanlge(currentRowColumnPoint.Row, currentRowColumnPoint.Column);
                if (rectanlge.Contains(e.X, e.Y)) nextMoveTurnstile.Set();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            shouldContinue = true;
            ThreadPool.QueueUserWorkItem(ActOnGameState);
        }

        public void Start(object state)
        {
            Start();
        }
    }
}