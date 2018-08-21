using UnityEngine;
using UnityEditor;

public class DiscardPile : DeckModel
{
    public const string DISCARD_PILE = "DiscardPile";

    private new void Start()
    {
        rotationVector = Quaternion.AngleAxis(-90, new Vector3(1, 0, 0));
        positionVector = new Vector3(-5, 0, 0);
        transform.position = positionVector;
    }
}