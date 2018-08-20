using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected CardCollectionModel Target { get; set; }
    protected bool myTurn;
    protected int numberOfChosenCard;
    protected Vector2 defaultPosition;

    protected void Awake()
    {
        myTurn = false;
        numberOfChosenCard = -1;
    }

    protected void Start()
    {
        
    }

    protected void Update()
    {
        if (myTurn && Input.GetMouseButtonDown(0))
        {
            if (SetTarget())
            {
                Actions();
            }
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

    protected virtual void HandAction()
    {
        int i;
        // Поиск выбранной карты в списке и нахождение её индекса:
        for (i = 0; i < Target.Cards.Count; i++)
        {
            if (Target.gameObject == Target.gameObject) // Target.gameObject == Cards[i].gameObject
            {
                break;
            }
        }
        if (numberOfChosenCard != i)
        {
            // Все карты возвращаются в исходные позиции:
            Target.transform.position = defaultPosition; // for (int i = 0; i < Cards.Count; i++) { Cards[i].gameObject.transform.position = defaultPosition; }
            // Обращение к gameobject карты и изменение transform.position:
            Target.gameObject.transform.position += new Vector3(0, 1, 0);
            numberOfChosenCard = i;
        }
        else
        {
            // PlayCard();
            numberOfChosenCard = -1;
        }
    }

    protected virtual void DeckAction()
    {
        Target.TakeCard();
    }

    bool SetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Target = DetectCardCollection(hit.collider.gameObject);
            defaultPosition = Target.gameObject.transform.position;
        }
        return (Target != null);
    }

    public static CardCollectionModel DetectCardCollection(GameObject gameObject)
    {
        CardCollectionModel cardCollection = gameObject.GetComponent<DeckModel>(); 
        if (cardCollection == null)
        {
            cardCollection = gameObject.GetComponent<HandModel>();
        }
        Debug.Log(cardCollection.name);
        return cardCollection;
    }

    public void GiveTurn()
    {
        myTurn = true;
    }

    public void EndTurn()
    {
        myTurn = false;
        Access.instance.EndTurn();
    }

}
