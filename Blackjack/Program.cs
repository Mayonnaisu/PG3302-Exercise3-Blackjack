// See https://aka.ms/new-console-template for more information

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInterface gi = new GameInterface();
            gi.Init();


            //Player p = new Player("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            //Console.WriteLine(p.PlayerName);


            //Player player1 = new Player("Tobias");
            //player1.PrintPlayerName();
            //player1.PrintPlayerScore();

            //Deck deck = new ();
            //deck.generateStock();

            //foreach (Game.CardValue i in g.Stock) {
            //    Console.WriteLine(i.ToString());
            //}
        }
    }
}

