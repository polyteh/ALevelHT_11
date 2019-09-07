using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    class Bloknot:GeneralPlayer
    {

        public Bloknot(string playerName, byte playerNumber) : base(playerName, playerNumber)
        {

        }

        public override int MakeTurn()
        {
            Random rndAnwer = new Random();
            int answer;

            do
            {
                answer = rndAnwer.Next(1, maxWeight) - 1;
                if (curPlayerAnswers[answer] == 0)
                {
                    break; ;
                }

            } while (true);


            this.RegisterAnswer(answer);
            Console.WriteLine($"Player {this.Name,10} trn is {answer,3}");
            return answer;

        }

    }
}
