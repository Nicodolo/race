using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wettrennen
{
    internal class Mensch : Lebewesen
    {
        private const char mensch_symbol = 'x';
        public Mensch() : base(mensch_symbol)
        {
            
        }

        public Mensch(int in_pos_x, int in_pos_y) : base(mensch_symbol)
        {
            this.setPos_x(in_pos_x);
            this.setPos_y(in_pos_y);
        }
    }
}