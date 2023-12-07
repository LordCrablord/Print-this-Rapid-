using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : Singleton<UIScript>
{
    [SerializeField] TextMeshProUGUI tipTMP;
    [SerializeField] TextMeshProUGUI finaleTMP;

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

    public void SetGameOver(int happyCustomers)
    {
        finaleTMP.gameObject.SetActive(true);
        finaleTMP.text = $"{happyCustomers} / 3 customers left happy from your printing store";
    }
}
