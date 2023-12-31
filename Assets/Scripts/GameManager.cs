using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int happyCustomer = 0;
    public float timeTillGameOver;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject helpUI;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource buyerAudioSource;

    /*private void Start()
    {
        AudioSource.PlayClipAtPoint(backgroundMusic, Vector3.zero);
    }*/

    private void Update()
    {
        timeTillGameOver -= Time.deltaTime;
        if (timeTillGameOver <= 0.0f)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionUI.SetActive(!optionUI.activeInHierarchy);
        }else if (Input.GetKeyDown(KeyCode.H))
        {
            ShowUIHelp();
        }
    }

    void GameOver()
    {
        gameUI.GetComponent<UIScript>().SetGameOver(happyCustomer); 
        optionUI.SetActive(true);
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

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayBuyerSound(AudioClip audioClip)
    {
        buyerAudioSource.clip = audioClip;
        buyerAudioSource.Play();
    }
}
