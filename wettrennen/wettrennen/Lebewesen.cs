using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wettrennen
{
    internal abstract class Lebewesen
    {
        private static Random randy = new Random();
        private float speed;
        private float pos_x;
        private float pos_y;
        private char symbol;
        public int bahn_nr;

        public Lebewesen(char in_symbol)
        {
            this.symbol = in_symbol;
            this.speed = this.makeRandomSpeed();
            this.pos_x = 0;
            this.pos_y = 0;
        }
        public void zeichne()
        {
            Console.SetCursorPosition((int)Math.Round(this.getPos_x()), 
                                      (int)Math.Round(this.getPos_y()));
            Console.Write( this.getSymbol() );
            

            if (Math.Round(this.getPos_x()) >= 1)
            {
                Console.SetCursorPosition((int)Math.Round(this.getPos_x()-1), 
                                            (int)Math.Round(this.getPos_y() ) );
                Console.Write( " " );
            }
        }
        private float makeRandomSpeed()
                 {
                     return randy.Next(15, 95) * 0.01f;
                 }
        public void bewegen()
        {
            this.setPos_x( this.getPos_x() +  this.getSpeed() );

            this.speed = this.makeRandomSpeed();
        }
        
        public char getSymbol()
        {
            return this.symbol;
        }
        public float getSpeed()
        {
            return this.speed;
        }

        public float getPos_x()
        {
            return this.pos_x;
        }

        public float getPos_y()
        {
             return this.pos_y;
        }



        public void setSpeed(float in_speed)
        {
            this.speed = in_speed;
        }


        public void setPos_x(float in_pos_x)
        {
            this.pos_x = in_pos_x;
        }

        public void setPos_y(float in_pos_y)
        {
            this.pos_y = in_pos_y;
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        public void setName(string? readLine)
        {
            throw new NotImplementedException();
        }
    }
}