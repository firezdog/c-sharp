using System;
using System.Collections.Generic;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player("Alex");
            player.draw(deck).draw(deck);
            object trash = player.discard(1);
        }
    }
    class Player
    {
        string name;
        List<Card> hand = new List<Card>();
        public Player(string name){
            this.name = name;
        }
        public Player draw(Deck deck){
            deck.shuffle();
            hand.Add(deck.deal());
            return this;
        }
        public object discard(int index){
            try 
            { 
                Card card = hand[index];
                hand.Remove(card);
                return card;
            }
            catch { return null; };
        }
    }
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public Dictionary<int, string> suits = new Dictionary<int,string>(){
            {1,"heart"},
            {2,"spade"},
            {3,"diamond"},
            {4,"club"}
        };
        public Dictionary<int, string> values = new Dictionary<int,string>(){
            {1,"ace"},
            {2,"two"},
            {3,"three"},
            {4,"four"},
            {5,"five"},
            {6,"six"},
            {7,"seven"},
            {8,"eight"},
            {9,"nine"},
            {10,"ten"},
            {11,"jack"},
            {12,"queen"},
            {13,"king"}
        };
        public Deck() {
            for (int suit = 0; suit < 4; suit++) {
                for (int value = 0; value < 13; value++) {
                    cards.Add(new Card(values[value+1], suits[suit+1], value+1));
                }
            }
        }
        public Card deal(){
            Card card = cards[cards.Count-1];
            cards.Remove(card);
            return card;
        }
        public Deck reset() {
            cards = new List<Card>();
            for (int suit = 0; suit < 4; suit++) {
                for (int value = 0; value < 13; value++) {
                    cards.Add(new Card(values[value+1], suits[suit+1], value+1));
                }
            }
            return this;
        }
        public Deck shuffle() {
            Random ayn = new Random();
            for (int i = 0; i < cards.Count; i++) {
                int swapIndex = ayn.Next(0,cards.Count);
                Card temp = cards[i];
                cards[i] = cards[swapIndex];
                cards[swapIndex] = temp;
            }
            return this;
        }
    }

    class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string stringVal, string suit, int val) {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
    }
}
