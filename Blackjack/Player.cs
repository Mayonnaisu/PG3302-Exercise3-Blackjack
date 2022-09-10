using System.Text.RegularExpressions;

namespace Blackjack
{
    internal class Player
    {

        private int _playerScore = 0;
        private string _playerName = "";

        public Player(string Name)
        {
            PlayerName = Name;
        }


        //Methods
        public void printPlayerName()
        {
            Console.WriteLine(PlayerName);
        }

        public void printPlayerScore()
        {
            Console.WriteLine(_playerScore);
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
                if ( (value.Length < 1 && value.Length > 50) || value == null) {
                    _playerName = "blank";
                } else {
                    _playerName = value;
                }
            }
        }
    }




                //}
            //set
            //{
            //    string pattern = @"([0-9][az][A-Z]";
            //    Regex regex = new Regex(pattern);

            //    if (regex.Matches(value, _playerName)) {
            //        _playerName = value;
            //    }
            //    else {
            //        _playerName = "empty";
            //    }
            //}

}
