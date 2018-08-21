using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel : MonoBehaviour {

    public const string HAND_MODEL = "HandModel";
    public const string DECK_MODEL = "DeckModel";

    public Vector3 positionVector;
    public Quaternion rotationVector;

    public List<Card> Cards;
    protected string Name;
    
    protected void Awake()
    {
        Init(gameObject.name);
    }

    protected void Start()
    {
        
    }
    protected void Update()
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
        Render(positionVector, rotationVector);
    }

    public Card TakeCard()
    {
        return TakeCard(Cards.Count - 1, true);
    }

    public virtual Card TakeCard(int index)
    {
        return TakeCard(index, true);
    }

    private Card TakeCard(int index, bool delete) 
    {
        if (Cards == null) { throw new System.Exception("Cards is null"); }
        if (Cards.Count == 0) { return null; }
        if (Cards.Count > index)
        {
            Card card = Cards[index];
            card.isOnScreen = false;
            Cards[index].mCardView.SelfDestroy();
            if (delete)
            {
                Cards.RemoveAt(index);
            }
            return card;
        }
        return null;    
    }

    public Card CheckCard(int index)
    {
        return TakeCard(index, false);
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
        if (Cards == null) { throw new System.Exception("Cards are null."); }
        Cards.Clear();
    }

    protected virtual void Render(Vector3 pos, Quaternion rot)
    {
        Debug.Log("Unexectable");
    }

    protected virtual void Replace(Vector3 pos, Quaternion rot)
    {
        Debug.Log("Unexectable");
    }
}
