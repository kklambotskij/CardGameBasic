
public class HandController : PlayerController  {

    HandModel model;

    private new void Awake()
    {
        base.Awake();
        model = GetComponent<HandModel>();
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

    public string getPlayerName() 
    {
        return model.GetName();
    }
}
