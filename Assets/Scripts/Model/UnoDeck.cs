using UnityEngine;
using UnityEditor;

public class UnoDeck : DeckModel
{
    private new void Start()
    {

        Quaternion rotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Render(new Vector3(-3, 0, 0), rotation);
        foreach (var item in Access.instance.GetListOfHands())
        {
            item.GiveCard(Cards[Cards.Count - 1]);
        }
    }

    private void CreateUnoDeck()
    {
        
    }

}