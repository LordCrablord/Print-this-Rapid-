using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    bool isPlayerNear = false;
    Collider playerCollider;

    private void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GiveItem();
            }
        }
    }

    void GiveItem()
    {
        GameObject ourObject = Instantiate(objectPrefab, transform.position, objectPrefab.transform.rotation);
        var playerManager = playerCollider.GetComponent<PlayerManager>();
        ourObject.transform.SetParent(playerManager.handsPos);
        ourObject.transform.localPosition = Vector3.zero;
        if (playerManager.objectInHands != null) Destroy(playerManager.objectInHands);
        playerManager.objectInHands = ourObject;
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
}
