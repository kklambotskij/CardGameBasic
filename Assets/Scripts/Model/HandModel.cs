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
        SetSize();
        rotationVector = Quaternion.AngleAxis(160, new Vector3(1, 0, 0));
    }

    private new void Update()
    {
        base.Update();

    }
    void SetSize()
    {
        GameObject testObj = (GameObject)Instantiate(Resources.Load("Uno/Card"));
        testObj.AddComponent<BoxCollider>();
        testObj.transform.localScale = new Vector3(10, 10, 4);
        cardSize = testObj.GetComponent<BoxCollider>().bounds.size;
        Destroy(testObj);
    }
    private new void Start()
    {
        base.Start();
        Render();
    }

    public HandModel(string playerName)
    {
        PlayerName = playerName;
    }

    public void Render()
    {
        Render(positionVector, rotationVector);
    }

    protected override void Render(Vector3 pos, Quaternion rot)
    {
        rot = Quaternion.AngleAxis(160, new Vector3(1, 0, 0));
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
                                                pos.y, pos.z), rot, gameObject);
                Cards[i].isOnScreen = true;
                if (Cards[i].mCardView.cardObject.GetComponent<BoxCollider>() != null)
                {
                    Cards[i].mCardView.cardObject.AddComponent<BoxCollider>();
                }
            }
            Cards[i].ReplaceCard(new Vector3(initialPosX + i * cardStep,
                                             pos.y + i * 0.001f, pos.z), rot);
            Cards[i].mCardView.cardObject.name = i.ToString();
        }
    }
}
