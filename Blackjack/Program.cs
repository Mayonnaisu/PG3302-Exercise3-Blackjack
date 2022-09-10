// See https://aka.ms/new-console-template for more information

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blackjack");

            //GameInterface gi = new GameInterface();
            //gi.Init();

            User player = new User("Tobias");

            player.Hand[0] = Deck.CardValue.Ten;
            Console.WriteLine(player.Hand[0]);


            //Deck.CardValue[] test = new Deck.CardValue[11];
            //Console.WriteLine(test[0]);


        }
    }
}

