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


        public bool StartRound()
        {
            _game.InitialDraw();
            Console.WriteLine($"{_game.House} Initial Draw is the \"hidden hole card\" and {_game.GetFromHand(_game.GetHouse, 0)}.");

            if (_game.CheckBlackjack()) {
                return false;
            }

            //Print Initial draw + points
            Console.WriteLine(
                $"Your initial draw is {_game.GetFromHand(_game.GetPlayer, 0)} and {_game.GetFromHand(_game.GetPlayer, 1)}. " +
                $"Your current total is {_game.GetPoints(_game.GetPlayer)} \n"
                );
            return true;
        }


        //Actual game running
        public void GameActive()
        {
            while (true) {
                //Initial Draw + Check if any player has Ace.
                bool isPlaying = StartRound();

                while (isPlaying) {
                    string input = InputHitOrStay();

                    if (input == "h") {
                        _game.HitOrStay("h");
                        isPlaying = _game.CheckVictoryCondition();
                    }
                    else if (input == "s") {
                        _game.HitOrStay("s");
                        isPlaying = _game.CheckVictoryCondition();
                    }
                }
                if (!PlayAgain()) {
                    break;
                }
            }
        }

        public string InputHitOrStay()
        {
            Console.Write($"Would you like to hit or stay? (h/s)? ");
            string input = "";
            //bool choice = true;

            while (true) {
                input = Console.ReadLine().ToLower();

                if (input == "h" || input == "s") {
                    return input;
                    //choice = false;
                }
                else {
                    Console.WriteLine("Enter valid option.");
                    //choice = true;
                }
            }
            //return input;
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
