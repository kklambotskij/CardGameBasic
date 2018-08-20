
public class HandController : PlayerController  {

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
        if (rules.IsAllowed(chosenCard, model))
        {
            model.GiveCard(chosenCard);
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
