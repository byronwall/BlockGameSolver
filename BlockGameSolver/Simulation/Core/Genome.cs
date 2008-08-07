using System.Text;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class Genome
    {
        private static int nextID;
        private readonly Board board;
        private readonly MersenneTwister rng = new MersenneTwister();

        public Genome(Board board) : this(board, true)
        {
        }

        public Genome(Board board, bool random)
        {
            this.board = board;
            Moves = new int?[GameSettings.MaxMoves];
            Fitness = 0d;
            ID = ++nextID;

            if (random)
            {
                for (int i = 0; i < GameSettings.MaxMoves; i++)
                {
                    Moves[i] = rng.Next(0, GameSettings.PieceCount);
                }
            }
        }

        public Genome(Genome genome) : this(genome.board, false)
        {
        }

        public int ID { get; set; }

        public int?[] Moves { get; set; }

        public double Fitness { get; set; }

        public int MoveCount { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public string GetMoveList()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Moves.Length; i++)
            {
                if (Moves[i] == null) break;

                sb.Append(Moves[i]);
                sb.Append(",");
            }
            return sb.ToString();
        }

        public void Evaluate()
        {
            board.SaveBoard();
            MoveCount = board.RemoveGroups(Moves);
            Fitness = board.Score;
            board.LoadOldBoard();
        }

        public static Genome FromGenome(Genome source)
        {
            Genome output = new Genome(source.board);
            source.Moves.CopyTo(output.Moves, 0);
            output.MoveCount = source.MoveCount;

            return output;
        }
    }
}