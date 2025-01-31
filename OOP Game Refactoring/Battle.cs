using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Refactoring
{
    internal class Battle
    {

        static void Main(string[] args)
        {

            PlayerProperties player = new PlayerProperties(100, 100, 0, false, false);
            PlayerProperties enemy = new PlayerProperties(100, 100, 0, false, false);

            Console.WriteLine("=== Card Battle Game ===");
            player.InitializedDeck();
            enemy.InitializedDeck();

            Random random = new Random();

            while (player.health > 0 && enemy.health > 0)
            {
                // Draw cards if needed
                if (player.Hand.Count < 3) player.DrawCards();

                Console.WriteLine(player.Hand.Count); 

                if (enemy.Hand.Count < 3) enemy.DrawCards();

                //Console.WriteLine(player.Hand[0].GetCardName()); 

                // Player turn
                DisplayGameState();
                PlayTurn(true);

                if (enemy.health <= 0) break;

                // Enemy turn
                Console.WriteLine("\nEnemy's turn...");
                Thread.Sleep(1000);
                PlayTurn(false);

                if (player.health <= 0) break;

                // End of round effects
                UpdateBuffs(true);
                UpdateBuffs(false);

                Console.WriteLine("\nPress any key for next round...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine(player.health <= 0 ? "You Lost!" : "You Won!");
            Console.ReadKey();


            void PlayTurn(bool isPlayer)
            {
                var hand = isPlayer ? player.Hand : enemy.Hand;                               

                if (isPlayer)
                {
                    Console.Write("\nChoose a card to play (1-3) or 0 to skip: ");
                    if (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int choice) || choice < 0 || choice > hand.Count)
                    {
                        Console.WriteLine($" {choice} Invalid choice! Turn skipped.");
                        return;
                    }
                    Console.WriteLine(choice.ToString());
                    if (choice == 0) return;

                    PlayCard(hand[choice - 1], isPlayer);
                    hand.RemoveAt(choice - 1);
                }
                else
                {
                    // Simple AI: randomly play a card if enough mana
                    int cardIndex = random.Next(hand.Count);
                    Card cardToPlay = hand[cardIndex];

                    // Check if enough mana
                    if ((cardToPlay.GetCardName() == "Fireball Card" && enemy.mana >= 30) ||
                        (cardToPlay.GetCardName() == "IceShield Card" && enemy.mana >= 20) ||
                        (cardToPlay.GetCardName() == "Heal Card" && enemy.mana >= 40) ||
                        (cardToPlay.GetCardName() == "Slash Card" && enemy.mana >= 20) ||
                        (cardToPlay.GetCardName() == "PowerUp Card" && enemy.mana >= 30))
                    {
                        PlayCard(cardToPlay, isPlayer);
                        hand.RemoveAt(cardIndex);
                    }
                }

            }

            void PlayCard(Card cardUsed, bool isPlayer)
            {
                if (isPlayer) 
                {
                    cardUsed.CardEffect(player, enemy, "Player");
                }
                else 
                {
                    cardUsed.CardEffect(enemy, player, "Enemy"); 
                }
            }
        

            void DisplayGameState()
            {
                Console.WriteLine($"\nPlayer Health: {player.health} | Mana: {player.mana} | Shield: {player.shield}");
                Console.WriteLine($"Enemy Health: {enemy.health} | Mana: {enemy.mana} | Shield: {enemy.shield}");

                Console.WriteLine("\nYour hand:");
                for (int i = 0; i < player.Hand.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.Hand[i].GetCardName()}  {player.Hand[i].GetCardDescription()}");
                }
            }

            void UpdateBuffs(bool isPlayer)
            {
                if (isPlayer)
                {
                    if (player.hasFireBuff) player.hasFireBuff = false;
                    if (player.hasIceShield) player.hasIceShield = false;
                    player.mana = Math.Min(100, player.mana + 20);
                }
                else
                {
                    if (enemy.hasFireBuff) enemy.hasFireBuff = false;
                    if (enemy.hasIceShield) enemy.hasIceShield = false;
                    enemy.mana = Math.Min(100, enemy.mana + 20);
                }
            }

        }
    }
}
