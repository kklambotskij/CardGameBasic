using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс состоящий изи 2 карт(для дурака), это пара должна быть частью стола
public class CardPair : CardCollectionModel
{
    protected Rules mRules;
    protected CardCollectionModel cardCollection;
    private new void Awake()
    {
        base.Awake();
    }

    private new void Start()
    {
        base.Start();

    }

    /*protected bool Check()
    {
        return (Cards.Count() <= 2);
    }*/

    //Фун-ия добовляет карту в пару, если это вщзможно 
    public void HitCard(Card chosenCard)
    {
        if ((mRules.IsAllowed(cardCollection.TakeCard(0), chosenCard)) && (cardCollection.Count < 2))
        {
            cardCollection.GiveCard(chosenCard);
        }
    }

    /*Фун-ия распологает на поле карту, которой атакуют
    public void ReplaceTargetCard(Vector3 position, Quaternion rotation)
    {
        if (CardCollection.TakeCard(0) != null)
        {
            CardCollection.TakeCard(0).ReplaceCard(position, rotation);
        }
        else
            throw new System.Exception("TargetCard is null");
    }
    //Фун-ия рвсполагает на поле карту, которой отбиваются 
    public void ReplaceChosenCard(Vector3 position, Quaternion rotation)
    {
        if (CardCollection.TakeCard(1) != null)
        {
            CardCollection.TakeCard(1).ReplaceCard(position, rotation);
        }
        else
            throw new System.Exception("ChosenCard is null");
    }*/

    protected override void Render(Quaternion rotation)
    {
        
    }
}
