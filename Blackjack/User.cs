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
        private string _userName = "";
        private Deck.CardValue[] _hand = new Deck.CardValue[11];
        private int _userScore = 0;

        public User(string name)
        {
            UserName = name;
        }


        //Methods
        public void PrintUserName()
        {
            Console.WriteLine(UserName);
        }

        public void PrintPlayerScore()
        {
            Console.WriteLine(UserScore);
        }

        //Bug - when only pressing enter, it passes on 2nd try.
        public bool ValidateUserName(string userName)
        {
            if (userName.Length <= 0 || userName.Length > 20 || userName == null) {
                return false;
            }
            if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9]+$")) {
                return false;
            }
            return true;
        }




        //Properties
        //Username
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (ValidateUserName(value)) {
                    _userName = value;
                }
            }
        }
        //User score
        public int UserScore
        {
            get
            {
                return _userScore;
            }
            set
            {
                _userScore = value;
            }
        }
        //User hand
        public Deck.CardValue[] Hand
        {
            get
            {
                return _hand;
            }
            set
            {
                //Add cards to hand
            }
        }




    }
}
