/*
 *  Interface class - Console interaction
 */

using System.Security.Cryptography.X509Certificates;

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

            while (!_game.NameToValidate(_userName)) {
                Console.Write("Invalid name. Try again: ");
                _userName = Console.ReadLine();
            }
            _game.NameToValidate(_userName);
            Console.WriteLine($"Welcome {_game.Player} \n");
        }


        public void GameActive()
        {
            bool isPlaying = true;

            //First deal 2 cards - first to House then to Player
            isPlaying = _game.InitialDraw();
            Console.WriteLine($"{_game.House} Initial Draw is the \"hidden hole card\" and {_game.HouseHand[0]}.");

            //Print Initial draw + points
            Console.WriteLine(
                $"Your initial draw is {_game.PlayerHand[0]} and {_game.PlayerHand[1]}." +
                $"Your current total is {_game.UserScore} \n"
                );


            while (isPlaying) {
                Deck.CardValue tempCard = new();

                //Deal another card?
                string Pick = HitOrStay();

                if (Pick == "h") {
                    tempCard = _game.AddCard(_game.GetPlayer);
                    Console.WriteLine(
                        $"You pulled {tempCard} from the deck. " +
                        $"Your current total is {_game.CalculatePoints(_game.GetPlayer)} \n"
                        );

                    isPlaying = _game.CheckVictoryCondition(Pick);

                }
                else if (Pick == "s") {
                    Console.WriteLine(
                        $"\n" +
                        $"Dealer's hole card was {_game.HouseHand[1]}. " +
                        $"Dealer's current total is {_game.CalculatePoints(_game.GetHouse)}"
                        );

                    tempCard = _game.AddCard(_game.GetHouse);
                    Console.WriteLine($"Dealer pulled {tempCard} from the deck. " +
                        $"Dealer's current total is {_game.CalculatePoints(_game.GetHouse)} \n"
                        );

                    isPlaying = _game.CheckVictoryCondition(Pick);
                }
            }
            PlayAgain();
        }

        public void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            bool choice = true;
            string input = "";

            while (choice) {
                input = Console.ReadLine();

                if (input.ToLower() == "y") {
                    _game.ResetGameData();
                    GameActive();
                    break;
                }
                else if (input.ToLower() == "n") {
                    choice = false;
                    break;
                }
                else {
                    Console.WriteLine("Enter valid option.");
                    choice = true;
                }
            }
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





    }
}
