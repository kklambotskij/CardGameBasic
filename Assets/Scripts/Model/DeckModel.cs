using System.Collections.Generic;
using UnityEngine;

public class DeckModel : CardCollectionModel {

    public static List<HandController> Players;

    private new void Start()
    {
        base.Start();
    }

    public override Card TakeCard(int index)
    {
        Card card = base.TakeCard(index);
        Debug.Log(card.mCardView.cardObject.name);
        if (card.mCardView != null)
        {
            Collider coll = card.mCardView.cardObject.GetComponent<BoxCollider>();
            coll.enabled = true;
        }
        return card;
    }

    protected override void Render(Vector3 pos, Quaternion rot)
    {
        //implement
        for (int i = 0; i < Cards.Count; i++)
        {
            if (!Cards[i].isOnScreen)
            {           
                Cards[i].CreateCard(new Vector3(pos.x, 
                    pos.y + i * 0.05f, pos.z),
                    rot, gameObject);
                Cards[i].mCardView.cardObject.GetComponent<BoxCollider>().enabled = false;
                Cards[i].isOnScreen = true;
            }
        }
        //base.Render(position, rotation);
    }

    private new void Reset()
    {
        base.Reset();
    }

}
