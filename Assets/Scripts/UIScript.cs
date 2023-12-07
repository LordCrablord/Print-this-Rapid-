using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void RestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }
}
