using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour 
{
    public static ButtonManager Instance;

    public GameObject mainMenu;
    public GameObject PauseMenu;

    private enum GameState 
   {
       EPlaying, 
       EWon, 
       ELost, 
       EUnknown,
   };

    GameState state;

    void Awake()
    {
        state = GameState.EPlaying;

        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void OnLevelWasLoaded(int LevelID)
    {
        if (LevelID != 0)
        {
            PauseMenu = GameObject.Find("PauseMenu");
        }
    }

    void Update()
    {
        GameStateChecking();

        if (PauseMenu != null && Input.GetButtonDown("Exit"))
        {
            foreach (Transform child in PauseMenu.transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }
    }

    void GameStateChecking()
    {
        switch (state)
        {
            case GameState.EPlaying:
                Debug.Log("Playing!");
                break;
            case GameState.EWon:
                Debug.Log("Won!");
                state = GameState.EPlaying;
                Application.LoadLevel(0);
                break;
            case GameState.ELost:
                Debug.Log("Lost!");
                state = GameState.EPlaying;
                Application.LoadLevel(0);
                break;
        }
    }

	void StartButton()
    {
        //state = GameState.EPlaying;
        Application.LoadLevel(1);
    }

    void OptionsButton()
    {
        mainMenu = GameObject.Find("MainMenu");
        foreach(Transform child in mainMenu.transform)
        {
            Debug.Log(child.name);
        }

    }

    void QuitButton()
    {
        Application.Quit();
    }

    void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }

    void ReturnToGame()
    {
        foreach (Transform child in PauseMenu.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }
    void Win()
    {
        state = GameState.EWon;
    }

    void Lose()
    {
        state = GameState.ELost;
    }
}
