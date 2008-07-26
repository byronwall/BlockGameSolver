using System;
using System.Collections.Generic;
using System.Drawing;
using BlockGameSolver.Simulation.Core;
using Point = System.Drawing.Point;
using System.Linq;

namespace BlockGameSolver.ImageAnalyzer.Core
{
    public class Analyzer : IBoardSource
    {
        private Bitmap screenshot;
        private ImageSettings settings;

        public Analyzer(ImageSettings settings)
        {
            this.settings = settings;
        }

        public Analyzer(Bitmap screenshot, ImageSettings settings)
        {
            this.screenshot = screenshot;
            this.settings = settings;

            settings.AnchorCorner = DetermineAnchorPoint();
            Size boardSize = DetermineBoardSize();
            settings.Cols = boardSize.Width;
            settings.Rows = boardSize.Height;

        }

        #region IBoardSource Members

        public List<Piece> GetPiecesForBoard()
        {
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < settings.Rows; i++)
            {
                for (int j = 0; j < settings.Cols; j++)
                {
                    int color;
                    bool isBomb;
                    bool isDouble;
                    Piece current = new Piece(i, j, color, isBomb, isDouble);
                }
            }

            return pieces;
        }

        #endregion

        private Point DetermineAnchorPoint()
        {
            if (settings == null)
            {
                throw new ArgumentException("The settings for the analyzer have not been established");
            }

            for (int i = 0; i < screenshot.Width; i++)
            {
                for (int j = 0; j < screenshot.Height; j++)
                {
                    if (screenshot.GetPixel(i, j).ToArgb() != settings.AnchorData[0].Color)
                    {
                        continue;
                    }
                    Point anchor = new Point(i - settings.AnchorData[0].XOffset, j - settings.AnchorData[0].YOffset);
                    bool pointFound = true;
                    foreach (AnchorPoint anchorPoint in settings.AnchorData)
                    {
                        if (screenshot.GetPixel(anchorPoint.XOffset + anchor.X, anchorPoint.YOffset + anchor.Y).ToArgb() != anchorPoint.Color)
                        {
                            pointFound = false;
                            break;
                        }
                    }
                    if (pointFound)
                    {
                        return anchor;
                    }
                }
            }
            throw new ArgumentException("The image does not contain the specified anchor.");
        }
        private Size DetermineBoardSize()
        {
            Point piece = settings.PieceCorner;
            int rows = 0, cols = 0, curCols = 0;

            for (int i = piece.X; i < screenshot.Width; i += settings.PieceWidth)
            {

                int curRows = 0;
                for (int j = piece.Y; j < screenshot.Height; j += settings.PieceHeight)
                {
                    if (settings.ColorData.Any(c => c.ImageColor != screenshot.GetPixel(i + settings.ColorOffset.X, j + settings.ColorOffset.Y).ToArgb()))
                    {
                        if (curRows < rows) rows = curRows;
                        if (curCols < cols) cols = curCols;
                        break;
                    }
                    curRows++;
                }
                if (curRows == 0) break;
                curCols++;
            }

            return new Size(cols, rows);
        }
    }

    public interface IBoardSource
    {
        List<Piece> GetPiecesForBoard();
    }
}