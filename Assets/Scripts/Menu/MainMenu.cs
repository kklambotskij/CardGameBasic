using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    GameObject mCanvas;
    List<GameObject> MainMenuButtons = new List<GameObject>();
    List<GameObject> Options = new List<GameObject>();
    List<GameObject> CreateGame = new List<GameObject>();


    State mState;

    enum State
    {
        MainMenu, Options, CreateGame
    }

    private void UpdateState()
    {
        DeactiveButtons(); //Выключение всех кнопок

        switch (mState)
        {
            case State.MainMenu:
                foreach (var item in MainMenuButtons)
                {
                    item.SetActive(true);
                }
                break;
            case State.Options:
                foreach (var item in Options)
                {
                    item.SetActive(true);
                }
                break;
            case State.CreateGame:
                foreach (var item in CreateGame)
                {
                    item.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    private void DeactiveButtons()
    {
        foreach (var item in MainMenuButtons)
        {
            item.SetActive(false);
        }
        foreach (var item in Options)
        {
            item.SetActive(false);
        }
    }

    private void SwitchState(State state)
    {
        mState = state;
        UpdateState();
    }

    private void Awake()
    {
        SwitchState(State.MainMenu); //Установка главного меню по умолчанию

        mCanvas = GameObject.Find("Canvas");

        AddButton(MainMenuButtons, "NewGame");
        AddButton(MainMenuButtons, "Options");
        AddButton(MainMenuButtons, "Exit");
    }

    public void AddButton(List<GameObject> objects, string name)
    {
        GameObject gameObject = mCanvas.transform.Find(name).gameObject;

        if (gameObject != null) //проверка на null и создание кнопки
        {
            objects.Add(gameObject);
        }
        else
        {
            Debug.Log("Не найдена кнопка" + name);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
