using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.BusinessLogic.Models
{
    public class SaveResultsModel
    {
        public bool Win { get; set; }
        public bool Draw { get; set; }
        public bool Loose { get; set; }

        public SaveResultsModel()
        {
            Win = false;
            Draw = false;
            Loose = false; 
        }
    }
}
