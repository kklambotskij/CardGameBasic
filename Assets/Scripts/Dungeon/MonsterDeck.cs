class MonsterDeck : DeckModel
{
    public const string MONSTER_DECK = "MonsterDeck";

    private new void Start()
    {
        base.Start();
        Name = MONSTER_DECK;
    }
}
