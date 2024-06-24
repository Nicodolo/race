using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wettrennen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int game_speed = 1000/10;
            int anzahl = 20;
            
            Lebewesen[] array_lebewese = new Lebewesen[anzahl];
            for (int i = 0; i < array_lebewese.Length; i++)
            {
            if (i % 2 == 0)
            
                array_lebewese[i] = new Mensch(0,i *2 );
            
            else
                array_lebewese[i] = new Tier(0, i * 2);
            }
            
            //array_lebewese[0] = new Mensch(0,8);
            //array_lebewese[1]= new Mensch(0,6);
            
           // array_lebewese[2]= new Tier(0,10);
            //array_lebewese[3] = new Tier(0,12);
           
            //t1.setSpeed(1);
            
            Console.CursorVisible = false;
            
            bool running = true;
            
            while (running)
            {
                for (int i = 0; i < array_lebewese.Length; i++)
                {
                    
                    array_lebewese[i].zeichne();
                    array_lebewese[i].bewegen();
                    
                    if (array_lebewese[i].getPos_x() > 80)
                    {
                        Console.Beep();
                        running = false;
                        break;
                    }
                }
                 //Console.Clear();

                // int m_speed   = m1.getSpeed();
                // int m_pos_x   = m1.getPos_x();
                 //int new_pos_x = m_pos_x + m_speed;
                // m1.setPos_x(new_pos_x);
                  
                 Thread.Sleep(game_speed);
            }
            Console.ReadKey();
        }


        static void leaderboard(Lebewesen[] all_lw)
        {
            
        }

        static Lebewesen[] sort_Lebewesen_Array_By_XPos(Lebewesen[] all_lw)
        {
            Lebewesen[] new_lw_array = new Lebewesen[all_lw.Length];
            all_lw.CopyTo(new_lw_array, 0);

            for (int x = 0; x < new_lw_array.Length; x++)
            {
                for (int y = 0; y < new_lw_array.Length -1 ; y++)
                {
                    if (new_lw_array[y+1].getPos_x() > new_lw_array[y].getPos_x())
                    {
                        Lebewesen tmp_lw     = new_lw_array[y];
                        new_lw_array[y]     = new_lw_array[y + 1];
                        new_lw_array[y + 1] = tmp_lw;
                    }
                    
                }
            }

            return new_lw_array;
        }
    }
}