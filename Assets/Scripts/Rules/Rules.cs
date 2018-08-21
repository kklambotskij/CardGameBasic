using System.Collections.Generic;

public class Rules
{
    public virtual bool IsAllowed(Card chosenCard, Card topCard)
    {
        return true;
    }

    public virtual bool IsAllowed(Card chosenCard, CardCollectionModel cardCollection)
    {
        return true;
    }
    
    protected int CountWinners(List<HandModel> hands)
    {
        int amountWon = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            if (hands[i].Cards.Count == 0)
                amountWon++;
        }
        return amountWon;
    }

    protected virtual bool SameValue(Card chosenCard, Card topCard)
    {
        return (chosenCard.mDenomination == topCard.mDenomination);
    }

    protected virtual bool SameSuit(Card chosenCard, Card topCard)
    {
        return (chosenCard.CardSuit.Value == topCard.CardSuit.Value);
    }
}
