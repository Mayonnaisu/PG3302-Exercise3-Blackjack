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
        public Cards[] Hand { get; } = new Cards[11];    //refactor enum in Deck
        public int UserScore {get; set;} = 0;

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


        public int CalculatePoints(User currentPlayer)
        {
            int points = 0;

            for (int i = 0; i < currentPlayer.Hand.Length; i++) {
                points += (int)currentPlayer.Hand[i];
            }
            currentPlayer.UserScore = points;

            //Console.WriteLine(currentPlayer.UserScore);
            return currentPlayer.UserScore;
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

    }
}
