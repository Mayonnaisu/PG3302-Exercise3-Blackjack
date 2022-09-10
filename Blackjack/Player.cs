using System.Text.RegularExpressions;

namespace Blackjack
{
    internal class Player
    {
        private string _playerName = "";
        private int _playerScore = 0;
        private Deck.CardValue[] _PlayerHand = new Deck.CardValue[11];

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
