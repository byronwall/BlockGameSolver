using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Board
    {
        private static Board instance;

        private readonly Point[] lookDirections = new[] {new Point(0, 1, Direction.Right), new Point(0, -1, Direction.Left), new Point(1, 0, Direction.Bottom), new Point(-1, 0, Direction.Top)};
        private Piece[,] backupPieces = new Piece[GameSettings.Rows,GameSettings.Columns];
        private Piece[,] pieces = new Piece[GameSettings.Rows,GameSettings.Columns];

        public int Score { get; private set; }

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public int PieceCount
        {
            get
            {
                int count = 0;
                foreach (Piece piece in pieces)
                {
                    if (piece != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = CreateRandomBoard();
                }
                return instance;
            }
        }

        public static Board CreateRandomBoard(int? rowMissing, int? colMissing)
        {
            Board output = new Board();
            MersenneTwister rng = RandomSource.Instance;
            for (int i = 0; i < GameSettings.Rows; i++)
            {
                if (i == rowMissing)
                {
                    continue;
                }
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    if (j == colMissing)
                    {
                        continue;
                    }
                    output[i, j] = new Piece(i, j, rng.Next(1, 6));
                }
            }
            return output;
        }

        /// <summary>
        /// Determines the size of the group located at the given coordinate.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="dirFrom"></param>
        /// <returns></returns>
        public int DetermineGroup(int row, int col, Direction dirFrom)
        {
            int count = 1;
            if (pieces[row, col] == null)
            {
                return 0;
            }
            pieces[row, col].Checked = true;

            for (int i = 0; i < lookDirections.Length; i++)
            {
                Point nextPoint = lookDirections[i];

                //This code checks that the path is not backtracked, the rows and columns are within bounds, the new piece exists, the new piece has not been checked, and that the colors match.

                if (dirFrom != Point.GetOppositeDirection(nextPoint.Dir) && (0 <= row + nextPoint.RowInc && row + nextPoint.RowInc < GameSettings.Rows) && 0 <= col + nextPoint.ColInc && col + nextPoint.ColInc < GameSettings.Columns && pieces[row + nextPoint.RowInc, col + nextPoint.ColInc] != null && !pieces[row + nextPoint.RowInc, col + nextPoint.ColInc].Checked && pieces[row + nextPoint.RowInc, col + nextPoint.ColInc].Color == pieces[row, col].Color)
                {
                    count += DetermineGroup(row + nextPoint.RowInc, col + nextPoint.ColInc, nextPoint.Dir);
                }
            }
            return count;
        }

        /// <summary>
        /// Removes the closest group to the given coordinate.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>The number of pieces that were removed.</returns>
        public int RemoveGroup(int row, int col)
        {
            int range = 0;
            while (true)
            {
                if (range >= GameSettings.Rows || range >= GameSettings.Columns)
                {
                    //No more groups to remove.
                    Score += (1 - PieceCount / (GameSettings.Rows * GameSettings.Columns)) * 100;
                    Debug.Assert(Score != 0, "The score is 0 after a removal");

                    return 0;
                }
                for (int i = -range; i <= range; i++)
                {
                    if (row + i >= GameSettings.Rows || row + i < 0)
                    {
                        continue;
                    }

                    for (int j = -range; j < range; j++)
                    {
                        if (col + j >= GameSettings.Columns || col + j < 0)
                        {
                            continue;
                        }
                        foreach (Piece piece in pieces)
                        {
                            if (piece != null)
                            {
                                piece.Checked = false;
                            }
                        }
                        int count = DetermineGroup(row + i, col + j, Direction.None);
                        if (count >= GameSettings.GroupSize)
                        {
                            foreach (Piece piece in pieces)
                            {
                                if (piece != null && piece.Checked)
                                {
                                    pieces[piece.Row, piece.Col] = null;
                                }
                            }
                            FillEmptySpaces();
                            Score += count * count;
                            Debug.Assert(Score != 0, "The score is 0 after a removal");

                            return count;
                        }
                    }
                }

                range++;
            }
        }

        public void FillEmptySpaces()
        {
            int colGap = 0;
            for (int i = GameSettings.Columns - 1; i >= 0; i--)
            {
                int rowGap = 0;
                bool colEmpty = true;
                for (int j = GameSettings.Rows - 1; j >= 0; j--)
                {
                    if (pieces[j, i] == null)
                    {
                        rowGap++;
                        continue;
                    }
                    colEmpty = false;

                    if (rowGap > 0 || colGap > 0)
                    {
                        pieces[j + rowGap, i + colGap] = pieces[j, i];
                        pieces[j + rowGap, i + colGap].Row = j + rowGap;
                        pieces[j + rowGap, i + colGap].Col = i + colGap;
                        pieces[j, i] = null;
                    }
                }
                if (colEmpty)
                {
                    colGap++;
                }
            }
        }

        public int RemoveGroups(List<int> groups)
        {
            foreach (int i in groups)
            {
                int removed = RemoveGroup(i / GameSettings.Columns, i % GameSettings.Columns);
                if (removed == 0)
                {
                    break;
                }
            }
            return Score;
        }

        private static Board CreateRandomBoard()
        {
            return CreateRandomBoard(null, null);
        }

        public void SaveBoard()
        {
            Array.Copy(pieces, backupPieces, pieces.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("*\t");

            for (int i = 0; i < GameSettings.Columns; i++)
            {
                sb.Append(i);
                sb.Append(" ");
            }

            sb.Append("\r\n\r\n");

            for (int i = 0; i < GameSettings.Rows; i++)
            {
                sb.Append(i);
                sb.Append("\t");

                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    if (pieces[i, j] != null)
                    {
                        sb.Append(pieces[i, j].Color);
                    }
                    else
                    {
                        sb.Append("*");
                    }
                    sb.Append(" ");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        public void LoadOldBoard()
        {
            Score = 0;
            Array.Copy(backupPieces, pieces, pieces.Length);
        }
    }
}