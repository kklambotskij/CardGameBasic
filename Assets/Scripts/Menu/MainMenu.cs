using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    GameObject mCanvas;
    //Создание листов с кнопками для меню
    List<GameObject> MainMenuButtons = new List<GameObject>();
    List<GameObject> OptionsButtons = new List<GameObject>();
    List<GameObject> CreateGameButtons = new List<GameObject>();
    List<GameObject> RulesButtons = new List<GameObject>();


    State mState;

    enum State
    {
        MainMenu, Options, CreateGame, Rules
    }

    private void UpdateState()
    {
        //Выключение всех кнопок
        DeactiveButtons();

        switch (mState)
        {
            case State.MainMenu:
                SetActive(MainMenuButtons, true);
                break;
            case State.Options:
                SetActive(OptionsButtons, true);
                break;
            case State.CreateGame:
                SetActive(CreateGameButtons, true);
                break;
            default:
                break;
        }
    }

    private void DeactiveButtons()
    {
        SetActive(MainMenuButtons, false);
        SetActive(OptionsButtons, false);
        SetActive(CreateGameButtons, false);
    }

    private void SetActive(List<GameObject> buttons, bool activate)
    {
        foreach (var item in buttons)
        {
            item.SetActive(activate);
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

        AddButton(MainMenuButtons, "MainMenuButtons/NewGame");
        AddButton(MainMenuButtons, "MainMenuButtons/Options");
        AddButton(MainMenuButtons, "MainMenuButtons/Exit");
        OptionsButtons.Add(CreateButton("Plus", new Vector2(1500, 1000), "Menu/Button", "+", "CreateGameButtons"));
        OptionsButtons.Add(CreateButton("InputField", new Vector2(830, 970), "Menu/InputField", "Введите имя игрока", "CreateGameButtons"));
        OptionsButtons.Add(CreateButton("BackCreate", new Vector2(1000, 700), "Menu/Button", "Назад", "CreateGameButtons"));
        OptionsButtons.Add(CreateButton("BackOptions", new Vector2(800, 500), "Menu/Button", "Назад", "OptionsButtons"));
        OptionsButtons.Add(CreateButton("BackRules", new Vector2(1500, 1000), "Menu/Button", "Назад", "CreateGameButtons"));
    }

    private void AddButton(List<GameObject> objects, string name)
    {
        Transform transf = mCanvas.transform.Find(name);// поиск кнопки на канвасе

        if (transf != null) //проверка на null и создание кнопки
        {
            objects.Add(transf.gameObject);
        }
        else
        {
            Debug.Log("Не найдена кнопка " + name); //если возвращён null
        }
    }

    public GameObject CreateButton(string name, Vector2 vector, string path, string text, string parent = null)
    {
        GameObject gameObject = (GameObject)Instantiate(Resources.Load(path));
        gameObject.name = name;
        if (parent != null)
        {
            GameObject parentObject = mCanvas.transform.Find(parent).gameObject;
            if (parentObject != null)
            {
                gameObject.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            gameObject.transform.SetParent(mCanvas.transform);
        }
        gameObject.transform.position = vector;

        return gameObject;
    }

    public void CreateG()
    {
        SwitchState(State.CreateGame);
    }

    public void Options()
    {
        SwitchState(State.Options);
    }

    public void Rules()
    {
        SwitchState(State.Rules);
    }

    // Use this for initialization
    void Start()
    {
        UpdateState();
        mState = State.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}
