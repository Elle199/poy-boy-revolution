using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState GameState { get; private set; }

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
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        GameState = GameState.Playing;
    }

    public void Continue()
    {
        GameState = GameState.Playing;
    }

    public void PauseGame()
    {
        GameState = GameState.Paused;
    }
}

public enum GameState
{
    Paused,
    Playing,
    InMenus,
}
