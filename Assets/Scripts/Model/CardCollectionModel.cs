using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel : MonoBehaviour {

    public const string HAND_MODEL = "HandModel";
    public const string DECK_MODEL = "DeckModel";

    protected List<Card> Cards;
    protected string Name;

    protected void Start()
    {
        Init(gameObject.name);
    }

    public void Init(string name)
    {
        Cards = new List<Card>();
        Name = name;
    }

    public string GetName()
    {
        return Name;
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
            Card card = Cards[Cards.Count - 1];
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
