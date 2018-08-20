using UnityEngine;
using UnityEditor;

public class UnoRules : Rules
{
    public override bool IsAllowed(Card chosenCard, Card topCard)
    {
        if (chosenCard.CardColor.Value == Card.Color.Values.Any)
        {
            return true;
        }
        return (chosenCard.Value == topCard.Value) || SameColor(chosenCard, topCard);
    }
}