using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected CardCollectionModel Target { get; set; }
    protected GameObject CardTarget;
    protected bool myTurn;
    protected int numberOfChosenCard;
    protected Vector2 defaultPosition;
    protected Vector2 initMouse;
    protected float initX, initY, initZ;

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
        if (Target != null)
        {
            switch (Target.GetName())
            {
                case CardCollectionModel.HAND_MODEL:
                    HandAction();
                    break;
                case CardCollectionModel.DECK_MODEL:
                    DeckAction();
                    break;
                default: 
                    break;
            }
        }
        else
        {
            CardAction();
        }
    }

    protected void CardAction()
    {
        if(CardTarget != null && CardTarget.tag.Equals("Card"))
        {
            //    CardTarget.transform.Translate(new Vector3(0, -0.5f, 0));
            initX = CardTarget.transform.position.x;
            initY = CardTarget.transform.position.y;
            initZ = CardTarget.transform.position.z;
            CardTarget.transform.position = new Vector3(initX, initY, initZ - 0.1f);
            initMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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

    protected bool SetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.collider.gameObject.tag.Equals("Card"))
            {
                Target = DetectCardCollection(hit.collider.gameObject);
                if (Target != null)
                {
                    defaultPosition = Target.gameObject.transform.position;
                }
            }
            else if(CardTarget == null)
            {
                CardTarget = hit.collider.gameObject;
                return true;
            }
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
        if (cardCollection != null)
        {
            Debug.Log(cardCollection.GetType().Name); 
            return cardCollection;
        } else {
            Debug.Log("Collection is null");
            return null;
        }
        
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
