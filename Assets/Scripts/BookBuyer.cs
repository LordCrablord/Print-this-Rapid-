using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBuyer : MonoBehaviour
{
    public float timeBeforeAppearing;
    public float timeToMakeBook;

    bool isBuyerActive = false;

    [SerializeField] GameObject body;

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
    }

    void timeToMakeBookEnded()
    {
        isBuyerActive = false;
        body?.SetActive(false);
    }
}
