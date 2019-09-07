using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class UberCheater:GeneralPlayer
    {
        private int answerByOrder;
        public UberCheater(string playerName, byte playerNumber) : base(playerName, playerNumber)
        {

        }

        public override int MakeTurn()
        {
            
            do
            {
                
                if (allPlayerAnswers[answerByOrder] == 0)
                {
                    break; 
                }
                else
                {
                    answerByOrder++;
                }
                

            } while (true);


            this.RegisterAnswer(answerByOrder);
            int answerToReturn = answerByOrder;
            Console.WriteLine($"Player {this.Name,10} trn is {answerToReturn,3}");
            answerByOrder++;
            return answerToReturn;

        }


    }
}
