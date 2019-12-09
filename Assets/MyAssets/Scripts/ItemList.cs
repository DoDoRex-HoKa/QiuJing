using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///将挂载的物体放在只会加载一次的场景中，以避免重复生成
///<\summary>
public class ItemList : MonoBehaviour
{
    public List<Item> list;
    public int pageCount = 0;
    public GameObject statement;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(list==null)
        {
            list = new List<Item>();
        }
    }
    public void AddItem(Item i)
    {
        list.Add(i);
        i.transform.SetParent(transform);
        i.Init();
    }
    public void RemoveItem(Item i)
    {
        list.Remove(i);
    }
    public void OpenItemList()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            //Debug.Log(pageCount);
            Time.timeScale = 0;
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (pageCount < 0)
                pageCount += 4;
            else if (pageCount >= list.Count)
                pageCount -= 4;
            foreach(Item i in list)
            {
                i.gameObject.SetActive(false);
            }
            for (int j = pageCount + 4, i = pageCount; i < j; i++)
            {
                if (i < list.Count && i >= 0)
                {
                    Item item = list[i];
                    item.gameObject.SetActive(true);
                    item.transform.localPosition = new Vector3(0, -0.4f - 0.4f * (i % 4), transform.position.z - 1);
                }
            }
            gameObject.SetActive(true);
        }
    }
    public void OpenItemList(Item item)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            //Debug.Log(pageCount);
            Time.timeScale = 0;
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            for (int j = 4,hasFound=0; j < list.Count&&hasFound==0; j += 4)
            {
                for (int i = j-4; i < j; i++)
                {
                    if (i < list.Count && i >= 0)
                    {
                        Item temp = list[i];
                        if (temp == item)
                        {
                            hasFound = 1;
                            pageCount = j - 4;
                            break;
                        }
                    }
                }
            }
            if (pageCount < 0)
                pageCount += 4;
            else if (pageCount >= list.Count)
                pageCount -= 4;
            foreach (Item i in list)
            {
                i.gameObject.SetActive(false);
            }
            for (int j = pageCount + 4, i = pageCount; i < j; i++)
            {
                if (i < list.Count && i >= 0)
                {
                    Item temp = list[i];
                    temp.gameObject.SetActive(true);
                    temp.transform.localPosition = new Vector3(0, -0.4f - 0.4f * (i % 4), transform.position.z - 1);
                }
            }
            gameObject.SetActive(true);
        }
    }
    public void CloseItemList()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
