using System.Collections.Generic;

namespace BlockGameSolver.Simulation.Visual
{
    public class BoardSettings
    {
        private static Dictionary<string, int> boardColors = new Dictionary<string, int>();

         static BoardSettings()
        {
             boardColors.Add("red", 1);
             boardColors.Add("blue",2);
             boardColors.Add("green",3);
             boardColors.Add("purple",4);
             boardColors.Add("orange",5);
        }

        public static Dictionary<string, int> BoardColors
        {
            get { return boardColors; }
        }
    }
}