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
    }
}
