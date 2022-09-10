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
            Console.WriteLine($"Welcome {_game.Player}");
        }


        public void GameActive()
        {
            Deck.CardValue TempCard = new();
            bool IsPlaying = true;
            //First deal 2 cards - first to House then to Player
            _game.InitialDraw();
            Console.WriteLine($"{_game.House} Initial Draw is the \"hidden hole card\" and {_game.HouseHand[0]}.");

            //Count initial points for both.
            _game.CalculateHand(_game.GetPlayer);
            _game.CalculateHand(_game.GetHouse);

            Console.WriteLine(
                $"Your initial draw is {_game.PlayerHand[0]} and {_game.PlayerHand[1]}." +
                $"Your current total is {_game.UserScore}"
                );

            while (IsPlaying) {
                //Deal another card?
                string Pick = HitOrStay();
                
                //Depending on pick
                if (Pick == "h") {
                    TempCard = _game.AddCard(Pick);
                    Console.WriteLine($"You pulled {TempCard} from the deck. Your current total is {_game.CalculateHand(_game.GetPlayer)}");
                    _game.CheckVictoryCondition();
                }
                else if (Pick == "s") {
                    //Stay? Check what dealer will do.
                }



            }
                IsPlaying = false;
        }


        public string HitOrStay()
        {
            Console.Write($"Would you like to hit or stay? (h/s)? ");
            bool Choice = true;
            string Input = "";

            while (Choice) {
                Input = Console.ReadLine();
                if (Input.ToLower() == "h" || Input.ToLower() == "s") {
                    Console.WriteLine(Input);
                    Choice = false;
                }
                else {
                    Console.WriteLine("Enter valid option.");
                    Choice = true;
                }
            }
            return Input;
        }





    }
}
