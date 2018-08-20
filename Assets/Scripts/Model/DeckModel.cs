using System.Collections.Generic;
using UnityEngine;

public class DeckModel : CardCollectionModel {

    public static List<HandController> Players;

    private new void Start()
    {
        base.Awake();
        FoolDeck();
        Shuffle();
        Quaternion rotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Render(new Vector3(-3, 0, 0), rotation);
        foreach (var item in Access.instance.GetListOfHands())
        {
            item.GiveCard(Cards[Cards.Count - 1]);
        }
    }

    protected override void Render(Vector3 position, Quaternion rotation)
    {
        //implement
        for (int i = 0; i < Cards.Count; i++)
        {
            if (!Cards[i].isOnScreen)
            { 
                Cards[i].CreateCard(new Vector3(position.x, position.y + i * 0.005f, position.z), rotation);
                Cards[i].isOnScreen = true;
            }
        }
        //base.Render(position, rotation);
    }

    private new void Reset()
    {
        base.Reset();
    }

}
