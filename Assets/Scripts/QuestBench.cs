using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBench : Singleton<QuestBench>
{
    public List<ItemPoint> itemPoints;
    Dictionary<int, BookBuyer> buyerOrderFinishedDict = new Dictionary<int, BookBuyer>();
    Dictionary<BookBuyer, GameObject> buyerOrderDict = new Dictionary<BookBuyer, GameObject>();

    public void SetBoard(BookBuyer bookBuyer, GameObject orderPrefab, int objectToCompleteId)
    {
        foreach(var point in itemPoints)
        {
            if (point.CheckIfFreePlace())
            {
                GameObject ourOrder = Instantiate(orderPrefab, transform.position, orderPrefab.transform.rotation);
                point.AddChild(ourOrder);
                buyerOrderDict[bookBuyer] = ourOrder;
                
                buyerOrderFinishedDict[objectToCompleteId] = bookBuyer;
                return;
            }
        }
        Debug.LogError("No more place!!!!");
    }

    public void RetractOrder(BookBuyer bookBuyer)
    {
        GameObject reqOrder = buyerOrderDict[bookBuyer];
        Destroy(reqOrder);
    }

    public void CheckCompletion(GameObject item)
    {
        BookBuyer potensialBuyer;
        var printItem = item.GetComponent<PrintingObject>();
        if (printItem != null)
        {
            if (buyerOrderFinishedDict.TryGetValue(printItem.id, out potensialBuyer))
            {
                buyerOrderFinishedDict.Remove(printItem.id);

                GameObject reqOrder = buyerOrderDict[potensialBuyer];
                buyerOrderDict.Remove(potensialBuyer);
                if(reqOrder !=null ) Destroy(reqOrder);
                Destroy(item);
                PlayerManager.Instance.objectInHands = null;
                potensialBuyer.ReceiveOrder();

            }
        }
        
    }
}
