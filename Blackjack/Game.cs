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
        private Player _player;
        private Deck.CardValue[] _stock = new Deck().generateStock();
        
        public Game(string UserName)
        {
            _player = new Player(UserName);
        }
        



    }


}
