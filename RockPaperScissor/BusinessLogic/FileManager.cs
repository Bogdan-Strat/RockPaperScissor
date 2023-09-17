using RockPaperScissor.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.BusinessLogic
{
    public class FileManager
    {
        private readonly string statisticFilePath;

        public FileManager()
        {
            statisticFilePath = @"C:\Users\strat\source\repos\RockPaperScissor\RockPaperScissor\Resources\Statistics.txt";
        }

        public void SaveResults(SaveResultsModel model)
        {
            if (!File.Exists(statisticFilePath))
            {
                WriteResultsInFile(model.Win == true ? 1 : 0, model.Draw == true ? 1 : 0, model.Loose == true ? 1 : 0);
            }
            else
            {
                var lines = File.ReadAllLines(statisticFilePath);

                int wins, draws, looses;
                Int32.TryParse(lines[0].Split(' ')[1], out wins);
                Int32.TryParse(lines[1].Split(' ')[1], out draws);
                Int32.TryParse(lines[2].Split(' ')[1], out looses);
                if (model.Win)
                {
                    wins++;
                }
                else if (model.Draw)
                {
                    draws++;
                }
                else
                {
                    looses++;
                }

                WriteResultsInFile(wins, draws, looses);

            }
        }

        public void WriteResultsInFile(int wins, int draws, int looses)
        {
            using (var outputFile = new StreamWriter(statisticFilePath))
            {
                outputFile.Write($"Win: {wins}\n" +
                    $"Draw: {draws}\n" +
                    $"Loose: {looses}\n");
            }
        }
    }
}
