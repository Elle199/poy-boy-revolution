using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState GameState { get; private set; }
    [SerializeField]
    public GameState gameStateOverride;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        GameState = gameStateOverride;

        if (GameState == GameState.Playing)
            StartGame();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        GameState = GameState.Playing;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Continue()
    {
        GameState = GameState.Playing;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        GameState = GameState.Paused;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

public enum GameState
{
    Paused,
    Playing,
    InMenus,
}
