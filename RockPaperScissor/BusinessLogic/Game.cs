using RockPaperScissor.BusinessLogic.Models;
using RockPaperScissor.ExtensionMethods;
using RockPaperScissor.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.BusinessLogic
{
    public class Game
    {
        public int UserWeapon { get; set; }
        public int ComputerWeapon { get; set; }
        public static int GameRound { get; set; } = 1;
        public int Result { get; set; }

       private readonly FileManager fileManager;

        public Game()
        {
            fileManager = new FileManager();
        }
       
        public void GenerateComputerWeapon()
        {
            var random = new Random();
            ComputerWeapon = random.Next(1, 4);
        }

        public bool IsWeaponValid(string weapon)
        {
            foreach(var enumWeapon in Enum.GetNames(typeof(Weapon)))
            {
                if(weapon.ToLower() == enumWeapon.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public void SelectTheWeaponFromTheUser()
        {
            while (true)
            {
                Console.WriteLine($"Round {GameRound} - choose your weapon: ");
                var weapon = Console.ReadLine();

                if (weapon != null && IsWeaponValid(weapon))
                {
                    UserWeapon = (int)(Weapon)Enum.Parse(typeof(Weapon), weapon.ToLower().CapitalizeFirstLetter());
                    GameRound++;
                    break;
                }
                else
                {
                    Console.WriteLine("Weapon is invalid. Please select again.");
                }
            }
        }


        public void DecideTheWinner(int userWeapon, int computerWeapon)
        {
            if(userWeapon == computerWeapon)
            {
                Result = (int)Results.Draw;
            }
            else if(userWeapon == (int)Weapon.Rock)
            {
                if(computerWeapon == (int)Weapon.Paper)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
            else if (userWeapon == (int)Weapon.Paper)
            {
                if (computerWeapon == (int)Weapon.Scissor)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
            else if (userWeapon == (int)Weapon.Scissor)
            {
                if (computerWeapon == (int)Weapon.Rock)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
        }

        public StatisticModel ProcessTheResult()
        {
            var saveResultModel = new SaveResultsModel();
            if (Result == (int)Results.Draw)
            {
                saveResultModel.Draw = true;

                Console.WriteLine($"The result is draw. The computer choose also: {((Weapon)ComputerWeapon).ToString().ToLower()}");

                return fileManager.SaveResults(saveResultModel);
            }
            else if(Result == (int)Results.Lose)
            {
                saveResultModel.Loose = true;

                Console.WriteLine($"You lost, computer chose {((Weapon)ComputerWeapon).ToString().ToLower()} and won");

                return fileManager.SaveResults(saveResultModel);
            }

            saveResultModel.Win = true;

            Console.WriteLine($"You won, computer chose {((Weapon)ComputerWeapon).ToString().ToLower()} and loosed");

            return fileManager.SaveResults(saveResultModel);
        }

       

        public void Play()
        {
            while (true)
            {
                GenerateComputerWeapon();
                SelectTheWeaponFromTheUser();
                DecideTheWinner(UserWeapon, ComputerWeapon);
                
                var statistics = ProcessTheResult();
                Console.WriteLine($"{statistics.Win.ToString("0.00")}% won by user, {statistics.Loose.ToString("0.00")}% won  by computer, {statistics.Draw.ToString("0.00")}% draws");

            }
        }
    }
}
