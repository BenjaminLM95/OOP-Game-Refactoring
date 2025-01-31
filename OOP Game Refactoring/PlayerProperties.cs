using System;


namespace OOP_Game_Refactoring
{
    public class PlayerProperties
    {
        //To create a player you should declare all the stats
        public PlayerProperties(int _health, int _mana, int _shield, bool _hasFireBuff, bool _hasIceShield) 
        {
            Health = _health;
            Mana = _mana;
            Shield = _shield;
            HasFireBuff = _hasFireBuff;
            HasIceShield = _hasIceShield;
        }


        private int Health;

        public List<Card> Deck = new List<Card>();   //The deck of the player
        public List<Card> Hand = new List<Card>();  // The hand of the player

        public int health 
        {
            get { return Health; }
            set { Health = Math.Max(0, value); }
        }


        private int Mana;

        public int mana 
        {
            get { return Mana;  }
            set { Mana = Math.Max(0, value); }
        }

        private int Shield;

        public int shield 
        {
            get { return Shield; }
            set { Shield = Math.Max(0, value); }
        }

        private bool HasFireBuff;

        public bool hasFireBuff 
        {
            get { return HasFireBuff; }
            set { HasFireBuff = value; }
        }

        private bool HasIceShield;

        public bool hasIceShield 
        {
            get { return HasIceShield; }
            set { HasIceShield = value; }
        }

        static Random random = new Random();
        public void InitializedDeck() 
        {
            // Add cards to player deck
            for (int i = 0; i < 5; i++) Deck.Add(new FireBallCard());
            for (int i = 0; i < 5; i++) Deck.Add(new IceShieldCard());
            for (int i = 0; i < 3; i++) Deck.Add(new HealCard());
            for (int i = 0; i < 4; i++) Deck.Add(new SlashCard());
            for (int i = 0; i < 3; i++) Deck.Add(new PowerUpCard());

            ShuffleDeck(Deck); 
        } 
                

        public void DrawCards()
        {
             // Method for draw cards
            while (Hand.Count < 3 && Hand.Count >= 0)  //Check if there's no more than 3
            {
                 
                Hand.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
        }

        private static void ShuffleDeck(List<Card> deck)
        {
            // Method for shuffling the decks
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card temp = deck[k];
                deck[k] = deck[n];
                deck[n] = temp;
            }
        }

        

    }
}
