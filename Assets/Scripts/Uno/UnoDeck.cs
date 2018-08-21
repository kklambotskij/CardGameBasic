using UnityEngine;
using UnityEditor;

public class UnoDeck : DeckModel
{
    public const string UNO_DECK = "UnoDeck";

    private new void Start()
    {
        rotationVector = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        positionVector = new Vector3(-13, 0, 0);
        transform.position = positionVector;
        CreateUnoDeck();
        Shuffle();
        Render(positionVector, rotationVector);
        foreach (var item in Access.instance.GetListOfHands())
        {
            for (int i = 0; i < 6; i++)
            {
                item.GiveCard(TakeCard());
            }
        }
        GameObject.Find("DiscardPile").GetComponent<DiscardPile>().GiveCard(TakeCard());
    }

    private void CreateUnoDeck()
    {
        for (int n = 0; n < 4; n++)
        {
            for (int i = 0; i < 13; i++)
            {
                GiveCard(new UnoCard(new UnoCard.UnoType(i), new UnoCard.Color(n)));
            }
        }
        
    }

}