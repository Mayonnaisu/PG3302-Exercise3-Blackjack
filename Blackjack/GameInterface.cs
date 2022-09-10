using System;

namespace Blackjack
{
    /*
     * Interface, interaction with console.
     * 
     */

    internal class GameInterface
    {
        private string? _userName;

        public void Init()
        {
            Console.WriteLine("Welcome to Blackjack beepboop");
            CreatePlayerName();
        }


        public void CreatePlayerName()
        {
            Game game = new Game();

            Console.WriteLine($"Enter your name: (Only letters and numbers. Max 20 characters");
            _userName = Console.ReadLine();

            while (!game.CheckUserName(_userName)) {
                Console.WriteLine("Invalid name! Please try again.");
                _userName = Console.ReadLine();
            }

            Console.WriteLine($"GameInterface Class - Welcome {_userName}");






            /*
             * Ta emot username
             * Skicka till Game
             * 
             * Game ska validera namnet
             *  Om OK - fortsätt
             *  OM NEJ - skriv in nytt namn här
             * 
             */

        }



    }


}
