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

    private void Awake()
    {
        Players = new List<GameObject>();
        Hands = new List<HandController>();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        win = false;
        timerTurn = -2;
        AddPlayer(GameObject.Find("Player1"));
        AddPlayer(GameObject.Find("Player2"));
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

    public void AddPlayer(GameObject obj)
    {
        Players.Add(obj);
        string playerName = "Player" + Players.Count;
        Players[Players.Count - 1].name = name;
        Hands.Add(Players[Players.Count - 1].GetComponent<HandController>());
        //hands[hands.Count - 1].playerName = name;
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
