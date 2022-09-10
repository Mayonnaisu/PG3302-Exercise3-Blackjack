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
            string pattern = "[0-9a-zA-Z ]*";

            if (Regex.Match(UserName, pattern).Success) {
                Console.WriteLine("Success!");
                return true;
            } else {
                Console.WriteLine("Fail!");

                return false;
            }
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
                if ((value.Length >= 1 && value.Length <= 20) || value != null && ValidateUserName(value)) {
                    if (ValidateUserName(value)) {
                        _playerName = value;
                    }
                } 
            }
        }
    }

}
