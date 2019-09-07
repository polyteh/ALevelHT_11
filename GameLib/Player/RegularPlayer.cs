using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class RegularPlayer:GeneralPlayer,IPlayerActions
    {
        public RegularPlayer(string playerName, byte playerNumber):base(playerName, playerNumber)
        {

        }
        public override int MakeTurn()
        {
            Random rndAnwer = new Random();
            int answer = rndAnwer.Next(1, maxWeight) - 1;
            Console.WriteLine($"Player {this.Name,10} trn is {answer,3}");


            this.RegisterAnswer(answer);

            foreach (var item in allPlayerAnswers)
            {
                Console.Write($"{ item,3}");
            }
            Console.WriteLine();

            return answer;
        }
    }
}
