using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class PageController : MonoBehaviour
{

    public enum ButtonType { Last, Next }
    public ButtonType type;
    public void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            switch (type)
            {
                case ButtonType.Last:
                    FindObjectOfType<ItemList>().pageCount -= 4;
                    FindObjectOfType<ItemList>().OpenItemList();
                    break;
                case ButtonType.Next:
                    FindObjectOfType<ItemList>().pageCount += 4;
                    FindObjectOfType<ItemList>().OpenItemList();
                    break;
            }
        }
    }
}
