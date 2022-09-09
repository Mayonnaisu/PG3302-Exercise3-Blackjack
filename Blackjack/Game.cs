using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        private CardValue[] _stock = new CardValue[52];
        private Player _player;

        //Knight, Queen, King = 10.
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

        //Generera fram 52 kort.
        public void generateCards()
        {
            int start = 2;
            //Add: Knight, Queen, King = 10
            int j = 0;

            for (int i = 0; i < _stock.Length; i++) {
                //_stock[i] = Enum.GetValues(typeof(CardValue)).Length;
                _stock[i] = (CardValue)start++;
                
                if (start >= 12) {
                    start = 2;
                }
                //int CardScore = (int) CardValue.Nine;
            }

        
        }

        /*
         *Array values = Enum.GetValues(typeof(Bar));
        Random random = new Random();
        Bar randomBar = (Bar)values.GetValue(random.Next(values.Length)); 
        */




        /*
         *
         *  2 kort per person
            2-10 har kortets värde
            11-13 har värdet 10
            Ace räkna som 11. Men om ace > 21 så blir ace = 1. Räknas för flera ace.
         */




        public CardValue[] Stock
        {
            get
            {
                return _stock;
            }
            set
            {

            }
        }

    }
}
