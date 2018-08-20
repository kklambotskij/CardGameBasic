public class Rules
{
    public virtual bool IsAllowed(Card chosenCard, Card topCard)
    {
        return true;
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
