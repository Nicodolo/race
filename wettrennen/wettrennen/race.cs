using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
 
namespace Wettrennen
{
    //internal interface iRaceElement
    //{
      //  void bewegen();
      //  void zeichne();
      //  void getPos_x();
    //}
 
    internal class Race
    {
        private int         game_speed                  = 1000 / 10;
        private int         anzahl                      = 4;
        private int         ziellinie                   = 20;
        private wettrennen.Lebewesen[] array_lebewesen  = null;    
        private bool        running                     = false;
 
            public Race()
        {
            this.Benutzereingaben();            
        }
 
        public void Benutzereingaben()
        {
            Console.WriteLine("Hallo, Willkommen zum Rennen!");
            Console.WriteLine("===========================================");
            Console.Write    ("Geben Si edie Anzhl der Teilnehmer ein:");
            
            this.anzahl    = Convert.ToInt32(Console.ReadLine());
            Console.Write    ("Geben Sie die Länge des Rennens ein:");
            
            this.ziellinie = Convert.ToInt32(Console.ReadLine());
 
            this.erzeugeLebewesen();
            this.zeichneSpielfeld();
 
            Console.CursorVisible = false;
 
        }
 
        
        private void zeichneSpielfeld()
        {
            for (int i = 0; i < this.array_lebewesen.Length; i++)
            {
                Console.SetCursorPosition(0, i * 2 + 1);
                Console.Write(new string ('=', this.ziellinie +5));
            }
            for (int i = 0; i < this.array_lebewesen.Length*2; i++)
            {
                Console.SetCursorPosition(this.ziellinie-1, i);
                Console.Write('|');
 
            }
        }
        public void start() 
        {
            this.running = true;
            while (this.running)
            {
                for (int i = 0; i < this.array_lebewesen.Length; i++)
                {
                    Console.SetCursorPosition(0, i * 2 + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = (ConsoleColor)i + 1;
                    
                    this.array_lebewesen[i].zeichne();
                    this.array_lebewesen[i].bewegen();
 
                    if (this.array_lebewesen[i].getPos_x() > this.ziellinie)  //<<Ziellinie
                    {
                        Console.Beep();
                        this.running = false;
                        break;
                    }
                }
                this.leaderboard();
                Thread.Sleep(this.game_speed);
            }
        }
 
        private void erzeugeLebewesen() 
        {
            this.array_lebewesen = new wettrennen.Lebewesen[this.anzahl];
 
            for (int i = 0; i < this.array_lebewesen.Length; i++)
            {
                if (i % 2 == 0)
                {
                    this.array_lebewesen[i] = new wettrennen.Mensch(0, i * 2);
                    Console.Write("Geben Sie den Namen des " + (i + 1) + "'sten Lebewesen ein.");
                    this.array_lebewesen[i].setName(Console.ReadLine());
                }
                else
                {
                    this.array_lebewesen[i] = new wettrennen.Tier(0, i * 2 );
                    Console.Write("Geben Sie den Namen des " + (i + 1) + "'sten Lebewesen ein.");
                    this.array_lebewesen[i].setName(Console.ReadLine());
                }
                this.array_lebewesen[i].bahn_nr = i + 1;
            }
            Console.Clear();
        }
 
        private void leaderboard()
        {
            wettrennen.Lebewesen[] lb_array = sort_Lebewesens_Array_By_XPos();
            for (int i = 0; i < lb_array.Length; i++)
            {
                string name = lb_array[i].getName();
                Console.SetCursorPosition(0, (this.anzahl * 2 )+ 1 + i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("#" + (i + 1) + ":  Bahn " + lb_array[i].bahn_nr + "  : " + name + "        ");
            }
        }
        private wettrennen.Lebewesen[] sort_Lebewesens_Array_By_XPos()
        {
            wettrennen.Lebewesen[] new_lw_array = new wettrennen.Lebewesen[this.array_lebewesen.Length];
           this.array_lebewesen.CopyTo(new_lw_array, 0);
 
            //bubble sort
            for (int x = 0; x < new_lw_array.Length; x++)
            {
                for (int y = 0; y < new_lw_array.Length - 1; y++)
                {
                    if (new_lw_array[y + 1].getPos_x() > new_lw_array[y].getPos_x())
                    {
                        wettrennen.Lebewesen tmp_lw    = new_lw_array[y];
                        new_lw_array[y]     = new_lw_array[y + 1];
                        new_lw_array[y + 1] = tmp_lw;
                    }
                }
            }
 
            return new_lw_array;
        }
 
 
    }
}
        