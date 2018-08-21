
using UnityEngine;

public class HandController : PlayerController  {

    HandModel model;
    public Rules rules;
    DeckModel deckModel;

    private new void Awake()
    {
        base.Awake();
        model = GetComponent<HandModel>();
        rules = new UnoRules();
    }
  
    private new void Update()
    {
        base.Update();
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
                if (Target.GetType().Name == CardCollectionModel.DECK_MODEL)
                {
                    Target.GiveCard(model.TakeCard(System.Convert.ToInt32(CardTarget.name)));
                    Destroy(CardTarget);
                    model.Render();
                }
            }
            if (CardTarget != null)
            {
                CardTarget.transform.position = new Vector3(initX, initY, initZ);
                CardTarget = null;
            }
        }
    }

    protected override void Actions()
    {
        base.Actions();
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
        model.GiveCard(card);
    }

    public string getPlayerName() 
    {
        return model.PlayerName;
    }

    public void setPlayerName(string name)
    {
        model.PlayerName = name;
        return model.GetName();
    }
}
