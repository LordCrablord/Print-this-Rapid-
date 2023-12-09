using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Notify(GameObject obj);
public class ItemPoint : MonoBehaviour
{
    bool isPlayerNear = false;
    Collider playerCollider;
    [SerializeField] AudioClip itemPut;
    
    public event Notify ItemPutOnPoint;
    protected virtual void OnItemPutOnPoint(GameObject obj)
    {
        ItemPutOnPoint?.Invoke(obj);
    }

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
                //OnItemPutOnPoint(tempHolder);
                QuestBench.Instance.CheckCompletion(tempHolder);
            }
            GameManager.Instance.PlaySound(itemPut);
        }
    }

    public bool CheckIfFreePlace() => transform.childCount > 0 ? false : true;

    public void AddChild(GameObject child)
    {
        child.transform.SetParent(transform);
        child.transform.localPosition = Vector3.zero;
    }

    void CheckForUI(bool visible)
    {
        GameObject ourItem;
        if (transform.childCount > 0)
        {
            ourItem = transform.GetChild(0).gameObject;
            var ui = GameManager.Instance.GetUI();
            ui.SetTipString(visible, ourItem.GetComponent<PrintingObject>().printObjName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerNear = true;
        playerCollider = other;

        CheckForUI(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        playerCollider = null;

        CheckForUI(false);
    }
}
