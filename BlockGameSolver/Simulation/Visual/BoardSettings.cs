using System.Collections.Generic;

namespace BlockGameSolver.Simulation.Visual
{
    public class BoardSettings
    {
        private static Dictionary<string, int> boardColors = new Dictionary<string, int>();

         static BoardSettings()
        {
             boardColors.Add("blue", 1);
             boardColors.Add("red",2);
             boardColors.Add("green",3);
             boardColors.Add("yellow",4);
             boardColors.Add("purple",5);
        }

        public static Dictionary<string, int> BoardColors
        {
            get { return boardColors; }
        }
    }
}