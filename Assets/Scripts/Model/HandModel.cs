using UnityEngine;

public class HandModel : CardCollectionModel {

    private string PlayerName;

    private string getName()
    {
        return PlayerName;
    }

    private new void Awake()
    {
        base.Awake();
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
        //implement
    }

}
