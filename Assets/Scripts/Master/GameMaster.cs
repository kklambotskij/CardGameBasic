using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    List<GameObject> Players;
    Rules rules;

    private void Awake()
    {
        rules = new DurakRules(new Card.Suit(Card.Suit.Values.Hearts));
    }

    void AddPlayer(string name)
    {
        GameObject player = (GameObject)Instantiate(Resources.Load("Player"));
        HandController hand = player.GetComponent<HandController>();
        hand.setPlayerName(name);
        hand.rules = rules;
        Players.Add(player);
    }
}