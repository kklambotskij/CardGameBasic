
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
    private new void Start()
    {
        for (int i = 0; i < 6; i++)
        {

        }
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
    public void GiveCard(Card card)
    {
        if (rules.IsAllowed(chosenCard, model))
        {
            model.GiveCard(chosenCard);
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
