﻿using RockPaperScissor.ExtensionMethods;
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
                    Console.WriteLine("Weapon is invalid. Please select again.\nChoose your weapon");
                }
            }
        }
    }
}
