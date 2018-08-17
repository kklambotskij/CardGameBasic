using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected CardCollectionModel Target { get; set; }
    protected bool myTurn;

    private void Awake()
    {
        myTurn = false;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (myTurn && Input.GetMouseButtonDown(0))
        {
            SetTarget();
        }
        else
        {
            Target = null;
        }
    }

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
