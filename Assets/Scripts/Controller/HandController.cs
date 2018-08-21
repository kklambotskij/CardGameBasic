
using System;
using System.Collections.Generic;
using UnityEngine;

public class HandController : PlayerController {

    HandModel model;
    public Rules rules;

    private new void Awake()
    {
        base.Awake();
        model = GetComponent<HandModel>();
        rules = new UnoRules();
    }

    private new void Update()
    {
        base.Update();
        if (myTurn)
        {
            DragAndDrop();
        }
    }

    private void DnDAction()
    {
        Target.GiveCard(model.TakeCard(Convert.ToInt32(CardTarget.name)));
        Destroy(CardTarget);
        model.Render();
    }

    private void DragAndDrop()
    {
        if (Input.GetMouseButton(0) && CardTarget != null)
        {
            CardTarget.transform.Translate((Input.mousePosition.x - initMouse.x) / 90,
                -(Input.mousePosition.y - initMouse.y) / 90, 0);
            initMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0) && CardTarget != null)
        {
            if (SetTarget() && Target != null)
            {
                Debug.Log(Target.GetType().ToString());
                Card card = model.CheckCard(TryParse(CardTarget.name));
                if (rules.IsAllowed(card, Target))
                {
                    DnDAction();
                    EndTurn();
                }
            }
            if (CardTarget != null)
            {
                CardTarget.transform.position = new Vector3(initX, initY, initZ);
                CardTarget = null;
            }
        }
    }

    public int TryParse(string str)
    {
        try
        {
            return Convert.ToInt32(str);
        } 
        catch(Exception e)
        {
            Debug.Log(e);
            return -1;
        }
    }

    protected override void Actions()
    {
        base.Actions();
        if (Target != null)
        {
            switch (Target.GetName())
            {
                case DiscardPile.DISCARD_PILE:
                    GetCard();
                    break;
                default:
                    break;
            }
        }
     }

    protected override void HandAction()
    {
        base.HandAction();
        //implement
    }

    protected override void DeckAction()
    {
        base.DeckAction();
        GetCard();
        EndTurn();
    }

    public void GetCard()
    {
        model.GiveCard(Target.TakeCard());
    }

    public void PutCard(Card chosenCard, CardCollectionModel model)
    {

    }
    public void GiveCard(Card card)
    {
        if (rules.IsAllowed(card, card))
        {
            model.GiveCard(card);
        }
    }

    public string getPlayerName() 
    {
        return model.PlayerName;
    }

    public void setPlayerName(string name)
    {
        model.PlayerName = name;
    }
}
