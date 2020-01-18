using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private GameManager gameManager;

    #region Serialized Private Variables
    [SerializeField] private GameObject StartMenu = null;
    #endregion

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameManager.GameState == GameState.Playing)
            {
                StartMenu.SetActive(true);
                gameManager.PauseGame();
            }
            else
            {
                StartMenu.SetActive(false);
                gameManager.Continue();
            }
        }
    }

    #region Public methods
    public void StartGame()
    {
        gameManager.StartGame();
        StartMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
    #endregion
}
