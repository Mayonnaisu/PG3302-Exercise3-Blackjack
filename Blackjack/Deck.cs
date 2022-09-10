namespace Blackjack
{

    /*
    *   Deck contains:
    *       Information about all cards and its values
    *       Method to generate all cards
    */

    internal class Deck
    {
        private CardValue[] _deck = new CardValue[52];

        public Deck()
        {
            _deck = generateCards();
        }


        public enum CardValue
        {
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
        //_stock[i] = Enum.GetValues(typeof(CardValue)).Length;
        //int CardScore = (int) CardValue.Nine;

        public CardValue[] generateCards()
        {
            int start = 2;
            int addRest = 40;
            //Add: Knight, Queen, King = 10

            for (int i = 0; i < _deck.Length; i++) {
                if (start >= 12) {
                    start = 2;
                }
                if (addRest == i) {
                    _deck[i] = CardValue.Ten;
                    addRest++;
                }
                else {
                    _deck[i] = (CardValue)start++;
                }
            }
            return _deck;
        }

        public CardValue[] Stock
        {
            get
            {
                return _deck;
            }
        }

    }
}
