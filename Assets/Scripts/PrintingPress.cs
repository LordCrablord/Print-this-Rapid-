using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingPress : Singleton<PrintingPress>
{
    [SerializeField] List<StorageConditionToPut> itemPointsToPut;

    [SerializeField] GameObject PamphletPrefab;
    [SerializeField] GameObject PamphletPrefabRed;
    [SerializeField] GameObject PamphletPrefabBlue;
    [SerializeField] GameObject PamphletPrefabGreen;

    [SerializeField] GameObject PagePrefab;
    [SerializeField] GameObject PagePrefabRed;
    [SerializeField] GameObject PagePrefabGreen;
    [SerializeField] GameObject PagePrefabBlue;

    GameObject playerObject;

    public void CkeckPrinting(GameObject playerGameObject)
    {
        playerObject = playerGameObject;
        if (CkeckIfAllpartsFilled())
        {
            Debug.Log("Printing...");
            int orderId = itemPointsToPut[2].transform.GetChild(0).gameObject.GetComponent<PrintingObject>().id;
            int inkId = itemPointsToPut[0].transform.GetChild(0).gameObject.GetComponent<PrintingObject>().id;
            int pageId = itemPointsToPut[1].transform.GetChild(0).gameObject.GetComponent<PrintingObject>().id;
            Debug.Log($"orderId: {orderId}, inkId: {inkId}, pageId: {pageId}");
            switch (orderId)
            {
                case 13: if (inkId == 17 && pageId == 25) PrintObject(PamphletPrefab); break;
                case 14: if (inkId == 19 && pageId == 25) PrintObject(PamphletPrefabBlue); break;
                case 15: if (inkId == 18 && pageId == 25) PrintObject(PamphletPrefabGreen); break;
                case 16: if (inkId == 20 && pageId == 25) PrintObject(PamphletPrefabRed); break;

                case 5: if (inkId == 17 && pageId == 25) PrintObject(PagePrefab); break;
                case 6: if (inkId == 19 && pageId == 25) PrintObject(PagePrefabBlue); break;
                case 7: if (inkId == 18 && pageId == 25) PrintObject(PagePrefabGreen); break;
                case 8: if (inkId == 20 && pageId == 25) PrintObject(PagePrefabRed); break;
            }
        }else
        {
            Debug.Log("Not all things yet");
        }
            return;
    }

    void PrintObject(GameObject objectPrefab)
    {

        var playerManager = playerObject.GetComponent<PlayerManager>();
        var playerHandsPos = playerManager.handsPos;
        var printResult = Instantiate(objectPrefab, playerHandsPos);
        printResult.transform.localPosition = Vector3.zero;
        playerManager.objectInHands = printResult;

        DestroyPrintingObjects();
    }

    void DestroyPrintingObjects()
    {
        Destroy(itemPointsToPut[0].transform.GetChild(0).gameObject);
        Destroy(itemPointsToPut[1].transform.GetChild(0).gameObject);

        int orderId = itemPointsToPut[2].transform.GetChild(0).gameObject.GetComponent<PrintingObject>().id;
        if(orderId == 5 || orderId == 6 || orderId == 7 || orderId == 8)
        {

        }
        else
        {
            Destroy(itemPointsToPut[2].transform.GetChild(0).gameObject);
        }
        
    }

    bool CkeckIfAllpartsFilled()
    {
        foreach(var point in itemPointsToPut)
        {
            if (point.transform.childCount <= 0) return false;
        }
        return true;
    }

    
}
