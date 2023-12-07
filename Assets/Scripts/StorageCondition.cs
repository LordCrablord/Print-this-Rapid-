using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCondition : Storage
{
    [SerializeField] GameObject requiredItemPrefab;
    protected override void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                GiveItem();
            }
        }
    }

    bool hasRequiredObject()
    {
        var playerManager = playerCollider.GetComponent<PlayerManager>();
        var playerObject = playerManager.objectInHands;
        return false;
    }
}
