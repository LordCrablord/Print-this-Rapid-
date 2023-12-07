using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCondition : Storage
{
    //public bool requiresOneOf = true;
    public List<GameObject> requiredItemList;
    protected override void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hasRequiredObject())
                    GiveItem();
            }
        }
    }

    bool hasRequiredObject()
    {
        var playerManager = playerCollider.GetComponent<PlayerManager>();
        var playerObject = playerManager.objectInHands;

        if (playerObject != null)
        {
            int playerObjectID = playerObject.GetComponent<PrintingObject>().id;

            foreach(var reqItem in requiredItemList)
            {
                int reqObjectID = reqItem.GetComponent<PrintingObject>().id;
                if (playerObjectID == reqObjectID)
                    return true;
            }
            
        }
        return false;
    }
}
