using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBench : Singleton<QuestBench>
{
    public List<ItemPoint> itemPoints;
    Dictionary<BookBuyer, GameObject> buyerOrderFinishedDict = new Dictionary<BookBuyer, GameObject>();
    Dictionary<BookBuyer, GameObject> buyerOrderDict = new Dictionary<BookBuyer, GameObject>();

    public void SetBoard(BookBuyer bookBuyer, GameObject orderPrefab, GameObject objectToCompletePrefab)
    {
        foreach(var point in itemPoints)
        {
            if (point.CheckIfFreePlace())
            {
                GameObject ourOrder = Instantiate(orderPrefab, transform.position, orderPrefab.transform.rotation);
                point.AddChild(ourOrder);
                buyerOrderDict[bookBuyer] = ourOrder;
                buyerOrderFinishedDict[bookBuyer] = objectToCompletePrefab;
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
}
