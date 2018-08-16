using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel {

    public List<Card> Cards { get; set; }
    public string Name { get; set; }

    public void GiveCard(Card card)
    {
        
    }

    public Card TakeCard()
    {
        return new Card();
    }

    protected void Shuffle()
    {

    }

    protected void Reset() 
    {
        
    }

    protected virtual void Render(Vector3 position, Quaternion rotation)
    {
        //implement
    }

}
