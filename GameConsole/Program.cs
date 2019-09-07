using GameLib;
using GameLib.Game;
using GameLib.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        enum Menu : byte { Newgame = 1, Exit }
        static void Main(string[] args)
        {

            // value, that players need to guess and maximum number of turns
            int valueToGuess = 45;
            int maxNumberOfTurns = 100;
            int minValueToGuess = 40;
            int maxValueToGuess = 140;

            bool continueGame = true;

            do
            {
                Console.WriteLine($"Choose your action\n1 - Play new game\n2 - Exit");
                int action = int.Parse(Console.ReadLine());
                Menu menuOperation = (Menu)action;

                // simple menu logic
                switch (menuOperation)
                {
                    case Menu.Newgame:
                        {

                            try
                            {
                                Console.WriteLine("Enter value to guess");
                                valueToGuess = int.Parse(Console.ReadLine());

                                if (valueToGuess<minValueToGuess||valueToGuess>maxValueToGuess)

                                {
                                    throw new ArgumentOutOfRangeException();
                                }

                                // create a new game
                                Game myGame = new Game(valueToGuess, maxNumberOfTurns);

                                // create new players add add them to the game
                                RegularPlayer myRegularPlayer = new RegularPlayer("Vasya", 1);
                                UberPlayer myUberPlayer = new UberPlayer("Gans", 2);
                                Bloknot myBloknotPlayer = new Bloknot("Igor Valerievish", 3);
                                Cheater myCheaterPlayer = new Cheater("Gome Simson", 4);
                                UberCheater myUberCheaterPlayer = new UberCheater("Mozzg", 5);

                                myGame.AddPlayer(myRegularPlayer);
                                myGame.AddPlayer(myUberPlayer);
                                myGame.AddPlayer(myBloknotPlayer);
                                myGame.AddPlayer(myCheaterPlayer);
                                myGame.AddPlayer(myUberCheaterPlayer);


                                // start game
                                GeneralPlayer winner = myGame.PlayGame();
                                // write name of the pleyer, who guessed the value if exist
                                if (winner != null)
                                {
                                    Console.WriteLine($"Player {winner.Name} won");
                                }
                                // or write name of the pleyer, who gave the nearest value
                                else
                                {
                                    winner = myGame.GetNearestResult();
                                    Console.WriteLine($"Player {winner.Name} gave the nearest result");

                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Value to guess should be in range [40,140]");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Cant parse to int");

                            }
                            break;
                        }

                    case Menu.Exit:
                        {
                            continueGame = false;
                            break;
                        }

                }


            } while (continueGame);


            Console.ReadKey();
        }
    }
}
