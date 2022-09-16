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
                            $"Your current total is {_game.GetPlayer.UserScore} \n"
                            );

                        isPlaying = _game.CheckVictoryCondition(Pick);
                    }
                    //DRAR BARA ETT KORT OAVASETT OM POÄNG E MINDRE ÄN 17.
                    else if (Pick == "s") {
                        Console.WriteLine(
                            $"\n" +
                            $"Dealer's hole card was {_game.HouseHand[1]}. " +
                            $"Dealer's current total is {_game.GetHouse.UserScore}"             //LAYERING!! Fixa direkt access.
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
            Console.WriteLine($"{_game.House} Initial Draw is the \"hidden hole card\" and {_game.HouseHand[0]}.");


            if (_game.GetPlayer.UserScore == 21) {
                Console.WriteLine($"{_game.GetPlayer.UserName} has blackjack and wins!");           //LAYERING!! Fixa direkt access.
                return false;
            }
            else if (_game.GetHouse.UserScore == 21) {
                Console.WriteLine($"{_game.GetHouse.UserName} has blackjack and wins!");
                return false;
            }

            //Print Initial draw + points
            Console.WriteLine(
                $"Your initial draw is {_game.PlayerHand[0]} and {_game.PlayerHand[1]}. " +
                $"Your current total is {_game.GetPlayer.UserScore} \n"
                );
            return true;
        }


        public string HitOrStay()
        {
            Console.Write($"Would you like to hit or stay? (h/s)? ");
            bool choice = true;
            string input = "";

            while (choice) {
                input = Console.ReadLine();

                if (input.ToLower() == "h" || input.ToLower() == "s") {
                    choice = false;
                }
                else {
                    Console.WriteLine("Enter valid option.");
                    choice = true;
                }
            }
            return input;
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
