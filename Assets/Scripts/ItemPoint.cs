using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    bool isPlayerNear = false;
    Collider playerCollider;
    private void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log($"{gameObject.name} is triggered by {playerCollider.gameObject.name}");
                ExchangeItems();
            }
        }
    }

    void ExchangeItems()
    {
        GameObject ourItem;
        if (transform.childCount > 0)
        {
            ourItem = transform.GetChild(0).gameObject;
        }
        else
        {
            ourItem = null;
        }

        var playerManager = playerCollider.GetComponent<PlayerManager>();
        if(playerManager != null)
        {
            var tempHolder = playerManager.objectInHands;

            playerManager.objectInHands = ourItem;
            if (ourItem != null)
            {
                ourItem.transform.SetParent(playerManager.handsPos);
                ourItem.transform.localPosition = Vector3.zero;
            }

            if(tempHolder != null)
            {
                tempHolder.transform.SetParent(transform);
                tempHolder.transform.localPosition = Vector3.zero;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerNear = true;
        playerCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        playerCollider = null;
    }
}
