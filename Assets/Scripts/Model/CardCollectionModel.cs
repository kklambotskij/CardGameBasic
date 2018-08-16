using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel {

    public List<Card> Cards { get; set; }
    public string Name { get; set; }

    public CardCollectionModel()
    {
        Cards = new List<Card>();
    }

    public void GiveCard(Card card)
    {
        if (Cards == null) { throw new System.Exception("Cards is null"); }
        Cards.Add(card);
    }

    public Card TakeCard()
    {
        if (Cards == null) { throw new System.Exception("Cards is null"); }
        if (Cards.Count != 0)
        {
            Card card = new Card(Cards[Cards.Count - 1]);
            Cards.RemoveAt(Cards.Count - 1);
            return card;
        }
        return null;
    }

    protected void Shuffle()
    {
        Card c;
        for (int j, i = Cards.Count - 1; i > 0; i--)
        {
            j = Random.Range(0, i);
            c = Cards[j];
            Cards[j] = Cards[i];
            Cards[i] = c;
        }
    }

    protected void Reset() 
    {
        if (Cards == null) { throw new System.Exception("Cards is null"); }
        Cards.Clear();
    }

    protected virtual void Render(Vector3 position, Quaternion rotation)
    {
        //implement
    }

}
