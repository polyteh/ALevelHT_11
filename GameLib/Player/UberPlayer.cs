using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class UberPlayer:GeneralPlayer
    {
        private int answerByOrder;
        public UberPlayer(string playerName, byte playerNumber) : base(playerName, playerNumber)
        {

        }

        public override int MakeTurn()
        {
            int answerToReturn = answerByOrder;


            this.RegisterAnswer(answerToReturn);
    
            //Console.WriteLine($"Player {this.Name,10} trn is {answerByOrder,3}");
            answerByOrder++;
            return answerToReturn;

        }

    }
}
