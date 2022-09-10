//using static Blackjack.Deck;

namespace Blackjack
{
    /*
     * Contains the player and the generated deck.
     * Check victory condition.
     * Gets input from GameInterface through console.
     * 
     * 
     */

    internal class Game
    {
        private Player _player = new("");
        private Deck.CardValue[] _stock = new Deck().generateStock();
        
 
        public bool CheckUserName(string UserName)
        {
            if (!_player.ValidateUserName("asdasd")) {
                return false;
            }
            _player = new Player(UserName);
            Console.WriteLine("Games class - ");
            return true;
        }

        /*
         * Game tar emot ett namn
         * Se om namnet är OK.
         *  OK - fortsätt.
         *  Annars be GameInterface om nytt namn.
         */


    }


}
