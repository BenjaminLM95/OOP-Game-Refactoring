using OOP_Game_Refactoring;
using System;


public abstract class Card
{
    //protected string GetCardDescription = "Unknown Card"; 

    public virtual string GetCardDescription() 
    {
        return "Unkown Effect"; 
    }

    public abstract string GetCardName(); 

    public abstract void CardEffect(PlayerProperties player, PlayerProperties enemy, string user); 
   

}


