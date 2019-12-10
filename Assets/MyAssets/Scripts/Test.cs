using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class Test : MonoBehaviour
{
    public List<Item> testItem;
    public ItemList list;
    private void Start()
    {
        foreach(Item i in testItem)
        {

            list.AddItem(i);
        }
    }
}
