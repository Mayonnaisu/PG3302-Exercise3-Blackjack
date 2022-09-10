using System.Text.RegularExpressions;

/*
 *  Class contains Player information.
 *  Print Player information method.
 *  Validate name method.
 */

namespace Blackjack
{
    internal class User
    {
        private string _playerName;
        private int _playerScore = 0;
        private Deck.CardValue[] _hand = new Deck.CardValue[11];

        public User(string Name)
        {
            if (ValidateUserName(Name)) {
                PlayerName = Name;
            }
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

        //Bug - when only pressing enter, it passes on 2nd try.
        public bool ValidateUserName(string UserName)
        {
            if (UserName.Length <= 0 || UserName.Length > 20 || UserName == null) {
                return false;
            }
            if (!Regex.IsMatch(UserName, @"^[a-zA-Z0-9]+$")) {
                return false;
            }
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

        public int PlayerScore { get; set; }

        public Deck.CardValue[] Hand { get; set; }
        //public Deck.CardValue[] Hand
        //{
        //    get
        //    {
        //        return Hand;
        //    }
        //}


    }
}
