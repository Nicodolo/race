using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wettrennen
{
    internal class Tier : Lebewesen
    {
        private const char tier_symbol = 'O';
        public Tier() : base(tier_symbol)
        {
            
        }
        public Tier(int in_pos_x, int in_pos_y) : base(tier_symbol)
        {
            this.setPos_x(in_pos_x);
            this.setPos_y(in_pos_y);
        }

    }

}