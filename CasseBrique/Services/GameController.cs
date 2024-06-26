using CasseBrique.GameObjects;
using CasseBrique.Props;
using CasseBrique.Scenes;
using CasseBrique.Scenes.Interfaces;
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
        public int maxLevel { get; private set; }
        public int lifes { get; private set; } = 3;

        public List<GameObject> replacement = new List<GameObject>();
        public GameController()
        {
            ServiceLocator.Register<GameController>(this);
            maxLevel = CountLevel();
        }

        private int CountLevel()
        {
            string dirpath = $"Levels";
            if (Directory.Exists(dirpath))
            {
                string[] files = Directory.GetFiles(dirpath, "Level*.txt");
                return files.Length;
            }
            else
                throw new DirectoryNotFoundException($"Directory on {dirpath} not found");
        }

        public void TakeDamage()
        {
            lifes--;
            if(lifes <= 0)
            {
                ServiceLocator.Get<IScenesManager>().LoadScene<SceneDefaite>();
                ResetScene();
            }
        }
        
        private void ResetScene()
        {
            this.lifes = 3;
            this.currentLevel = 1;
        }

        public void NextLevel()
        {
            currentLevel++;
        }

        public void SetBonus(Bonus bonus)
        {
            replacement.Add(bonus);
        }

        public void Replace(ref List<GameObject> sceneGameObjects)
        {
            foreach (var item in replacement)
            {
                sceneGameObjects.Add(item);
            }
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
                    switch (lines[row][column])
                    {
                        case '1':
                            brickLevelComposition[row, column] = 1;
                            break;
                        case '2':
                            brickLevelComposition[row, column] = 2;
                            break;
                    }
            
            return brickLevelComposition;
        }

    }
}
