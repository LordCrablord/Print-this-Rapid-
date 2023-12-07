using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int happyCustomer = 0;
    [SerializeField] GameObject gameUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameUI.SetActive(!gameUI.activeInHierarchy);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
