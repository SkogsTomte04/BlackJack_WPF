using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomElement
{
    class BlackJack
    {
        public BlackJack()
        {
            Card[] h = { deck.drawcard(true), deck.drawcard(false) };
            Card[] p = { deck.drawcard(false), deck.drawcard(false) };

            h[0].Name = "Hidden"; // assigns name "Hidden" to dealers upside down card so i can find it later

            houseHand.AddRange(h);
            playerHand.AddRange(p);
        }

        public void PlayerFold()
        {
            playerfold= true;
        }
        public void HouseFold()
        {
            housefold = true;
        }
        public string getresult()
        {
            int p = handValue(playerHand), h = handValue(houseHand);

            if (p > h && p <= 21)
            {
                pot *= 2;
                return $"PLAYER WON: {pot}";
                
            }
            else if (p == h)
            {
                return "Draw!!!";
            }
            else
            {
                pot /= 2;
                if (p > 21)
                {
                    return "Player hand FAT";
                }
                return $"Player Lost: {pot}";
                
            };
            
        }
        public Card houseTurn()
        {
            if (handValue(houseHand) < 16)
            {
                Card card = deck.drawcard(false);
                houseHand.Add(card);
                return card;
            }
            else
            {
                housefold = true;
                return null;
            }
        }
        public bool checkGameState()
        {
            if (handValue(playerHand) > 21)
            {
                playerfold = true;
            }
            if (playerfold == true && housefold == true)
            {
                Console.WriteLine("Both players have folded!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public Card hit()
        {
            Card newcard = deck.drawcard(false);
            playerHand.Add(newcard);
            return newcard;
        }


        public int cardValue(Card card)
        {
            
            string[] numerals = { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            for (int i = 0; i < numerals.Length; i++)
            {
                if (card.CardValue == numerals[i])
                {
                    return i + 2;
                }
            }
            if (card.CardValue == "A")
            {
                return 11;
            }

            return 10;
        }
        public int handValue(List<Card> cards)
        {
            int finalvalue = 0;
            foreach (Card card in cards)
            {
                finalvalue += cardValue(card);
            }
            return finalvalue;
        }

        public List<Card> GetPlayerHand()
        {
            return playerHand;
        }
        public List<Card> GetHouseHand()
        {
            return houseHand;
        }


        private CardDeck deck = new CardDeck();
        private int pot = 200;
        private List<Card> houseHand = new List<Card>(), playerHand = new List<Card>();
        private bool playerfold = false, housefold = false;
    }
}
