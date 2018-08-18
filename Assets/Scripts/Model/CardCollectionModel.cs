using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel : MonoBehaviour {

    public const string HAND_MODEL = "HandModel";
    public const string DECK_MODEL = "DeckModel";

    protected List<Card> Cards;
    protected string Name;

    protected void Awake()
    {
        Init(gameObject.name);
    }

    protected void Start()
    {
        
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
        if (card != null)
        {
            Cards.Add(card);
        }
    }

    public Card TakeCard()
    {
        return TakeCard(Cards.Count - 1);
    }

    public Card TakeCard(int index) 
    {
        if (Cards == null) { throw new System.Exception("Cards is null"); }
        if (Cards.Count == 0) { return null; }
        if (Cards.Count > index)
        {
            Card card = Cards[index];
            Cards.RemoveAt(index);
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
        
    }

}
