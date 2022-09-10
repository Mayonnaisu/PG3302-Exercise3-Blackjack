using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Blackjack
{
    /*
     * Interface, interaction with console.
     * 
     */

    internal class GameInterface
    {
        private Game? game;
        private string? _userName;


        public void Init()
        {
            Console.WriteLine("Welcome to Blackjack beepboop");
            CreatePlayerName();
        }


        public void CreatePlayerName()
        {
            Console.WriteLine($"Enter your name: (Only letters and numbers. Max 20 characters");
            _userName = Console.ReadLine();

            //Check if username is valid. If not -> loop until OK
            while (_userName == null || !ValidateUserName(_userName)) {
                Console.WriteLine("Invalid name. Try again: ");
                _userName = Console.ReadLine();
            }
            game = new Game(_userName);
            Console.WriteLine($"Welcome {game.Player}");

        }

        public bool ValidateUserName(string UserName)
        {
            if ((UserName.Length < 0 && UserName.Length > 20) || UserName == null) {
                return false;
            }
            if (!Regex.IsMatch(UserName, @"^[a-zA-Z0-9]+$")) {
                return false;
            }
            return true;
        }


    }






}
