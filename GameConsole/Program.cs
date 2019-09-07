using GameLib;
using GameLib.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game(4,3);
            GeneralPlayer winner=myGame.PlayGame();
            if (winner != null)
            {
                Console.WriteLine($"Player {winner.Name} won");
            }
            else
            {
                winner = myGame.GetNearestResult();
                Console.WriteLine($"Player {winner.Name} gave the nearest result");

            }
            Console.ReadKey();
        }
    }
}
