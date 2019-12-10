using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class PageController : MonoBehaviour
{
    public Sprite normal, click;
    public enum ButtonType { Last, Next }
    public ButtonType type;
    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = click;
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
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
    }
}
