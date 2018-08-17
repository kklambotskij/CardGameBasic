using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected CardCollectionModel Target { get; set; }
    protected bool myTurn;

    protected void Awake()
    {
        myTurn = true;
    }

    protected void Start()
    {
        
    }

    protected void Update()
    {
        if (myTurn && Input.GetMouseButtonDown(0))
        {
            SetTarget();
            Actions();
        }
        else
        {
            Target = null;
        }
    }

    protected virtual void Actions()
    {
        switch (Target.GetType().Name)
        {
            case CardCollectionModel.HAND_MODEL:
                HandAction();
                break;
            case CardCollectionModel.DECK_MODEL:
                DeckAction();
                break;
            default:
                Debug.Log("Unexpected target");
                break;
        }
    }

    protected virtual void HandAction() {}

    protected virtual void DeckAction() {}

    private void SetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Target = DetectCardCollection(hit.collider.gameObject);
        }
    }

    public static CardCollectionModel DetectCardCollection(GameObject gameObject)
    {
        CardCollectionModel cardCollection = gameObject.GetComponent<DeckModel>(); 
        if (cardCollection == null)
        {
            cardCollection = gameObject.GetComponent<HandModel>();
        }
        Debug.Log(cardCollection.GetName());
        return cardCollection;
    }

}
