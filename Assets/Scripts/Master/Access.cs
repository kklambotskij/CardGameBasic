using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Access : MonoBehaviour
{
    private static Access _instance;
    public static Access instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Access>();
            return _instance;
        }
    }

    private List<GameObject> Players;
    private List<HandController> Hands;
    GameObject playerReady;
    GameObject changeColor;


    private int currentPlayer = -1;
    int timerTurn;
    public bool win;
    Rules mRules;

    private void Awake()
    {
        Players = new List<GameObject>();
        Hands = new List<HandController>();
        List<string> players = new List<string>();
        players.Add("player1");
        players.Add("player2");
        UnoRules rules = new UnoRules();
        StartGame(players, rules);
    }

    private void Start()
    {
        
    }

    public void StartGame(List<string> players, Rules rules)
    {
        mRules = rules;
        foreach (var item in players)
        {
            AddPlayer(item);
        }
        win = false;
        timerTurn = -2;
        GiveTurn(0);
    }

    public List<HandController> GetListOfHands()
    {
        return Hands;
    }

    public HandController NextPlayer()
    {
        currentPlayer = (currentPlayer + 1) % Hands.Count;
        return Hands[currentPlayer];
    }

    public void AddPlayer(string playerName)
    {
        GameObject player = (GameObject)Instantiate(Resources.Load("Player"));
        player.name = playerName;
        HandController hand = player.GetComponent<HandController>();
        hand.setPlayerName(playerName);
        hand.rules = mRules;
        Players.Add(player);
        Hands.Add(hand);
    }

    void GiveTurn(int number)
    {
        if (number >= Hands.Count)
        {
            number = 0;
        }
        foreach (var item in Hands)
        {
            item.gameObject.SetActive(false);
        }
        if (number >= 0)
        {
            Hands[number].GiveTurn();
            Hands[number].gameObject.SetActive(true);
        }
        currentPlayer = number;
        if (win)
        {
            UpdateCurrentPlayerText();
            return;
        }
        UpdateCurrentPlayerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GiveTurn(currentPlayer + 1);
        }
    }

    void UpdateCurrentPlayerText()
    {
        if (win)
        {
            //currentPlayerText.text = "Победил игрок: " + Hands[playerNumber].getPlayerName();
        } 
        else 
        {
            //currentPlayerText.text = "Ходит игрок: " + Hands[playerNumber];
        }
    }

    public void EndTurn()
    {
        if (!win)
        {
            timerTurn = (currentPlayer + 1);
            StartCoroutine(TimerTurn());
        }
    }

    IEnumerator TimerTurn()
    {
        print("debug");
        yield return new WaitForSeconds(0.01f);
        if (timerTurn > -2)
        {
            GiveTurn(timerTurn);
            timerTurn = -2;
        }
    }
}
