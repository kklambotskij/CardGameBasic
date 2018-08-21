using System.Collections.Generic;

public class Rules
{
    public virtual bool IsAllowed(Card chosenCard, Card topCard)
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
    protected bool SameSuit(Card chosenCard, Card topCard)
    {
        return (chosenCard.CardSuit == topCard.CardSuit);
    }

    protected bool SameColor(Card chosenCard, Card topCard)
    {
        return (chosenCard.CardColor == topCard.CardColor);
    }
}
