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
        public Cards[] CardDeck { get; set; } = new Cards[52];

        public Deck()
        {
            CardDeck = GenerateDeck();
            ShuffleStock();
        }


        //Methods
        public Cards[] GenerateDeck()
        {
            int start = 2;
            int addRest = 40;   //Add: Knight, Queen, King = 10

            for (int i = 0; i < CardDeck.Length; i++) {
                if (start >= 12) {
                    start = 2;
                }
                if (addRest == i) {
                    CardDeck[i] = Cards.Ten;
                    addRest++;
                }
                else {
                    CardDeck[i] = (Cards)start++;
                }
            }
            return CardDeck;
        }


        /* Manual sort
         * https://www.youtube.com/watch?v=EvPVtKryspY&ab_channel=FallenWorldStudios
         */
        public void ShuffleStock()
        {
            Random random = new Random();
            CardDeck = CardDeck.OrderBy(x => random.Next()).ToArray(); 
        }
    }
}
