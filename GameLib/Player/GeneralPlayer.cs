using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// abstract class for players
    /// </summary>
    public abstract class GeneralPlayer
    {
        // fileds
        protected static int minWeight;
        protected static int maxWeight;
        protected int minimalDistanceToAnswer;
        /// <summary>
        /// all players answers store here
        /// </summary>
        public static int[] allPlayerAnswers;
        /// <summary>
        /// current player answers store here
        /// </summary>
        protected int[] curPlayerAnswers;

        // for the future update
        public enum PlayerType { RegPlayer, BloknotPlayer, UberPlayer, CheaterPlayer, UberCheaterPlayer };

        // ctors
        public GeneralPlayer(string playerName, int playerNumber)
        {
            this.Name = playerName;
            this.Number = playerNumber;
            curPlayerAnswers = new int[maxWeight];

        }

        // properties

        /// <summary>
        /// player name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// actionally, player number (just for debyg)
        /// </summary>
        public int Number { get; private set; }
        /// <summary>
        /// minimal distance to the right answer
        /// </summary>
        public int MimimalDistanceToAnswer
        {
            get { return minimalDistanceToAnswer; }
        }

        // methods

        /// <summary>
        /// Initiate general player settings for current game
        /// </summary>
        /// <param name="_minWeight"></param>
        /// <param name="_maxWeight"></param>
        public static void SetGuessLimits(int _minWeight, int _maxWeight)
        {
            minWeight = _minWeight;
            maxWeight = _maxWeight;
            allPlayerAnswers = new int[maxWeight];

        }

        /// <summary>
        /// Make turn abstract method
        /// </summary>
        /// <returns>return player answer as int</returns>
        public abstract int MakeTurn();
        
        /// <summary>
        /// find minimum distance from the right answer for the current player. 
        /// F.E. if guess value is 45 and nearest player answer was 44 and 47, return 1
        /// </summary>
        /// <param name="curAnswer">value, which plaer need to guess</param>
        public void FindDistanceToNearest(int curAnswer)
        {
            // make two arrays, left and righr sides from the answer. 
            int leftDistanceToAnswer = Int32.MaxValue, rightDistanceToAnswer = Int32.MaxValue;
            int[] leftArray = new int[curAnswer];
            int[] rightArray = new int[curPlayerAnswers.Length - 1 - curAnswer];
            Array.Copy(this.curPlayerAnswers, 0, leftArray, 0, curAnswer);
            Array.Copy(this.curPlayerAnswers, curAnswer + 1, rightArray, 0, curPlayerAnswers.Length - 2 - curAnswer);
            for (int i = (leftArray.Length - 1); i >=0; i--)
            {
                if (leftArray[i] != 0)
                {
                    leftDistanceToAnswer = (byte)(leftArray.Length - i);
                    break;
                }
            }
            for (int i = 0; i < rightArray.Length; i++)
            {
                if (rightArray[i] != 0)
                {
                    rightDistanceToAnswer = (byte)(i + 1);
                    break;
                }
            }

            this.minimalDistanceToAnswer = leftDistanceToAnswer <= rightDistanceToAnswer ? leftDistanceToAnswer : rightDistanceToAnswer;
           // Console.WriteLine($"left distance {leftDistanceToAnswer,10} ,right distance {rightDistanceToAnswer,10}, minimum distance {this.minimalDistanceToAnswer}");        
        }

        /// <summary>
        /// save current player answer in the player and all players answers List
        /// </summary>
        /// <param name="answer">player answer</param>
        protected void RegisterAnswer(int answer)
        {
            curPlayerAnswers[answer] = this.Number;
            allPlayerAnswers[answer] = this.Number;
        }

    }
}
