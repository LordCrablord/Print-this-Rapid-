using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : Singleton<UIScript>
{
    [SerializeField] TextMeshProUGUI tipTMP;

    public void SetTipString(bool isStringActive, string text)
    {
        tipTMP.gameObject.SetActive(isStringActive);
        tipTMP.text = text;
    }
    public void RestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }
}
