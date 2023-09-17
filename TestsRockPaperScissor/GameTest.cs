using RockPaperScissor.BusinessLogic;
using RockPaperScissor.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRockPaperScissor
{
    public class GameTest
    {
        [Fact]
        public void TestGenerateComputerWeapon()
        {
            // Arrange
            var game = new Game();

            // Act
            game.GenerateComputerWeapon();

            // Assert
            Assert.InRange(game.ComputerWeapon, 1, 3);
        }

        [Theory]
        [InlineData("rock", true)]
        [InlineData("PAPER", true)]
        [InlineData("SciSSor", true)]
        [InlineData("roc", false)]
        [InlineData("something", false)]
        [InlineData("papers", false)]
        [InlineData("scisor", false)]
        public void TestIsWeaponValid(string weapon, bool expected)
        {
            // Arrange 
            var game = new Game();

            // Act
            var isValid = game.IsWeaponValid(weapon);

            // Assert
            Assert.Equal(expected, isValid);
        }

        [Theory]
        [InlineData((int)Weapon.Rock, (int)Weapon.Rock, (int)Results.Draw)]
        [InlineData((int)Weapon.Rock, (int)Weapon.Scissor, (int)Results.Win)]
        [InlineData((int)Weapon.Rock, (int)Weapon.Paper, (int)Results.Lose)]
        [InlineData((int)Weapon.Paper, (int)Weapon.Paper, (int)Results.Draw)]
        [InlineData((int)Weapon.Paper, (int)Weapon.Rock, (int)Results.Win)]
        [InlineData((int)Weapon.Paper, (int)Weapon.Scissor, (int)Results.Lose)]
        [InlineData((int)Weapon.Scissor, (int)Weapon.Scissor, (int)Results.Draw)]
        [InlineData((int)Weapon.Scissor, (int)Weapon.Rock, (int)Results.Lose)]
        [InlineData((int)Weapon.Scissor, (int)Weapon.Paper, (int)Results.Win)]
        public void TestDecideTheWinner(int userWeapon, int computerWeapon, int expected)
        {
            // Arrange 
            var game = new Game();

            // Act
            game.DecideTheWinner(userWeapon, computerWeapon);

            // Assert
            Assert.Equal(expected, game.Result);
        }
    }
}
