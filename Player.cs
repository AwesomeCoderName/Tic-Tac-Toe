using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac.ObjectModels
{
    internal class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Piece { get; set; }
        public List<int> Conquered { get; set; } = new List<int>(); // The Space/Buttons that player has pressed / conquered 
    }
}
