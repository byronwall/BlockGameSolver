using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BlockGameSolver.ImageAnalyzer.Utility;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;

namespace BlockGameSolver.ImageAnalyzer.Core
{
    public class Analyzer : IBoardSource
    {
        private readonly List<Size> acceptableSizes = new List<Size>() { new Size(10, 10), new Size(10, 15), new Size(10, 20) };
        private readonly ImageSettings settings;

        private Bitmap screenshot;

        public Analyzer(ImageSettings settings)
        {
            this.settings = settings;
        }

        public Analyzer(Bitmap screenshot, ImageSettings settings)
            : this(settings)
        {
            SetScreenshot(screenshot);
        }

        public bool IsValidBoard { get; private set; }

        public ImageSettings Settings
        {
            get { return settings; }
        }

        #region IBoardSource Members

        public List<Piece> GetPiecesForBoard()
        {
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Columns; j++)
                {
                    string colorName = GetColorNameFromImage(i, j, Settings.ColorOffset);

                    bool isBomb = GetColorNameFromImage(i, j, Settings.ColorOffset) == "bomb";
                    bool isDouble = GetColorNameFromImage(i, j, Settings.DoubleOffset) == "double";

                    int color = (isBomb) ? -1 : BoardSettings.BoardColors[colorName];
                    Piece current = new Piece(i, j, color, isBomb, isDouble);

                    pieces.Add(current);
                }
            }

            return pieces;
        }

        public int Rows
        {
            get { return Settings.Rows; }
        }

        public int Columns
        {
            get { return Settings.Columns; }
        }

        #endregion

        public void SetScreenshot(string path)
        {
            SetScreenshot((Bitmap)Image.FromFile(path));
        }

        public void SetScreenshot()
        {
            SetScreenshot(BitmapUtility.BitmapFromScreenshot());
        }

        public void SetScreenshot(Bitmap bitmap)
        {
            screenshot = bitmap;

            Settings.AnchorCorner = DetermineAnchorPoint();
            Size boardSize = DetermineBoardSize();
            Settings.Columns = boardSize.Width;
            Settings.Rows = boardSize.Height;
        }

        public Rectangle GetPieceRectanlge(int row, int col)
        {
            return new Rectangle(GetPixelForPieceLocation(row, col), new Size(settings.PieceWidth, settings.PieceHeight));
        }

        public Point GetPixelForPieceLocation(int row, int col)
        {
            return GetPixelForPieceLocation(row, col, new Point(0, 0));
        }

        public Point GetPixelForPieceLocation(int row, int col, Point offset)
        {
            int x = Settings.PieceCorner.X + offset.X + Settings.PieceWidth * col;
            int y = Settings.PieceCorner.Y + offset.Y + Settings.PieceHeight * row;
            return new Point(x, y);
        }

        private string GetColorNameFromImage(int row, int col, Point offset)
        {
            int x = Settings.PieceCorner.X + offset.X + Settings.PieceWidth * col;
            int y = Settings.PieceCorner.Y + offset.Y + Settings.PieceHeight * row;

            int key = screenshot.GetPixel(x, y).ToArgb();
            string value;
            if (Settings.ColorData.TryGetValue(key, out value)) return value;
            return null;
        }

        private Point DetermineAnchorPoint()
        {
            if (Settings == null) throw new ArgumentException("The settings for the analyzer have not been established");

            for (int i = 0; i < screenshot.Width; i++)
            {
                for (int j = 0; j < screenshot.Height; j++)
                {
                    if (screenshot.GetPixel(i, j).ToArgb() != Settings.AnchorData[0].Color) continue;
                    Point anchor = new Point(i - Settings.AnchorData[0].XOffset, j - Settings.AnchorData[0].YOffset);
                    bool pointFound = true;
                    foreach (AnchorPoint anchorPoint in Settings.AnchorData)
                    {
                        if (screenshot.GetPixel(anchorPoint.XOffset + anchor.X, anchorPoint.YOffset + anchor.Y).ToArgb() != anchorPoint.Color)
                        {
                            pointFound = false;
                            break;
                        }
                    }
                    if (pointFound)
                    {
                        Settings.AnchorCorner = anchor;
                        IsValidBoard = true;
                        return anchor;
                    }
                }
            }
            IsValidBoard = false;
            Console.WriteLine("Anchor not found.");
            return new Point();
        }

        private Size DetermineBoardSize()
        {
            if (!IsValidBoard) return Size.Empty;
            Point piece = Settings.PieceCorner;
            int rows = Int32.MaxValue,
                cols = Int32.MaxValue,
                curCols = 0;

            for (int i = piece.X; i < screenshot.Width; i += Settings.PieceWidth)
            {
                int curRows = 0;
                for (int j = piece.Y; j < screenshot.Height; j += Settings.PieceHeight)
                {
                    int color = screenshot.GetPixel(i + Settings.ColorOffset.X, j + Settings.ColorOffset.Y).ToArgb();
                    if (!Settings.ColorData.Any(c => c.Key == color && c.Value != "double"))
                    {
                        if (curRows == 0) break;
                        if (curRows < rows) rows = curRows;

                        break;
                    }
                    curRows++;
                }
                if (curRows == 0)
                {
                    if (curCols < cols) cols = curCols;
                    break;
                }
                curCols++;
            }

            Size size = new Size(cols, rows);
            IsValidBoard = acceptableSizes.Contains(size);
            return size;
        }
    }
}