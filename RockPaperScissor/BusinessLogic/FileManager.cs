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

        public async Task<StatisticModel> SaveResults(SaveResultsModel model)
        {
            int wins, draws, looses;
            if (!File.Exists(statisticFilePath))
            {
                wins = model.Win == true ? 1 : 0;
                draws = model.Draw == true ? 1 : 0;
                looses = model.Loose == true ? 1 : 0;

                await WriteResultsInFile(wins, draws, looses, statisticFilePath);
            }
            else
            {
                var lines = await File.ReadAllLinesAsync(statisticFilePath);

               
                int.TryParse(lines[0].Split(' ')[1], out wins);
                int.TryParse(lines[1].Split(' ')[1], out draws);
                int.TryParse(lines[2].Split(' ')[1], out looses);
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

                await WriteResultsInFile(wins, draws, looses, statisticFilePath);

            }

            return GetStatistics(wins, draws, looses);
        }

        public async Task WriteResultsInFile(int wins, int draws, int looses, string filePath)
        {
            using (var outputFile = new StreamWriter(filePath))
            {
               await outputFile.WriteAsync($"Win: {wins}\n" +
                    $"Draw: {draws}\n" +
                    $"Loose: {looses}\n");
                outputFile.Close();
            }
        }

        public StatisticModel GetStatistics(int wins, int draws, int looses)
        {
            decimal allGames = wins + draws + looses;

            return new StatisticModel()
            {
                Win = (wins / allGames * 100).ToString("0.00"),
                Draw = (draws / allGames * 100).ToString("0.00"),
                Loose = (looses / allGames * 100).ToString("0.00")
            };
        }
    }
}
