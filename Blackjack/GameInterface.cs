/*
 *  Interface class - Console interaction
 */

namespace Blackjack
{
    internal class GameInterface
    {
        private Game _game = new Game();
        private string? _userName;
        



        //Methods
        public void Init()
        {
            Console.Write($"Enter your name (Only letters and numbers. Max 20 characters): ");
            EnterUserName();
            GameActive();
        }


        public void EnterUserName()
        {
            _userName = Console.ReadLine();

            //Validate username! Sends the input to Game and then calls the Property in User class to set the name if valid.
            while (!_game.NameToValidate(_userName)) {
                Console.Write("Invalid name. Try again: ");
                _userName = Console.ReadLine();
            }
            _game.NameToValidate(_userName);
            Console.WriteLine($"Welcome {_game.Player} \n");
        }


        //Actual game running
        public void GameActive()
        {
            while(true) {

                //Initial Draw + Check if any player has Ace.
                bool isPlaying = StartRound();

                while (isPlaying) {
                    Cards tempCard = new();
                    string Pick = HitOrStay();

                    if (Pick == "h") {
                        tempCard = _game.AddCard(_game.GetPlayer);
                        _game.GetPoints(_game.GetPlayer);
                        _game.SpecialAceCondition(_game.GetPlayer);

                        Console.WriteLine(
                            $"You pulled {tempCard} from the deck. " +
                            $"Your current total is {_game.GetScore(_game.GetPlayer)} \n"
                            );

                        isPlaying = _game.CheckVictoryCondition(Pick);
                    }
                    //DRAR BARA ETT KORT OAVASETT OM POÄNG E MINDRE ÄN 17.
                    else if (Pick == "s") {
                        Console.WriteLine(
                            $"\n" +
                            $"Dealer's hole card was {_game.GetFromHand(_game.GetHouse, 1)}. " +
                            $"Dealer's current total is {_game.GetScore(_game.GetHouse)}"
                            );

                        tempCard = _game.AddCard(_game.GetHouse);
                        _game.GetPoints(_game.GetHouse);
                        _game.SpecialAceCondition(_game.GetHouse);

                        Console.WriteLine($"Dealer pulled {tempCard} from the deck. " +
                            $"Dealer's current total is {_game.GetPoints(_game.GetHouse)} \n"
                            );

                        isPlaying = _game.CheckVictoryCondition(Pick);
                    }


                }
                if (!PlayAgain()) {
                    break;
                }
            }
            
            
        }


        public bool StartRound()
        {
            _game.InitialDraw();
            Console.WriteLine($"{_game.House} Initial Draw is the \"hidden hole card\" and {_game.GetFromHand(_game.GetHouse, 0)}.");


            if (_game.GetScore(_game.GetPlayer) == 21) {
                Console.WriteLine($"{_game.GetName(_game.GetPlayer)} has blackjack and wins!");
                return false;
            }
            else if (_game.GetScore(_game.GetHouse) == 21) {
                Console.WriteLine($"{_game.GetName(_game.GetHouse)}'s hidden hole card was: {_game.GetFromHand(_game.GetHouse, 1)} has blackjack and wins!");
                return false;
            }

            //Print Initial draw + points
            Console.WriteLine(
                $"Your initial draw is {_game.GetFromHand(_game.GetPlayer, 0)} and {_game.GetFromHand(_game.GetPlayer, 1)}. " +
                $"Your current total is {_game.GetPoints(_game.GetPlayer)} \n"
                );
            return true;
        }


        public string HitOrStay()
        {
            Console.Write($"Would you like to hit or stay? (h/s)? ");
            string input = "";

            while (true) {
                input = Console.ReadLine();

                if (input.ToLower() == "h" || input.ToLower() == "s") {
                    return input.ToLower();
                }
                else {
                    Console.WriteLine("Enter valid option.");
                }
            }
        }


        public bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            string input = "";

            while (true) {
                input = Console.ReadLine();

                if (input.ToLower() == "y") {
                    _game.ResetGameData();
                    Console.Clear();
                    return true;
                }
                else if (input.ToLower() == "n") {
                    return false;
                }
                else {
                    Console.WriteLine("Enter valid option.");
                }
            }
        }

    }
}
