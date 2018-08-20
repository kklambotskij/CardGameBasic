using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс состоящий изи 2 карт(для дурака), это пара должна быть частью стола
public class DoubleCardModel : CardCollextionModel {

    protected bool isThrow = false;
    protected bool isHit = false; 
    
    private new void Awake()
    {
        base.Awake();
    }

    private new void Start()
    {
        base.Start();
    }

    public void ThrowCard(Card card)
    {
        if (!isThrow)
        {
            GiveCard(card);
            isThrow = true;
        }

    }

    public void HitCard(Card card)
    {
        if ((!isHit) && (!isThrow))
        {
            GiveCard(card);
            isHit = true;
        }
    }
}
