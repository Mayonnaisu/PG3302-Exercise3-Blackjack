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
        //Username. Setter is not used atm.
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
        //Hand-array
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
