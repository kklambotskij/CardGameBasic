using UnityEngine;

class DungeonDeck : DeckModel
{
    public const string DUNGEON_DECK = "DungeonDeck";
    private new void Awake()
    {
        base.Awake();
        Name = DUNGEON_DECK;
        CreateDeck();
        Shuffle();
    }

    private new void Start()
    {
        Render(new Vector3(-4, 0, 0), rotationVector);
        for (int i = 0; i < 10; i++)
        {
            Access.instance.GetListOfHands()[0].GiveCard(TakeCard());
        }
    }

    private void CreateDeck()
    {
        for (int i = 0; i < 20; i++)
        {
            Cards.Add(new Card(new Card.Denomination(Card.Denomination.Values.ACE),
                new Card.Suit(Card.Suit.Values.Diamond)));
        }
    }
}
