// See https://aka.ms/new-console-template for more information

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Tobias");
            player1.printPlayerName();
            player1.printPlayerScore();

            Deck deck = new ();
            deck.generateCards();

            //foreach (Game.CardValue i in g.Stock) {
            //    Console.WriteLine(i.ToString());
            //}
        }
    }
}

