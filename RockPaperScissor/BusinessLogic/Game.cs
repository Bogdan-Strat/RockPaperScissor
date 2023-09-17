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

        public void GenerateComputerWeapon()
        {
            var random = new Random();
            ComputerWeapon = random.Next(1, 4);
        }
    }
}
