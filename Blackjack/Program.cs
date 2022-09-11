// See https://aka.ms/new-console-template for more information

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blackjack");

            GameInterface gi = new GameInterface();
            gi.Init();



            //User player = new User("Tobias");

            //player.Hand[0] = Deck.CardValue.Ten;
            //Console.WriteLine(player.Hand[0]);
            //Console.WriteLine(player.PlayerScore);




            //Deck d = new Deck();
            //int count = 0;

            //for (int i = 0; i < d.Stock.Length; i++) {
            //    //Console.WriteLine(d.Stock[i]);
            //    if (d.Stock[i] == Deck.CardValue.None) {
            //        count++;
            //    }
            //}
            //Console.WriteLine(d.Stock.Length);
            //Console.WriteLine(count);




        }
    }
}

