using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBuyer : MonoBehaviour
{
    public float timeBeforeAppearing;
    public float timeToMakeBook;

    bool isBuyerActive = false;

    [SerializeField] GameObject body;

    [SerializeField] GameObject orderPrefab;
    [SerializeField] int orderCompletedId;
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
        SetTaskOnBoard();
    }

    void timeToMakeBookEnded()
    {
        isBuyerActive = false;
        body?.SetActive(false);
        /*if(!isSuccessfullyCompleted)*/ FailOrder();
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
        Destroy(this.gameObject);
        GameManager.Instance.happyCustomer++;
    }
}
