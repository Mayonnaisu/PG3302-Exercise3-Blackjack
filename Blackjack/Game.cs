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
            if (_player.UserName == UserName) return true;
            return false;
        }

        //First time
        public void InitialDraw()
        {
            Random random = new Random();
            int RandomCard;

            for (int i = 0; i < _house.Hand.Length; i++) {
                if (_house.Hand[i] != 0) {
                    Console.WriteLine("This should be empty!");
                    return;
                }
                else {
                    for (int j = 0; j < 2; j++) {
                        RandomCard = random.Next(2, 12);
                        _house.Hand[j] = _stock[RandomCard];
                        RandomCard = random.Next(2, 12);
                        _player.Hand[j] = _stock[RandomCard];
                    }
                }
            }
        }

        public int CalculateHand(User CurrentPlayer)
        {
            int points = 0;

            for (int i = 0; i < CurrentPlayer.Hand.Length; i++) {
                Console.WriteLine(CurrentPlayer.Hand[i]);
                points += (int) CurrentPlayer.Hand[i];
            }
            CurrentPlayer.UserScore = points;


            Console.WriteLine(CurrentPlayer.UserScore);

            return CurrentPlayer.UserScore;
        }

        public Deck.CardValue AddCard(string Input)
        {
            Random random = new Random();
            int RandomDeckCard = random.Next(2, 12);

            if (Input == "h") {
                int CheckDeckCount = 0;
                
                //Find how many cards are in the hand.
                for (int i = 0; i < _player.Hand.Length; i++) {
                    if ((int)_player.Hand[i] != 0) {
                        CheckDeckCount++;
                    }
                }
                _player.Hand[CheckDeckCount] = _stock[RandomDeckCard];
                return _stock[RandomDeckCard];

            }
            return 0;
            //else if (Input == "s") {
            //    //
            //}
            //return 0;
        }

            public void CheckVictoryCondition()
        {

        }




        //Properties
        //User score
        public int UserScore
        {
            get
            {
                return _player.UserScore;
            }
        }
        //User Object
        public User GetPlayer
        {
            get
            {
                return _player;
            }
        }
        public User GetHouse
        {
            get
            {
                return _house;
            }
        }
        //Username
        public string Player
        {
            get
            {
                return _player.UserName;
            }
        }
        public string House
        {
            get
            {
                return _house.UserName;
            }
        }
        //Array of cards
        public Deck.CardValue[] PlayerHand
        {
            get
            {
                return _player.Hand;
            }
        }
        public Deck.CardValue[] HouseHand
        {
            get
            {
                return _house.Hand;
            }
        }


    }
}
