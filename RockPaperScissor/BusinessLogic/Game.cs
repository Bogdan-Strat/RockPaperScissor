using RockPaperScissor.ExtensionMethods;
using RockPaperScissor.Resources;
using System;
using System.Collections.Generic;
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
                    Console.WriteLine(UserWeapon);
                    GameRound++;
                    break;
                }
                else
                {
                    Console.WriteLine("Weapon is invalid. Please select again.");
                }
            }
        }


        public void DecideTheWinner()
        {
            if(UserWeapon == ComputerWeapon)
            {
                Result = (int)Results.Draw;
            }
            else if(UserWeapon == (int)Weapon.Rock)
            {
                if(ComputerWeapon == (int)Weapon.Paper)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
            else if (UserWeapon == (int)Weapon.Paper)
            {
                if (ComputerWeapon == (int)Weapon.Scissor)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
            else if (UserWeapon == (int)Weapon.Scissor)
            {
                if (ComputerWeapon == (int)Weapon.Rock)
                {
                    Result = (int)Results.Lose;
                }
                else
                {
                    Result = (int)Results.Win;
                }
            }
        }

        public string ProcessTheResult()
        {
            if(Result == (int)Results.Draw)
            {
                return $"The result is draw. The computer choose also: {((Weapon)ComputerWeapon).ToString().ToLower()}";
            }
            else if(Result == (int)Results.Lose)
            {
                return $"You lost, computer chose {((Weapon)ComputerWeapon).ToString().ToLower()} and won";
            }

            return $"You won, computer chose {((Weapon)ComputerWeapon).ToString().ToLower()} and loosed";
        }

        public void Play()
        {
            while (true)
            {
                GenerateComputerWeapon();
                SelectTheWeaponFromTheUser();
                DecideTheWinner();
                var resultMessage = ProcessTheResult();
                Console.WriteLine(resultMessage);

            }
        }
    }
}
