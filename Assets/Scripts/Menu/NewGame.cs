using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
    private const string Name = "Game";

    public void TaskOnClick()
    {
        SceneManager.LoadScene(Name);
    }

}
