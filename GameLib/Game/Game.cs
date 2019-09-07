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
        //fields

        // number of turns
        private int curTurnNumber = 0;
        /// <summary>
        /// minimum value to guess
        /// </summary>
        private readonly int minValue = 40;
        /// <summary>
        /// maximum value to guess
        /// </summary>
        private readonly int maxnValue = 140;

        /// <summary>
        /// List of players
        /// </summary>
        private List<GeneralPlayer> curPlayers;

        /// <summary>
        /// make new game
        /// </summary>
        /// <param name="_guessValue">value to guess</param>
        /// <param name="_numberOfTurns">maximum number of turns</param>
        public Game(int _guessValue, int _numberOfTurns)
        {
            // normalization to work with arrays without shift
            this.GuessValue = _guessValue - minValue;
            this.MaxNumberOfTurns = _numberOfTurns;
            GeneralPlayer.SetGuessLimits(0, maxnValue - minValue + 1);//need +1 from to range [40..140]
            curPlayers = new List<GeneralPlayer>();
        }

        // properties
        protected int GuessValue { get; private set; }
        public int MaxNumberOfTurns { get; set; }

        // methods

        /// <summary>
        /// start the game
        /// </summary>
        /// <returns>return player as GeneralPlayer if somebody guessed  overwise return null</returns>
        public GeneralPlayer PlayGame()
        {
            bool continueGame = true;

            do
            {
                foreach (var player in curPlayers)
                {
                    if (curTurnNumber >= this.MaxNumberOfTurns)
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

        /// <summary>
        /// player turns
        /// </summary>
        /// <param name="curPlayer">player, who make the turn</param>
        /// <returns>true if right answer overwise false</returns>
        private bool NextTurn(GeneralPlayer curPlayer)
        {
            int curAnswer = curPlayer.MakeTurn();
            /// Console.WriteLine($"Cur answer{curAnswer}");

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

        /// <summary>
        /// if nobode gave right answer, return player who gave the nearest valu
        /// </summary>
        /// <returns></returns>
        public GeneralPlayer GetNearestResult()
        {

            foreach (var player in curPlayers)
            {
                player.FindDistanceToNearest(this.GuessValue);
            }

            GeneralPlayer nearestPlayer = curPlayers.OrderBy(index => index.MimimalDistanceToAnswer).First();
            return nearestPlayer;
        }

        /// <summary>
        /// add new player to the game
        /// </summary>
        /// <param name="_newPlayer"></param>
        public void AddPlayer(GeneralPlayer _newPlayer)
        {
            curPlayers.Add(_newPlayer);
        }


    }
}
