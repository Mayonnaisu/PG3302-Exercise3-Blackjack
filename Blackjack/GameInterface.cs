/*
 *  Interface class - Console interaction
 */

namespace Blackjack
{
    internal class GameInterface
    {
        private Game game = new Game();
        private string? _userName;


        //Methods
        public void Init()
        {
            Console.WriteLine($"Enter your name: (Only letters and numbers. Max 20 characters");
            EnterUserName();
            GameActive();
        }

        public void EnterUserName()
        {
            _userName = Console.ReadLine();

            while (!game.NameToValidate(_userName)) {
                Console.WriteLine("Invalid name. Try again: ");
                _userName = Console.ReadLine();
            }
            game.NameToValidate(_userName);
            Console.WriteLine($"Welcome {game.Player}");
        }

        public void GameActive()
        {
            bool IsPlaying = true;
            
            while (IsPlaying) {
                //First deal 2 cards - first to House then to Player
                game.InitialDealCards();
                Console.WriteLine($"{game.House} Initial Draw is the \"hidden hole card\" and Ten.");

                Console.WriteLine($"Card: {game.GetHouseHand[0]}");
                Console.WriteLine($"Card: {game.GetHouseHand[1]}");
                Console.WriteLine($"Card: {game.GetPlayerHand[0]}");
                Console.WriteLine($"Card: {game.GetPlayerHand[1]}");


                IsPlaying = false;




            }
        }





        



    }
}
