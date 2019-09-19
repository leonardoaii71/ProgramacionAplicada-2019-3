using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace puzzle
{
    public enum CurrentState
    {
       Starting,
       Menu,
       Playing,
       Idle,
       Over
    }

    public class Puzzle { 
    
        public char[,] table { get; set; }
        public CurrentState State { get; set; }

    }
    class Program
    {
        
        const int COLUMNS = 10, ROWS = 4;
        const int LftM = 4, TOPM = 2;
        const int FPS = 30;
        public static Puzzle puzzle;
        static Thread input;

        static void Main(string[] args)
        {
            Start();

            while (puzzle.State != CurrentState.Over)
            {
                switch (puzzle.State)
                {
                    case CurrentState.Menu:
                        DisplayMenu();
                        break;
                    case CurrentState.Starting:
                        Render();
                        break;
                    case CurrentState.Playing:
                        Update();
                        break;
                    default:
                        break;

                }
                Thread.Sleep(FPS);
            }
            input.Abort();
            input.Join();
        }


        public static void Start()
        {
            puzzle = new Puzzle();
            puzzle.State = CurrentState.Menu;
            puzzle.table = new char[3, 3];
            input = new Thread(ReadKeys);
            input.Start();
        }

        public static void Update()
        {
            Render();
        }

        public static void ReadKeys()
        {
            string option;
            if (puzzle.State == CurrentState.Starting)
            {
                option = Console.ReadKey().KeyChar.ToString();
                puzzle.State = CurrentState.Playing;
            }
            if (puzzle.State == CurrentState.Menu)
            {
                option = Console.ReadKey().KeyChar.ToString();
                if(option == "1")
                    puzzle.State = CurrentState.Starting;
            }
         
            if (puzzle.State == CurrentState.Playing)
            {

            }
            
               //puzzle.State = CurrentState.Over;
           
        }
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("-- THE ULTIMATE PUZZLE --");
            Console.WriteLine("\nPresione el numero de la opción que desea: ");
            Console.WriteLine("\n\t1: Jugar");
            Console.WriteLine("\t2: Salir");
        }

        static void Render()
        {
            Console.Clear();
            Console.WriteLine("_________________");
            Console.WriteLine("  6  |  4  |  3  ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("  5  |  2  |  7  ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("  1  |     |  8  ");
            Console.WriteLine("_____|_____|_____");
            if (puzzle.State == CurrentState.Starting)
            {
                Console.Write("Seleccione la celda de 1 - 9 a donde quiere mover el espacio en blanco");
            }
            
        }

    }
}
