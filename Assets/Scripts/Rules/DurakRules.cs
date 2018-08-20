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

    public override bool IsAllowed(Card chosenCard, Card topCard)
    {
        if (topCard == null)
        {
            return true;
        }

        if (topCard.CardSuit == kozir)
        {
            return ((topCard.CardSuit.Value < chosenCard.CardSuit.Value) && (chosenCard.CardSuit == kozir));
        }
        else
        {
            return (SameSuit(chosenCard, topCard) && (topCard.CardSuit.Value < chosenCard.CardSuit.Value))
                || (chosenCard.CardSuit == kozir);
        }
    }
}