using UnityEngine;
using UnityEditor;

public class UnoRules : Rules
{
    protected bool SameColor(UnoCard chosenCard, UnoCard topCard)
    {
        return (chosenCard.CardColor.Value == topCard.CardColor.Value);
    }

    public override bool IsAllowed(Card chosenCard, CardCollectionModel cardCollection)
    {
        if (cardCollection.GetType().ToString().Equals(DiscardPile.DISCARD_PILE) 
            && chosenCard.GetType().ToString().Equals("UnoCard"))
        {
            return IsAllowed((UnoCard)chosenCard, cardCollection.CheckCard(0));
        }
        return false;
    }

    public bool IsAllowed(UnoCard chosenCard, UnoCard topCard)
    {
        if (chosenCard.CardColor.Value == UnoCard.Color.Values.Any)
        {
            return true;
        }
        return (SameValue(chosenCard, topCard) || SameColor(chosenCard, topCard));
    }
}