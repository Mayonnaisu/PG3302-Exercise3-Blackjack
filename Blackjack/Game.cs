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

        //First time
        public void InitialDealCards()
        {
            Random random = new Random();
            int RandomDeckCard;

            for (int i = 0; i < _house.Hand.Length; i++) {
                if (_house.Hand[i] != 0) {
                    Console.WriteLine("This should be empty!");
                    return;
                } else {
                    for (int j = 0; j < 2; j++) {
                        RandomDeckCard = random.Next(2, 12);
                        _house.Hand[j] = _stock[RandomDeckCard];
                        RandomDeckCard = random.Next(2, 12);
                        _player.Hand[j] = _stock[RandomDeckCard];
                    }
                }
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
                return _house.PlayerName;
            }
            set
            {
                _player.PlayerScore = +1;
            }
        }

        public Deck.CardValue[] GetPlayerHand
        {
            get
            {
                return _player.Hand;
            }
        }
        public Deck.CardValue[] GetHouseHand
        {
            get
            {
                return _house.Hand;
            }
        }


    }
}
