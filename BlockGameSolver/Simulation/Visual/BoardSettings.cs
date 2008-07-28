using System.Collections.Generic;
using System.Drawing;

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

        public static Color[] Colors
        {
            get { return colors; }
        }

        private static readonly Color[] colors = new[] { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple, Color.Black };
    }
}