using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageConditionToPut: MonoBehaviour
{
    protected bool isPlayerNear = false;
    protected Collider playerCollider;

    public List<GameObject> requiredItemList;
    protected virtual void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hasRequiredObject())
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
        if (playerManager != null)
        {
            var tempHolder = playerManager.objectInHands;

            playerManager.objectInHands = ourItem;
            if (ourItem != null)
            {
                ourItem.transform.SetParent(playerManager.handsPos);
                ourItem.transform.localPosition = Vector3.zero;
            }

            if (tempHolder != null)
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
        Debug.Log($"{other.gameObject.name} is near {gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        playerCollider = null;
    }

    bool hasRequiredObject()
    {
        var playerManager = playerCollider.GetComponent<PlayerManager>();
        var playerObject = playerManager.objectInHands;

        if (playerObject != null)
        {
            int playerObjectID = playerObject.GetComponent<PrintingObject>().id;

            foreach (var reqItem in requiredItemList)
            {
                int reqObjectID = reqItem.GetComponent<PrintingObject>().id;
                if (playerObjectID == reqObjectID)
                    return true;
            }

        }
        return false;
    }
}
