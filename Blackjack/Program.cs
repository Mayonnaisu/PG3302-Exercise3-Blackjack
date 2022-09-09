// See https://aka.ms/new-console-template for more information

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Hehe");
            Console.WriteLine($"Name: {player1.PlayerName}");


            Game g = new ();
            g.generateCards();

            foreach (Game.CardValue i in g.Stock) {
                Console.WriteLine(i.ToString());
            }
        }
    }
}

