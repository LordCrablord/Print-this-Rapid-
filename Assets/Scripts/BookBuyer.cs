using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BookBuyer : MonoBehaviour
{
    public float timeBeforeAppearing;
    public float timeToMakeBook;

    bool isBuyerActive = false;

    [SerializeField] GameObject body;

    [SerializeField] GameObject orderPrefab;
    [SerializeField] int orderCompletedId;
    [SerializeField] GameObject timerUI;
    [SerializeField] TextMeshProUGUI timerToMakeBookTMP;
    [SerializeField] GameObject timerForMainUi;
    [SerializeField] TextMeshProUGUI timerForMainUiTMP;
    //bool isSuccessfullyCompleted = false;
    private void Update()
    {
        if (!isBuyerActive)
        {
            timeBeforeAppearing -= Time.deltaTime;
            if (timeBeforeAppearing <= 0.0f)
                timeBeforeAppearingEnded();
        }
        else
        {
            timeToMakeBook -= Time.deltaTime;

            float roundedNumber = (float)Math.Floor(timeToMakeBook * 100) / 100;
            timerToMakeBookTMP.text = roundedNumber.ToString("F2");
            timerForMainUiTMP.text = roundedNumber.ToString("F2");

            if (timeToMakeBook <= 0.0f)
            {
                timeToMakeBookEnded();
                Destroy(gameObject);
            }
        }

    }

    void timeBeforeAppearingEnded()
    {
        isBuyerActive = true;
        body?.SetActive(true);
        timerUI.SetActive(true);
        SetTaskOnBoard();

        timerForMainUi.SetActive(true);
    }

    void timeToMakeBookEnded()
    {
        isBuyerActive = false;
        body?.SetActive(false);
        timerForMainUi.SetActive(false);
        /*if(!isSuccessfullyCompleted)*/
        FailOrder();
    }

    void SetTaskOnBoard()
    {
        QuestBench.Instance.SetBoard(this, orderPrefab, orderCompletedId);
    }

    void FailOrder()
    {
        QuestBench.Instance.RetractOrder(this);
    }

    public void ReceiveOrder()
    {
        /*isBuyerActive = false;
        body?.SetActive(false);
        isSuccessfullyCompleted = true;*/
        Debug.Log("I'm happy!");
        timerForMainUi.SetActive(false);
        Destroy(this.gameObject);
        GameManager.Instance.happyCustomer++;
    }
}
