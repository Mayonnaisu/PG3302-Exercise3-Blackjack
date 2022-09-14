/*
*   Deck contains:
*   Enum with the possible values.
*   Method to generate all cards and to shuffle them.
*   
*   
*   //Note to self
*   //_stock[i] = Enum.GetValues(typeof(CardValue)).Length;
*   //int CardScore = (int) CardValue.Nine;
*/

using System.Security.Cryptography;

namespace Blackjack
{
    internal class Deck
    {
        private CardValue[] _stock = new CardValue[52];

        public Deck()
        {
            _stock = GenerateStock();
            ShuffleStock();
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
            Ace = 11
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


        /*
         * https://www.youtube.com/watch?v=EvPVtKryspY&ab_channel=FallenWorldStudios
         */
        public void ShuffleStock()
        {
            int lastIndex = _stock.Length - 1;
            Random random = new Random();

            while (lastIndex > 0) {
                CardValue tempValue = _stock[lastIndex];

                int randomIndex = random.Next(0, lastIndex);
                _stock[lastIndex] = _stock[randomIndex];
                _stock[randomIndex] = tempValue;
                lastIndex--;
            }
        }


        //Properties
        public CardValue[] Stock
        {
            get
            {
                return _stock;
            }
        }

    }
}
