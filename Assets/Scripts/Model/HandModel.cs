using UnityEngine;

public class HandModel : CardCollectionModel {
    public Vector3 cardSize;
    public const float step = 1.1f;
    public float cardStep = 1;
    public string PlayerName;
    private string getName()
    {
        return PlayerName;
    }

    private new void Awake()
    {
        base.Awake();

        for (int i = 0; i < 4; i++)
        {
            GiveCard(new Card("2", new Card.Suit(Card.Suit.Values.Club)));
        }
        SetSize();
        rotation = Quaternion.AngleAxis(160, new Vector3(1, 0, 0));
        Render(new Vector3(0, 0, 0), rotation);
    }
    private new void Update()
    {
        base.Update();

    }
    void SetSize()
    {
        GameObject testObj = (GameObject)Instantiate(Resources.Load("FPC/PlayingCards_3Diamond"));
        testObj.AddComponent<BoxCollider>();
        testObj.transform.localScale = new Vector3(10, 10, 4);
        cardSize = testObj.GetComponent<BoxCollider>().bounds.size;
        Destroy(testObj);
    }
    private new void Start()
    {
        base.Start();    
    }

    public HandModel(string playerName)
    {
        PlayerName = playerName;
    }

    public void Render()
    {
        Render(position, rotation);
    }

    protected override void Render(Vector3 position, Quaternion rotation)
    {
        rotation = Quaternion.AngleAxis(160, new Vector3(1, 0, 0));
        float initialPosX = -cardSize.x * step * Cards.Count / 2;
        cardStep = cardSize.x * step;
        if (Cards.Count > 7)
        {
            cardStep = cardStep / Cards.Count * 8;
            initialPosX = -3;
        }
        for (int i = 0; i < Cards.Count; i++)
        {
            if (!Cards[i].isOnScreen)
            {
                Cards[i].CreateCard(new Vector3(initialPosX + i * cardStep,
                    position.y, position.z), rotation, gameObject);
                Cards[i].isOnScreen = true;
            }
            Cards[i].ReplaceCard(new Vector3(initialPosX + i * cardStep,
                    position.y + i * 0.001f, position.z), rotation);
            Cards[i].cardView.cardObject.name = i.ToString();
        }
    }
}
