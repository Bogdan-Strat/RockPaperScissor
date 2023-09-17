using Newtonsoft.Json.Linq;
using RockPaperScissor.BusinessLogic;
using RockPaperScissor.BusinessLogic.Models;

namespace TestsRockPaperScissor
{
    public class FileManagerTest
    {
        private readonly FileManager fileManager;
        private readonly string statisticsFilePath;

        public FileManagerTest()
        {
            fileManager = new FileManager();
            statisticsFilePath = @"C:\Users\strat\source\repos\RockPaperScissor\RockPaperScissor\Resources\TestStatistics.txt";
        }

        [Theory]
        [InlineData(1, 0, 0, "100.00", "0.00", "0.00")]
        [InlineData(5, 0, 0, "100.00", "0.00", "0.00")]
        [InlineData(4, 0, 1, "80.00", "0.00", "20.00")]
        [InlineData(2, 2, 2, "33.33", "33.33", "33.33")]
        [InlineData(3, 4, 7, "21.43", "28.57", "50.00")]
        public void TestGetStatistics(int wins, int draws, int looses, string expectedWin, string expectedDraw, string expectedLoose)
        {
            // Arrange

            // Act
            var statistics = fileManager.GetStatistics(wins, draws, looses);

            // Assert
            Assert.Equal(expectedWin, statistics.Win);
            Assert.Equal(expectedDraw, statistics.Draw);
            Assert.Equal(expectedLoose, statistics.Loose);
        }

        [Theory]
        [InlineData(1, 4, 5, "Win: 1\n" +
                    "Draw: 4\n" +
                    "Loose: 5\n")]
        [InlineData(0, 0, 1, "Win: 0\n" +
                    "Draw: 0\n" +
                    "Loose: 1\n")]
        [InlineData(8914, 14859, 1023, "Win: 8914\n" +
                    "Draw: 14859\n" +
                    "Loose: 1023\n")]
        public async Task TestWriteResultsInFile(int wins, int draws, int loose, string expected)
        {
            // Arrange

            // Act
            await fileManager.WriteResultsInFile(wins, draws, loose, statisticsFilePath);
            var fileContent = await File.ReadAllTextAsync(statisticsFilePath);

            // Assert
            Assert.Equal(expected, fileContent);
            
        }
    }
}