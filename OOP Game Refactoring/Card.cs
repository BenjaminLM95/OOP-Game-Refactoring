using OOP_Game_Refactoring;
using System;


public abstract class Card
{
    //This all the abstracts/virtual methods are declare
    //Each card is going to have a different description, name card and card effect. That's the reason all these methods are abstract

    public abstract string GetCardDescription();
    

    public abstract string GetCardName();  

    public abstract void CardEffect(PlayerProperties player, PlayerProperties enemy, string user); 
   

}


