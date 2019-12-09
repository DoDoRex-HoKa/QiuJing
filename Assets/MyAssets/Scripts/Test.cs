using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class Test : MonoBehaviour
{
    public Item testItem;
    public ItemList list;
    private void Start()
    {
        list.AddItem(testItem);
    }
}
