using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int happyCustomer = 0;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject helpUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionUI.SetActive(!optionUI.activeInHierarchy);
        }else if (Input.GetKeyDown(KeyCode.H))
        {
            ShowUIHelp();
        }
    }

    void ShowUIHelp()
    {
        helpUI.SetActive(!helpUI.activeInHierarchy);
        Time.timeScale = helpUI.activeInHierarchy ? 0 : 1;
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
