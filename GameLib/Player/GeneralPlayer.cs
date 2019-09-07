using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public abstract class GeneralPlayer
    {
        protected static int minWeight;
        protected static int maxWeight;


        protected int minimalDistanceToAnswer;
        public static int[] allPlayerAnswers;
        protected int[] curPlayerAnswers;

        public enum PlayerType { RegularPlayer, UberPlyer };

        public GeneralPlayer(string playerName, int playerNumber)
        {
            this.Name = playerName;
            this.Number = playerNumber;
            curPlayerAnswers = new int[maxWeight];

        }

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

        public string Name { get; private set; }
        public int Number { get; private set; }
        public int MimimalDistanceToAnswer
        {
            get { return minimalDistanceToAnswer; }
        }


        public int[] GetAllPlayerAnswers()
        {
            return allPlayerAnswers.ToArray();
        }
        public abstract int MakeTurn();



        public void FindDistanceToNearest(int curAnswer)
        {

            int[] testFor0_10 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 7, 9, 1 };
           // curPlayerAnswers = testFor0_10;
            Console.WriteLine(this.GetType());
            foreach (var item in curPlayerAnswers)
            {
                Console.Write($"{ item,3}");
            }

            int leftDistanceToAnswer = Int32.MaxValue, rightDistanceToAnswer = Int32.MaxValue;
            int[] leftArray = new int[curAnswer];
            int[] rightArray = new int[curPlayerAnswers.Length - 1 - curAnswer];
            Array.Copy(this.curPlayerAnswers, 0, leftArray, 0, curAnswer);
            Array.Copy(this.curPlayerAnswers, curAnswer + 1, rightArray, 0, curPlayerAnswers.Length - 2 - curAnswer);
            for (int i = (leftArray.Length - 1); i > 0; i--)
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
            Console.WriteLine($"left distance {leftDistanceToAnswer,10} ,right distance {rightDistanceToAnswer,10}, minimum distance {this.minimalDistanceToAnswer}");


        }

        protected void RegisterAnswer(int answer)
        {
            curPlayerAnswers[answer] = this.Number;
            allPlayerAnswers[answer] = this.Number;
        }

    }
}
