﻿/*
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
        private Cards[] _stock = new Deck().GenerateDeck();



        //Methods
        //Gets input from GameInterface (console). Sends name to User class.
        public bool NameToValidate(string userName)
        {
            _player = new User(userName);

            if (_player.UserName == userName) return true;
            return false;
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


        //Calculate points for player
        public int GetPoints(User currentPlayer)
        {
            return currentPlayer.CalculatePoints(currentPlayer);
        }


        //Add a new card to players hand. Returns the card that was added.
        public Cards AddCard(User currentPlayer)
        {
            Cards tempCard = RandomCard();
            int checkDeckCount = 0;

            //Find how many cards are in the hand to know where to add the new one.
            for (int i = 0; i < currentPlayer.Hand.Length; i++) {
                if ((int)_player.Hand[i] != 0) {
                    checkDeckCount++;
                }
            }
            currentPlayer.Hand[checkDeckCount] = tempCard;
            RemoveCardFromDeck(tempCard);

            return currentPlayer.Hand[checkDeckCount];
        }


        //Method for regular win/lose condition. Ace-card condition is in a separate method, below.
        public bool CheckVictoryCondition(string pick)
        {
            //Player card
            if (pick == "h") {
                if (_player.UserScore > 21) {
                    Console.WriteLine(
                        $"Player lost! (Your total was {_player.UserScore}. " +
                        $"Dealer's total was {_house.UserScore}"
                        );

                    return false;
                }
            }

            //House card
            if (pick == "s") {
                while (true) {
                    if (_house.UserScore < 17) {       //if points goes beyond 17, dont draw.
                        AddCard(_house);
                        GetPoints(_house);
                    }

                    if (GetPoints(_house) > 21) {
                        Console.WriteLine(
                            $"Player Wins! (Your total was {_player.UserScore}. " +
                            $"Dealer's total was {_house.UserScore}"
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
