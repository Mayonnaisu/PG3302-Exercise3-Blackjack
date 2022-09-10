/*
 *  Contains the player and the generated deck.
 *  Check victory condition.
 *  Gets input from GameInterface through console.
 */

namespace Blackjack
{
    internal class Game
    {
        private User _player;
        private User _house = new User("Dealer");
        private Deck.CardValue[] _stock = new Deck().generateStock();


        //Methods
        public bool NameToValidate(string UserName)
        {
            _player = new User(UserName);
            if (_player.PlayerName == UserName) return true;
            return false;
        }

        public void DealCards()
        {
            Random random = new Random();
            int RandomDeckCard = random.Next(2, 12);

            //First time
            if (_house.Hand.Length <= 0) {
                _house.Hand[0] = _stock[RandomDeckCard];
                _player.Hand[0] = _stock[RandomDeckCard];
            }




        }

            public void CheckVictoryCondition()
        {

        }

        public void AddCards()
        {

        }

        public void CheckPoints()
        {

        }




        //Properties
        public string Player
        {
            get
            {
                return _player.PlayerName;
            }
            set
            {
                _player.PlayerScore = +1;
            }
        }
        
        public string House
        {
            get
            {
                return _player.PlayerName;
            }
            set
            {
                _player.PlayerScore = +1;
            }
        }


    }
}
