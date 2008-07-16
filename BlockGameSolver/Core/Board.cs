using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Board
    {
        private static Board instance;

        private readonly Point[] lookDirections = new[] {new Point(0, 1, Direction.Right), new Point(0, -1, Direction.Left), new Point(1, 0, Direction.Bottom), new Point(-1, 0, Direction.Top)};
        private readonly Piece[,] pieces = new Piece[GameSettings.Rows,GameSettings.Columns];
        private Piece[,] backupPieces = new Piece[GameSettings.Rows,GameSettings.Columns];
        private bool hasMoves = true;

        public int Score { get; private set; }

        public Piece this[int row, int col]
        {
            get { return Pieces[row, col]; }
            set { Pieces[row, col] = value; }
        }

        public bool HasMoves
        {
            get { return hasMoves; }
            private set { hasMoves = value; }
        }

        public List<Piece> PieceList
        {
            get
            {
                Piece[] temp = new Piece[pieces.Length];

                int count = 0;
                foreach (Piece piece in temp)
                {
                    temp[count++] = piece;
                }
                return temp.ToList();
            }
        }

        public int PieceCount
        {
            get
            {
                int count = 0;
                foreach (Piece piece in Pieces)
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

        public Piece[,] Pieces
        {
            get { return pieces; }
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
            output.SaveBoard();
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
            if (Pieces[row, col] == null)
            {
                return 0;
            }
            Pieces[row, col].Checked = true;

            for (int i = 0; i < lookDirections.Length; i++)
            {
                Point nextPoint = lookDirections[i];

                //This code checks that the path is not backtracked, the rows and columns are within bounds, the new piece exists, the new piece has not been checked, and that the colors match.

                if (dirFrom != Point.GetOppositeDirection(nextPoint.Dir) && (0 <= row + nextPoint.RowInc && row + nextPoint.RowInc < GameSettings.Rows) && 0 <= col + nextPoint.ColInc && col + nextPoint.ColInc < GameSettings.Columns && Pieces[row + nextPoint.RowInc, col + nextPoint.ColInc] != null && !Pieces[row + nextPoint.RowInc, col + nextPoint.ColInc].Checked && Pieces[row + nextPoint.RowInc, col + nextPoint.ColInc].Color == Pieces[row, col].Color)
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
                    Score += (int) ((1 - (double) PieceCount / (GameSettings.Rows * GameSettings.Columns)) * 100);
                    HasMoves = false;
                    Debug.Assert(Score != 0, "The score is 0 after a removal");

                    return 0;
                }
                foreach (Piece piece in pieces)
                {
                    if (piece!=null)
                    {
                        piece.StartedOn = false;   
                    }
                }
                for (int i = -range; i <= range; i++)
                {
                    if (row + i >= GameSettings.Rows || row + i < 0)
                    {
                        continue;
                    }

                    for (int j = -range; j <= range; j++)
                    {
                        if (col + j >= GameSettings.Columns || col + j < 0)
                        {
                            continue;
                        }
                        if (pieces[row + i, col + j] == null)
                        {
                            continue;
                        }
                        if (pieces[row + i, col + j].StartedOn)
                        {
                            continue;
                        }
                        foreach (Piece piece in Pieces)
                        {
                            if (piece != null)
                            {
                                piece.Checked = false;
                            }
                        }
                        int count = DetermineGroup(row + i, col + j, Direction.None);
                        if (count >= GameSettings.GroupSize)
                        {
                            foreach (Piece piece in Pieces)
                            {
                                if (piece != null && piece.Checked)
                                {
                                    Pieces[piece.Row, piece.Col] = null;
                                }
                            }
                            FillEmptySpaces();
                            Score += count * count;
                            Debug.Assert(Score != 0, "The score is 0 after a removal");

                            return count;
                        }
                        pieces[row + i, col + j].StartedOn = true;
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
                    if (Pieces[j, i] == null)
                    {
                        rowGap++;
                        continue;
                    }
                    colEmpty = false;

                    if (rowGap > 0 || colGap > 0)
                    {
                        Pieces[j + rowGap, i + colGap] = Pieces[j, i];
                        Pieces[j + rowGap, i + colGap].Row = j + rowGap;
                        Pieces[j + rowGap, i + colGap].Col = i + colGap;
                        Pieces[j, i] = null;
                    }
                }
                if (colEmpty)
                {
                    colGap++;
                }
            }
        }

        public int RemoveGroups(int[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                int removed = RemoveGroup(groups[i] / GameSettings.Columns, groups[i] % GameSettings.Columns);

                if (removed == 0)
                {
                    break;
                }
            }
            return Score;
        }

        public static Board CreateRandomBoard()
        {
            return CreateRandomBoard(null, null);
        }

        public void SaveBoard()
        {
            Array.Copy(Pieces, backupPieces, Pieces.Length);
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
                    if (Pieces[i, j] != null)
                    {
                        sb.Append(Pieces[i, j].Color);
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
            hasMoves = true;

            Array.Copy(backupPieces, Pieces, Pieces.Length);

            for (int i = 0; i < GameSettings.Rows; i++)
            {
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    Pieces[i, j].Row = i;
                    Pieces[i, j].Col = j;
                }
            }
        }
    }
}