/*
*   Deck contains:
*   Information about all cards and its values
*   Method to generate all cards
*   
*   
*   //_stock[i] = Enum.GetValues(typeof(CardValue)).Length;
*   //int CardScore = (int) CardValue.Nine;
*/

namespace Blackjack
{
    internal class Deck
    {
        private CardValue[] _stock = new CardValue[52];

        public Deck()
        {
            _stock = GenerateStock();
        }

        //Added a None = 0 value in this enum to be able to reset game.
        //AceLow = 1 for the special rule.
        public enum CardValue
        {
            None = 0,
            AceLow = 1,
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            AceHigh = 11
        };


        //Methods
        public CardValue[] GenerateStock()
        {
            int start = 2;
            int addRest = 40;   //Add: Knight, Queen, King = 10

            for (int i = 0; i < _stock.Length; i++) {
                if (start >= 12) {
                    start = 2;
                }
                if (addRest == i) {
                    _stock[i] = CardValue.Ten;
                    addRest++;
                }
                else {
                    _stock[i] = (CardValue)start++;
                }
            }
            return _stock;
        }


        //Properties
        public CardValue[] Stock { get; }

    }
}
