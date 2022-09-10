using System.Text.RegularExpressions;

namespace Blackjack
{
    internal class Player
    {
        private string _playerName = "";
        private int _playerScore = 0;
        private Deck.CardValue[] g = new Deck.CardValue[11];

        public Player(string Name)
        {
            PlayerName = Name;
        }


        //Methods
        public void PrintPlayerName()
        {
            Console.WriteLine(PlayerName);
        }

        public void PrintPlayerScore()
        {
            Console.WriteLine(_playerScore);
        }

        public bool ValidateUserName(string UserName)
        {
            if ((UserName.Length < 0 && UserName.Length > 20) || UserName == null) {
                return false;
            }

            string pattern = "[0-9a-zA-Z ]*";

            if (!Regex.Match(UserName, pattern).Success) {
                Console.WriteLine("Failed!");
                return false;
            }
            Console.WriteLine("Player Class - ");
            return true;
        }


        //Properties
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }
    }

}
