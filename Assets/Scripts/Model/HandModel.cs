using UnityEngine;

public class HandModel : CardCollectionModel {
    public Vector3 cardSize;
    public const float step = 1.1f;
    public int screenWidth = Screen.width;

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
        rotation = Quaternion.AngleAxis(-20, new Vector3(1, 0, 0));
        Render(new Vector3(0, 0, 0), rotation);
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

    protected override void Render(Vector3 position, Quaternion rotation)
    {
        float initialPosX = (screenWidth - cardSize.x * step * Cards.Count) / 2;
        for (int i = 0; i < Cards.Count; i++)
        {
            if (!Cards[i].isOnScreen)
            {
                Cards[i].CreateCard(new Vector3(initialPosX + i * cardSize.x * step,
                    position.y, position.z), rotation);
                Cards[i].isOnScreen = true;
            }
            Cards[i].ReplaceCard(new Vector3(initialPosX + i * cardSize.x * step,
                    position.y + i * 0.01f, position.z), rotation);
        }
    }
}
