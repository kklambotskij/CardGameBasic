using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionModel {

    protected List<Card> Cards { get; set; }
    protected string Name { get; set; }
    
    protected void GiveCard()
    {

    }

    protected void TakeCard()
    {

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
