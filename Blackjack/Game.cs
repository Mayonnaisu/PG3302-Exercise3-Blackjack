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
        private Deck.CardValue[] _stock = new Deck().GenerateStock();


        //Methods
        public bool NameToValidate(string userName)
        {
            _player = new User(userName);
            if (_player.UserName == userName) return true;
            return false;
        }

        //First time -> Draw 2 cards, calculate points and check win condition.
        //the variabel isPlaying (bool) from GameInterface calls this method.
        public bool InitialDraw()
        {
            Random random = new Random();
            int randomCard;

            int playerPoints = CalculatePoints(_player);
            int housePoints = CalculatePoints(_player);

            //ADD
            if (playerPoints == housePoints && playerPoints == 0) {
                for (int j = 0; j < 2; j++) {
                    randomCard = random.Next(2, 12);
                    _house.Hand[j] = _stock[randomCard];
                    RemoveCardFromDeck(_stock[randomCard]);
                    randomCard = random.Next(2, 12);
                    _player.Hand[j] = _stock[randomCard];
                    RemoveCardFromDeck(_stock[randomCard]);
                }
            }
            else {
                Console.WriteLine("Should be empty!!!");
            }

            //CALC
            CalculatePoints(_player);
            CalculatePoints(_house);

            //If initial deal of 2 cards gives 21 = Blackjack
            if (_player.UserScore == 21) {
                Console.WriteLine($"{_player.UserName} has blackjack and wins!");
                return false;
            }
            else if (_house.UserScore == 21) {
                Console.WriteLine($"{_house.UserName} has blackjack and wins!");
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

        //Add a new card to players hand. Returns the card that was added.
        public Deck.CardValue AddCard(User currentPlayer)
        {
            Random random = new Random();
            int randomCard = random.Next(2, 12);
            int checkDeckCount = 0;

            //Find how many cards are in the hand.
            for (int i = 0; i < currentPlayer.Hand.Length; i++) {
                if ((int)_player.Hand[i] != 0) {
                    checkDeckCount++;
                }
            }
            currentPlayer.Hand[checkDeckCount] = _stock[randomCard];
            RemoveCardFromDeck(_stock[randomCard]);

            return _stock[randomCard];
        }

        //Remove Card from Deck when taken
        public void RemoveCardFromDeck(Deck.CardValue card)
        {
            //Få in kortet som lades till.
            //Ta bort kortet från _deck objekt.

            for (int i = 0; i < _stock.Length; i++) {
                if (_stock[i] == card) {
                    _stock[i] = Deck.CardValue.None;            //Remove card, set it to value None = 0;
                    return;
                }
            }
        }

        public bool CheckVictoryCondition(string pick)
        {
            if (pick == "h") {
                if (_player.UserScore > 21) {
                    Console.WriteLine(
                        $"Player lost! (Your total was {_player.UserScore}. " +
                        $"Dealer's total was {_house.UserName}"
                        );
                    return false;
                }
            }

            if (pick == "s") {
                while (true) {
                    if (_house.UserScore <= 17) {
                        AddCard(_house);
                        CalculatePoints(_house);
                    }

                    if (CalculatePoints(_house) > 21) {
                        Console.WriteLine(
                            $"Player Wins! (Your total was {_player.UserScore}. " +
                            $"Dealer's total was {_house.UserName}"
                            );
                        return false;
                    }

                    if (_house.UserScore >= _player.UserScore) {
                        Console.WriteLine(
                            $"Player lost! (Your total was {_player.UserScore}. " +
                            $"Dealer's total was {_house.UserScore}"
                            );
                        return false;
                    }
                }
            }
            //Afterwards add special rule for ACE if score > 21
            return true;
        }

        //Reset both hands.
        public void ResetGameData()
        {
            _stock = new Deck().GenerateStock();
            for (int i = 0; i < _player.Hand.Length; i++) {
                _player.Hand[i] = Deck.CardValue.None;
                _house.Hand[i] = Deck.CardValue.None;
            }
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
