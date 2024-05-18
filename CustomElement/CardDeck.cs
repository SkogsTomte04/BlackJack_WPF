using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomElement
{
    class CardDeck
    {
        public CardDeck()
        {
            cards = createDeck();
            shuffleDeck();
        }

        public List<Card> createDeck()
        {
            List<Card> newdeck = new List<Card>();
            Card.CardSuits suits = new Card.CardSuits();
            string[] cardvalues = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (Card.CardSuits cardSuits in Enum.GetValues<Card.CardSuits>())
            {
                suits = cardSuits;
                foreach (string value in cardvalues)
                {
                    Card newcard = new Card();
                    newcard.CardValue= value;
                    newcard.cardSuits = suits;
                    newdeck.Add(newcard);
                }
            }
            return newdeck;
        }


        public void shuffleDeck()
        {
            List<Card> c = cards;
            var rng = new Random();
            int n = c.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                Card temp = c[n];
                c[n] = c[k];
                c[k] = temp;
            }
            cards = c;

        }

        public Card drawcard(bool isHidden) // isHidden determins if card is returned facing up or down. 
        {
            Card card = cards[0];
            card.Hidden = isHidden;
            cards.RemoveAt(0);
            return card;
        }

        public int cardsleft()
        {
            return cards.Count;
        }

        public List<Card> GetCardsByType(Card.CardSuits suit)
        {
            List<Card> cardbytype = new List<Card>();
            foreach(Card card in cards)
            {
                if(card.cardSuits == suit)
                {
                    cardbytype.Add(card);
                }
            }
            return cardbytype;
        }

        public void print()
        {
            /*foreach (string card in cards)
            {
                Console.WriteLine(card);
            }*/
        }


        private List<Card> cards;
    }
}
