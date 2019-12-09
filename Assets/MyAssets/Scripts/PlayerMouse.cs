using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///优先级处理
///打开物品栏时：使用物品
///关闭物品栏时：互动
///<\summary>
public class PlayerMouse : MonoBehaviour
{

    public ItemList itemList;
    public bool showList=false;
    public Item itemInTrigger;

    private void Update()
    {

        
        

        if(Input.GetMouseButtonDown(1))
        {
            if (itemList)
            {
                if (!showList)
                {
                    itemList.OpenItemList();
                    showList = true;
                }
                else
                {
                    itemList.CloseItemList();
                    showList = false;
                }
            }
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (itemList)
            {
                if (showList)
                {

                }
            }
        }
    }
    




    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Item>())
            itemInTrigger = collision.GetComponent<Item>();
        if (itemList)
        {
            if (collision.GetComponent<Item>())
            {
                if (!showList)
                {
                    if(collision.GetComponent<Item>().type==Item.Type.Box)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            gameObject.GetComponent<player>().enabled = false;
                            collision.GetComponent<Item>().Action();
                        }
                        else
                        {
                            gameObject.GetComponent<player>().enabled = true;
                        }
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        collision.GetComponent<Item>().Action();
                    }
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        itemInTrigger = null;
    }





}
