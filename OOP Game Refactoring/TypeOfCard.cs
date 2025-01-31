using OOP_Game_Refactoring;
using System;

namespace OOP_Game_Refactoring
{
    public class FireBallCard : Card
    {

        public override string GetCardDescription()
        {
            return "Fireball (Costs 30 mana): Deal 40 damage";
        }

        public override string GetCardName() {
            return "FireBall Card";
        }

        public override void CardEffect(PlayerProperties player, PlayerProperties enemy, string user)
        {
            
                if (player.mana >= 30)
                {
                    int damage = 40;
                    if (player.hasFireBuff) damage *= 2;
                    if (enemy.hasIceShield) damage /= 2;

                    if (enemy.shield > 0)
                    {
                        if (enemy.shield>= damage)
                        {
                            enemy.shield -= damage;
                            damage = 0;
                        }
                        else
                        {
                            damage -= enemy.shield;
                            enemy.shield = 0;
                        }
                    }

                    enemy.health -= damage;
                    player.mana -= 30;
                    Console.WriteLine($"{user} casts Fireball for {damage} damage!");
                }
                else
                {
                    Console.WriteLine("Not enough mana!");
                    return;
                }
            }
            
        }

    }

    public class IceShieldCard : Card
    {
       public override string GetCardDescription()
        {
            return "Ice Shield (Costs 20 mana): Gain 30 shield and ice protection";
        }

        public override string GetCardName()
        {
            return "IceShield Card";
        }

    public override void CardEffect(PlayerProperties player, PlayerProperties enemy, string user)
    {
        if (player.mana >= 20)
        {
            player.shield += 30;
            player.hasIceShield  = true;
            player.mana -= 20;
            Console.WriteLine("Player gains Ice Shield!");
        }
        else
        {
            Console.WriteLine("Not enough mana!");
            return;
        }
    }

}

    public class HealCard : Card
    {
        public override string GetCardDescription()
        {
            return "Heal (Costs 40 mana): Restore 40 health";
        }

        public override string GetCardName()
        {
            return "Heal Card";
        }

    public override void CardEffect(PlayerProperties player, PlayerProperties enemy, string user)
    {
        if (player.mana >= 40)
        {
            player.health = Math.Min(100, player.health + 40);
            player.mana -= 40;
            Console.WriteLine("Player heals 40 health!");
        }
        else
        {
            Console.WriteLine("Not enough mana!");
            return;
        }
    }
}

    public class SlashCard : Card
    {
        public override string GetCardDescription()
        {
            return "Slash (Costs 20 mana): Deal 20 damage";
        }

        public override string GetCardName()
        {
            return "Slash Card";
        }

    public override void CardEffect(PlayerProperties player, PlayerProperties enemy, string user)
    {
        if (player.mana >= 20)
        {
            int damage = 20;
            if (player.hasFireBuff) damage *= 2;

            if (enemy.shield > 0)
            {
                if (enemy.shield >= damage)
                {
                    enemy.shield -= damage;
                    damage = 0;
                }
                else
                {
                    damage -= enemy.shield;
                    enemy.shield = 0;
                }
            }

            enemy.health -= damage;
            player.mana-= 20;
            Console.WriteLine($"Player slashes for {damage} damage!");
        }
        else
        {
            Console.WriteLine("Not enough mana!");
            return;
        }
    }

}

    public class PowerUpCard : Card
    {
        public override string GetCardDescription()
        {
            return "Power Up (Costs 30 mana): Gain fire buff for 2 turns";
        }

        public override string GetCardName()
        {
            return "PowerUp Card";
        }

    public override void CardEffect(PlayerProperties player, PlayerProperties enemy, string user)
    {
        if (player.mana >= 30)
        {
            player.hasFireBuff = true;
            player.mana -= 30;
            Console.WriteLine("Player gains Fire Buff!");
        }
        else
        {
            Console.WriteLine("Not enough mana!");
            return;
        }
    }
}


