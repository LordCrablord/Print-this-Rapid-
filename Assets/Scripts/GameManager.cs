using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int happyCustomer = 0;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject optionUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionUI.SetActive(!optionUI.activeInHierarchy);
        }
    }

    public UIScript GetUI() => gameUI.GetComponent<UIScript>();

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
