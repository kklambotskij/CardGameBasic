using UnityEngine;
using UnityEditor;

public class DurakRules : Rules
{
    Card.Suit kozir;

    public DurakRules(Card.Suit suit)
    {
        kozir = suit;
    }

    public DurakRules()
    {
        int numberSuit = Random.Range(0, 3);
    }

    public override bool IsAllowed(Card chosenCard, Card targetCard)
    {
        if (targetCard == null)
        {
            return true;
        }
        if (targetCard.CardSuit == kozir)
        {
            return ((targetCard.mDenomination < chosenCard.mDenomination) && (chosenCard.CardSuit == kozir));
        } 
        else
        {
            return (SameSuit(chosenCard, targetCard) && (targetCard.mDenomination < chosenCard.mDenomination))
                || (chosenCard.CardSuit == kozir);
        }
    }
    /*public bool ThrowCard(Desk desk, Card chosenCard)
    {
        for (i = 0; i < desk.Count(); i++)
        {
            if (desk.TakeCard(i).denomination == chosenCard.denomination)
            {
                return true;
            }
        }
        return false;
    }*/
}