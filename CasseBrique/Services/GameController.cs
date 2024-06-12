using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services
{
    public class GameController
    {
        public int currentLevel { get; private set; } = 1;
        public int maxLevel { get; private set; } = 3;
        public int lifes { get; private set; } = 1;
        public GameController()
        {
            ServiceLocator.Register<GameController>(this);
        }


        public int[,] getBricksLevel()
        {
            string filepath = $"Levels/level{currentLevel}.txt";

            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            int rows = lines.Count;
            int columns = lines[0].Length;
            int[,] brickLevelComposition = new int[rows, columns];

            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                    brickLevelComposition[row, column] =  lines[row][column] == '1' ? 1 : 0;

            return brickLevelComposition;
        }

    }
}
