using GameLib.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Game
{
    public class Game
    {
        private int curTurnNumber=0;
        private readonly int minValue = 40;
        private readonly int maxnValue = 140;

        private List<GeneralPlayer> curPlayers;
        public Game(int _guessValue, int _numberOfTurns)
        {
            this.GuessValue = _guessValue;
            this.MaxNumberOfTurns = _numberOfTurns;
            GeneralPlayer.SetGuessLimits(0,11);//need +1 from to range 0..10
            curPlayers = new List<GeneralPlayer>();
        }
        public int GuessValue { get; private set; }
        //private IPlayerActions PlayerMakeTurn { get; set; }
        public int MaxNumberOfTurns { get; set; }

        public GeneralPlayer PlayGame()
        {
            RegularPlayer myRegularPlayer = new RegularPlayer("vasya", 1);
            UberPlayer myUberPlayer = new UberPlayer("petya", 2);
            Bloknot myBloknotPlayer = new Bloknot("serg", 3);
            Cheater myCheaterPlayer = new Cheater("gomer", 4);
            UberCheater myUberCheaterPlayer = new UberCheater("mozzg", 5);

            curPlayers.Add(myRegularPlayer);
            curPlayers.Add(myUberPlayer);
            curPlayers.Add(myBloknotPlayer);
            curPlayers.Add(myCheaterPlayer);
            curPlayers.Add(myUberCheaterPlayer);

            bool continueGame = true;

            do
            {
                foreach (var player in curPlayers)
                {
                    if (curTurnNumber>=this.MaxNumberOfTurns)
                    {
                        continueGame = false;
                        return null;
                    }
                    if (this.NextTurn(player))
                    {
                        continueGame = false;
                        return player;
                    }
                    else
                    {
                        curTurnNumber++;
                    }

                }

            } while (continueGame);


            return null;

        }

        private bool NextTurn(GeneralPlayer curPlayer)
        {
            int curAnswer = curPlayer.MakeTurn();
            Console.WriteLine($"Cur answer{curAnswer}");

            if (this.GuessValue == curAnswer)
            {

                Console.WriteLine("Game over");
                return true;
            }
            else
            {
                return false;
            }
        }

        public GeneralPlayer GetNearestResult()
        {

            foreach (var player in curPlayers)
            {
                player.FindDistanceToNearest(this.GuessValue);
            }

            GeneralPlayer nearestPlayer = curPlayers.OrderBy(index => index.MimimalDistanceToAnswer).First();
            return nearestPlayer;
        }

        public void AddPlayer(GeneralPlayer _newPlayer)
        {
            curPlayers.Add(_newPlayer);
        }


    }
}
