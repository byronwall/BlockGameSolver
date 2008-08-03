using System;
using System.Text;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class Board
    {
        private readonly Piece[,] backupPieces = new Piece[GameSettings.Rows,GameSettings.Columns];

        private readonly Piece[] currentPieces = new Piece[GameSettings.PieceCount];

        private readonly Point[] lookDirections = new[] {new Point(0, 1, Direction.Right), new Point(0, -1, Direction.Left), new Point(1, 0, Direction.Bottom), new Point(-1, 0, Direction.Top)};

        private readonly Piece[,] pieces = new Piece[GameSettings.Rows,GameSettings.Columns];
        private int currentPieceCount;

        private bool hasMoves = true;

        public int Score { get; private set; }

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public bool HasMoves
        {
            get { return hasMoves; }
            private set { hasMoves = value; }
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

        public Piece[,] Pieces
        {
            get { return pieces; }
        }

        public static Board FromIBoardSource(IBoardSource source)
        {
            //update game settings
            GameSettings.Rows = source.Rows;
            GameSettings.Columns = source.Columns;
            Board board = new Board();
            foreach (Piece piece in source.GetPiecesForBoard())
            {
                board[piece.Row, piece.Column] = piece;
            }
            board.SaveBoard();

            return board;
        }

        /// <summary>
        /// Removes a given set of pieces and their corresponding groups from the board.
        /// </summary>
        /// <param name="groups">Array containing the piece numbers to be removed.</param>
        /// <returns>The number of groups actually used to complete the board.</returns>
        public int RemoveGroups(int?[] groups)
        {
            int stopPoint = groups.Length;
            for (int i = 0; i < groups.Length; i++)
            {
                if (hasMoves)
                {
                    if (groups[i] == null)
                    {
                        groups[i] = RandomSource.Instance.Next(0, GameSettings.PieceCount);
                    }

                    int? removed = RemoveGroup(groups[i].Value/GameSettings.Columns, groups[i].Value%GameSettings.Columns);

                    if (removed == null)
                    {
                        groups[i] = null;
                        stopPoint = i;
                    }
                    else
                    {
                        groups[i] = removed;
                    }
                }
                else
                {
                    groups[i] = null;
                }
            }
            return stopPoint;
        }

        public static Board CreateRandomBoard()
        {
            return CreateRandomBoard(null, null);
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
                    bool isDouble = (rng.NextDoublePositive() < 0.05) ? true : false;
                    bool isBomb = (!isDouble && rng.NextDoublePositive() < 0.05) ? true : false;
                    output[i, j] = new Piece(i, j, rng.Next(1, 6), isBomb, isDouble);
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
            if (pieces[row, col] == null)
            {
                return 0;
            }

            if (pieces[row, col].IsBomb && row == GameSettings.Rows - 1 && currentPieceCount == 0)
            {
                AddSurroundingPiecesForBomb(row, col);
                return GameSettings.GroupSize;
            }
            currentPieces[currentPieceCount++] = pieces[row, col];

            for (int i = 0; i < lookDirections.Length; i++)
            {
                Point nextPoint = lookDirections[i];

                //This code checks that the path is not backtracked, the rows and columns are within bounds, the new piece exists, the new piece has not been checked, and that the colors match.

                int nextColumn = col + nextPoint.ColInc;
                int nextRow = row + nextPoint.RowInc;
                if (dirFrom != Point.GetOppositeDirection(nextPoint.Dir) && 0 <= nextRow && nextRow < GameSettings.Rows && 0 <= nextColumn && nextColumn < GameSettings.Columns && Pieces[nextRow, nextColumn] != null && !Pieces[row, col].IsBomb && Pieces[nextRow, nextColumn].Color == Pieces[row, col].Color)
                {
                    bool isAlreadyContained = false;
                    for (int j = 0; j < currentPieceCount; j++)
                    {
                        if (currentPieces[j] == Pieces[nextRow, nextColumn])
                        {
                            isAlreadyContained = true;
                            break;
                        }
                    }

                    if (!isAlreadyContained)
                    {
                        count += DetermineGroup(nextRow, nextColumn, nextPoint.Dir);
                    }
                }
            }
            return count;
        }

        private void AddSurroundingPiecesForBomb(int row, int col)
        {
            for (int i = GameSettings.Rows - 2; i < GameSettings.Rows; i++)
            {
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    Piece piece = pieces[i, j];

                    if (piece != null && Math.Abs(piece.Row - row) <= 1 && Math.Abs(piece.Column - col) <= 1)
                    {
                        currentPieces[currentPieceCount++] = piece;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the closest group to the given piece number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The number of pieces that were removed.</returns>
        public int? RemoveGroup(int number)
        {
            Point location = GameSettings.GetLocationFromNumber(number);

            return RemoveGroup(location.RowInc, location.ColInc);
        }

        /// <summary>
        /// Gets a list of pieces that would be removed if the current move went through.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>The list of pieces that would be removed.</returns>
        public int? RemoveGroup(int row, int col)
        {
            int range = 0;
            while (true)
            {
                if (range >= GameSettings.Rows || range >= GameSettings.Columns)
                {
                    //No more groups to remove.
                    Score += (int) ((1 - (double) PieceCount/(GameSettings.Rows*GameSettings.Columns))*100);
                    HasMoves = false;
                    return null;
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

                        //currentGroup.Clear();
                        currentPieceCount = 0;

                        int count = DetermineGroup(row + i, col + j, Direction.None);
                        if (count >= GameSettings.GroupSize)
                        {
                            //return currentGroup;

                            int multiplier = 1;
                            int maxRow = 0,
                                minCol = GameSettings.Columns - 1;
                            for (int k = 0; k < currentPieceCount; k++)
                            {
                                Piece piece = currentPieces[k];

                                pieces[piece.Row, piece.Column] = null;
                                multiplier *= (piece.IsDouble) ? 2 : 1;

                                if (piece.Row > maxRow)
                                {
                                    maxRow = piece.Row;
                                }
                                if (piece.Column < minCol)
                                {
                                    minCol = piece.Column;
                                }
                            }

                            FillEmptySpaces(maxRow, minCol);
                            Score += count*count*multiplier;

                            return GameSettings.GetNumberFromLocation(row + i, col + j);
                        }
                    }
                }

                range++;
            }
        }

        //TODO:Refactor this into two separate steps.  One for moving pieces down.  Another for moving columns over if needed.
        public void FillEmptySpaces(int maxRow, int minCol)
        {
            int colGap = 0;
            for (int i = minCol; i < GameSettings.Columns; i++)
            {
                int rowGap = 0;
                bool colEmpty = true;
                for (int j = maxRow; j >= 0; j--)
                {
                    if (pieces[j, i] == null)
                    {
                        rowGap++;
                        continue;
                    }
                    colEmpty = false;

                    if (rowGap > 0 || colGap > 0)
                    {
                        pieces[j + rowGap, i - colGap] = Pieces[j, i];
                        pieces[j + rowGap, i - colGap].Row = j + rowGap;
                        pieces[j + rowGap, i - colGap].Column = i - colGap;
                        pieces[j, i] = null;
                    }
                }
                if (maxRow == GameSettings.Rows - 1 && colEmpty)
                {
                    colGap++;
                }
            }
        }

        public void SaveBoard()
        {
            Array.Copy(pieces, backupPieces, pieces.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < GameSettings.Rows; i++)
            {
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    Piece piece = pieces[i, j];
                    if (piece != null)
                    {
                        sb.Append(piece.Color);
                        if (piece.IsDouble)
                        {
                            sb.Append("d");
                        }
                    }
                    else
                    {
                        sb.Append("*");
                    }
                    sb.Append("\t");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        public void LoadOldBoard()
        {
            Score = 0;
            hasMoves = true;

            Array.Copy(backupPieces, pieces, pieces.Length);

            for (int i = 0; i < GameSettings.Rows; i++)
            {
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    pieces[i, j].Row = i;
                    pieces[i, j].Column = j;
                }
            }
        }
    }
}