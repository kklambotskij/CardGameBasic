class DungeonRules : Rules
{
    public override bool IsAllowed(Card chosenCard, Card topCard)
    {
        return true;
    }

    public override bool IsAllowed(Card chosenCard, CardCollectionModel cardCollection)
    {
        return cardCollection.GetName().Equals(DungeonDeck.DUNGEON_DECK);
    }
}
