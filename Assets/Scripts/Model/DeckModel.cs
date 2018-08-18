using UnityEngine;

public class DeckModel : CardCollectionModel {

    private new void Awake()
    {
        base.Awake();
        for (int i = 0; i < 100; i++)
        {
            GiveCard(new Card("0", new Card.Suit(Card.Suit.Values.Clubs)));
        }
    }

    protected override void Render(Vector3 position, Quaternion rotation)
    {
        //implement
        base.Render(position, rotation);
    }

    private new void Reset()
    {
        base.Reset();
    }

}
