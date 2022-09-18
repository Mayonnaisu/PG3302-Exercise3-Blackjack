/*
 *  Contains the player and the generated deck.
 *  Check victory condition.
 *  Gets input from GameInterface through console.
 */

using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Blackjack
{
    internal class Game
    {
        private User _player;
        private User _house = new User("Dealer");
        private Cards[] _stock = new Deck().GenerateDeck();



        //Methods
        //Gets input from GameInterface (console). Sends name to User class.
        public bool NameToValidate(string userName)
        {
            _player = new User(userName);

            if (_player.UserName == userName) return true;
            return false;
        }


        //This method is run at the beginning of each game. Deals initial 2 cards to players and calculate points.
        public void InitialDraw()
        {
            int playerPoints = GetPoints(_player);
            int housePoints = GetPoints(_player);

            //ADD
            if (playerPoints == housePoints && playerPoints == 0) {
                for (int j = 0; j < 2; j++) {
                    Cards tempCard;

                    tempCard = RandomCard();
                    _player.Hand[j] = tempCard;
                    RemoveCardFromDeck(tempCard);


                    tempCard = RandomCard();
                    _house.Hand[j] = tempCard;
                    RemoveCardFromDeck(tempCard);
                }
            }
            GetPoints(_player);
            GetPoints(_house);
        }


        public bool CheckBlackjack()
        {
            if (_player.Hand.Length == 2 && _house.Hand.Length == 2) {
                if (_player.UserScore == 21 && _house.UserScore == 21) {
                    Console.WriteLine($"Its a draw! Both players scored Blackjack");
                    //
                    Console.WriteLine($"{_player.UserName}: {_player.Hand[0]} and {_player.Hand[1]}");
                    Console.WriteLine($"{_house.UserName}'s hidden hole card was: {_house.Hand[1]} ");
                    //
                    return true;
                }
            }
            return false;
        }


        public void HitOrStay(string userChoice)
        {
            Cards tempCard;
            int currentPoints;

            if (userChoice == "h") {
                tempCard = AddCard(_player);
                GetPoints(_player);
                SpecialAceCondition(_player);
                currentPoints = GetPoints(_player);

                Console.WriteLine(
                    $"You pulled {tempCard} from the deck. " +
                    $"Your current total is {currentPoints} \n"
                );

                return;
            }
            else if (userChoice == "s") {
                Console.WriteLine(
                    $"\n" +
                    $"Dealer's hole card was {GetFromHand(_house, 1)}. " +
                    $"Dealer's current total is {GetPoints(_house)}"
                );

                while (_house.UserScore < 17) {
                    tempCard = AddCard(_house);
                    GetPoints(_house);
                    SpecialAceCondition(_house);
                    currentPoints = GetPoints(_house);

                    Console.WriteLine($"Dealer pulled {tempCard} from the deck. " +
                        $"Dealer's current total is {currentPoints} \n"
                    );
                }
                return;
            }
        }


        //Method for regular win/lose condition. Ace-card condition is in a separate method, below.
        public bool CheckVictoryCondition()
        {
            if (_player.UserScore > 21) {
                Console.WriteLine(
                    $"{_player.UserName} lost! \n" +
                    $"(Your total was {_player.UserScore}. " +
                    $"{_house.UserName}'s total was {_house.UserScore}"
                    );

                return false;
            }

            else if (_house.UserScore > 21) {
                Console.WriteLine(
                    $"{_player.UserName} Wins! \n" +
                    $"(Your total was {_player.UserScore}. " +
                    $"{_house.UserName}'s total was {_house.UserScore}"
                    );

                return false;
            }

            else if (_house.UserScore >= _player.UserScore) {
                Console.WriteLine(
                    $"{_player.UserName} lost! \n" +
                    $"(Your total was {_player.UserScore}. " +
                    $"{_house.UserName}'s total was {_house.UserScore}"
                    );
                return false;
            }

            else if (_house.UserScore == _player.UserScore) {
                Console.WriteLine("Player lost");
                return false;
            }
            return true;
        }


        //This method is run after a new card is added.
        //This method checks if total points goes over 21 after a hit, if there is an ace, sets ace = 1.
        public void SpecialAceCondition(User currentPlayer)
        {
            if (currentPlayer.UserScore > 21) {                                 //Get players score. If new card -> over 21 points.

                for (int i = 0; i < currentPlayer.Hand.Length; i++) {           //Check if player has Ace/Aces (only convert the first it finds)
                    if (currentPlayer.Hand[i] == Cards.Ace) {
                        currentPlayer.Hand[i] = Cards.AceLow;
                        break;
                    }
                }
            }
        }


        //Find random card in deck and that is not None = 0.
        public Cards RandomCard()
        {
            Random random = new Random();
            int randomCard = random.Next(0, 52);

            while (_stock[randomCard] == Cards.None) {             //***************(This should not be needed. check later)****************
                randomCard = random.Next(0, 52);
            }
            return _stock[randomCard];
        }


        //Add a new card to players hand. Returns the card that was added.
        public Cards AddCard(User currentPlayer)
        {
            //Find how many cards are in the hand to know where to add the new one.
            int checkDeckIndex = 0;
            for (int i = 0; i < currentPlayer.Hand.Length; i++) {
                if ((int)currentPlayer.Hand[i] != 0) {
                    checkDeckIndex++;
                }
            }

            Cards randomCard = RandomCard();
            currentPlayer.Hand[checkDeckIndex] = randomCard;
            RemoveCardFromDeck(randomCard);
            //SpecialAceCondition(currentPlayer);

            return currentPlayer.Hand[checkDeckIndex];
        }


        //Remove Card from Deck.
        public void RemoveCardFromDeck(Cards card)
        {
            for (int i = 0; i < _stock.Length; i++) {
                if (_stock[i] == card) {
                    _stock[i] = Cards.None;            //Remove card, set it to value None = 0;
                    return;
                }
            }
        }


        //Reset both hands.
        public void ResetGameData()
        {
            _stock = new Deck().GenerateDeck();
            for (int i = 0; i < _player.Hand.Length; i++) {
                _player.Hand[i] = Cards.None;
                _house.Hand[i] = Cards.None;
            }
        }


        //Getters (mostly used by GameInterface)
        public int GetPoints(User currentPlayer)
        {
            return currentPlayer.CalculatePoints(currentPlayer);
        }

        //public int GetScore(User currentPlayer)
        //{
        //    return currentPlayer.UserScore;
        //}

        public string GetName(User currentPlayer)
        {
            return currentPlayer.UserName;
        }

        public Cards GetFromHand(User currentPlayer, int index)
        {
            return currentPlayer.Hand[index];
        }


        //Properties.
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
        public Cards[] PlayerHand
        {
            get
            {
                return _player.Hand;
            }
        }
        public Cards[] HouseHand
        {
            get
            {
                return _house.Hand;
            }
        }


    }
}
