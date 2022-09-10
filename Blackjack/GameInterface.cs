namespace Blackjack
{
    /*
     * Interface, interaction with console.
     * 
     */

    internal class GameInterface
    {
        private string? _userName;


        public void init()
        {
            menu();
            CreatePlayerName();
        }

        public void menu()
        {
            Console.WriteLine("Welcome to Blackjack beepboop");


        }


        public void CreatePlayerName()
        {
            bool ValidName = false;

            while (!ValidName) {
                Console.WriteLine($"Enter your name: (Only letters and numbers. Max 20 characters");
                _userName = Console.ReadLine();

                Game game = new Game(_userName);
                Console.WriteLine($"Welcome {_userName}");



            }

        }



    }


}
