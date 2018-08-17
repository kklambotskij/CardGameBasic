
public class HandController : PlayerController  {

    public HandModel model;

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
    }

    public void getCard()
    {
        model.GiveCard(Target.TakeCard());
    }
}
