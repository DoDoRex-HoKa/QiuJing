using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.LWRP;
using TMPro;
///<summary>
///
///<\summary>
public class Item : MonoBehaviour
{
    public enum Function { Use, Take,None }
    public enum Type { Note,Key,Paper,Box,NoteBook,Door,Case,Light,None}
    public Type type;
    public Function function;
    public new string name;
    public int id;
    public string statement;
    [HideInInspector] public bool isOpened;
    [HideInInspector] public bool isLocked;
    [HideInInspector] public bool[] notes=new bool[4];
    [HideInInspector] public bool[] finalLocked = {true,true,true,true};
    [HideInInspector] public bool isLighted;
    public Sprite[] lightSprites = new Sprite[2];
    public SpriteRenderer image;
    public TextMeshPro text;
    public new BoxCollider2D collider;

    

    public void Action()
    {
        switch(function)
        {
            //纸张不显示在道具栏，不可使用
            case Function.Take:
                switch(type)
                {
                    case Type.Note:
                        function = Function.None;
                        FindObjectOfType<ItemList>().list.Find((Item item) => item.type == Type.NoteBook).notes[id] = true;
                        gameObject.SetActive(false);
                        break;
                    default:
                        //加入道具栏
                        function = Function.Use;
                        FindObjectOfType<PlayerMouse>().itemList.AddItem(this);
                        FindObjectOfType<PlayerMouse>().itemList.OpenItemList(this);
                        FindObjectOfType<PlayerMouse>().showList = true;
                        FindObjectOfType<PlayerMouse>().itemList.statement.GetComponent<TextMeshPro>().text = statement;
                        FindObjectOfType<PlayerMouse>().itemList.statement.SetActive(true);
                        break;
                }
                break;
            case Function.Use:
                switch(type)
                {
                    case Type.Box:
                        MoveBox();
                        break;
                    case Type.Case:
                        OpenCase();
                        break;
                    case Type.Door:
                        OpenDoor();
                        break;
                    case Type.Key:
                        Unlock();
                        break;
                    case Type.Light:
                        UseLight();
                        break;
                    case Type.Paper:
                        UnlockPuzzle();
                        break;
                    case Type.NoteBook:
                        Unlock();
                        break;
                }
                break;
        }
    }

    //parameter is setting
    public void Init()
    {
        text.text = name;
        text.gameObject.SetActive(false);
        collider.isTrigger = true;
        switch (function)
        {
            case Function.Use:
                switch (type)
                {
                    case Type.Key:
                        transform.localScale = Vector3.one;
                        transform.localPosition = Vector3.zero;

                        text.gameObject.SetActive(true);
                        text.sortingOrder = 1;
                        text.fontSize = 1.8f;

                        collider.offset = new Vector2(-0.4f, -0.01f);
                        collider.size = new Vector2(1.3f, 0.35f);
                        collider.isTrigger = false;

                        image.sortingLayerName = "UI";
                        image.sortingOrder = 1;
                        switch(id)
                        {
                            case 0:
                                image.transform.localPosition = new Vector3(-0.8f, 0, 0);
                                break;
                            case 1:
                                image.transform.localPosition = new Vector3(-0.8f, 0f, 0);
                                image.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                                break;
                            case 3:
                                image.transform.localPosition = new Vector3(-0.78f, 0f, 0);
                                image.transform.localScale = new Vector3(0.68f, 0.68f, 0.68f);
                                break;
                        }
                        break;
                    case Type.Paper:
                        transform.localScale = Vector3.one;
                        transform.localPosition = Vector3.zero;

                        text.gameObject.SetActive(true);
                        text.sortingOrder = 1;
                        text.fontSize = 1.8f;

                        collider.offset = new Vector2(-0.4f, -0.01f);
                        collider.size = new Vector2(1.3f, 0.35f);
                        collider.isTrigger = false;

                        image.sortingLayerName = "UI";
                        image.sortingOrder = 1;
                        image.transform.localPosition = new Vector3(-0.77f, 0f, 0);
                        image.transform.localScale = new Vector3(0.66f, 0.66f, 0.66f);
                        break;
                    case Type.NoteBook:
                        transform.localScale = Vector3.one;
                        transform.localPosition = Vector3.zero;

                        text.gameObject.SetActive(true);
                        text.sortingOrder = 1;
                        text.fontSize = 1.8f;

                        collider.offset = new Vector2(-0.4f, -0.01f);
                        collider.size = new Vector2(1.3f, 0.35f);
                        collider.isTrigger = false;
                        
                        image.sortingLayerName = "UI";
                        image.sortingOrder = 1;
                        image.transform.localPosition = new Vector3(-0.8f, 0f, 0);
                        image.transform.localScale = new Vector3(0.36f, 0.36f, 0.36f);
                        break;
                }
                break;
        }
    }

    private void OnMouseOver()
    {
        if(function==Function.Use)
        {
            if(type==Type.Key|| type == Type.Paper|| type == Type.NoteBook)
            {
                FindObjectOfType<PlayerMouse>().itemList.statement.GetComponent<TextMeshProUGUI>().text = statement;
                FindObjectOfType<PlayerMouse>().itemList.statement.SetActive(true);
            }
        }
    }



    private void MoveBox()
    {
        Vector3 dir;
        float x = transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x,
            y = transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y;
        if (Mathf.Abs(x)> Mathf.Abs(y))
        {
            if (x > 0)
                dir = Vector3.right;
            else
                dir = Vector3.left;
        }
        else
        {
            if (y > 0)
                dir = Vector3.up;
            else
                dir = Vector3.down;
        }
        transform.Translate( dir*Time.fixedDeltaTime);
        GameObject.FindGameObjectWithTag("Player").transform.Translate( dir * Time.fixedDeltaTime);
    }
    private void OpenCase()
    {
        if (!isOpened)
        {
            GameObject key1 = Instantiate(Resources.Load<GameObject>("key1"));//path
            key1.transform.position = transform.position + new Vector3(1, 0);//position
                                                                             //enemyAppear
            isOpened = true;
        }
        else
        {

        }
    }
    private void OpenDoor()
    {
        if (id != 4)
        {
            if (!isLocked)
            {
                //collider.enabled = false;
                switch(id)
                {
                    //move
                    //loadScene
                }
            }
            else
            {

            }
        }
        else
        {
            foreach(bool locked in finalLocked)
            {
                if (locked)
                {


                    return;
                }
            }
            //collider.enabled = false;
            //move
            //loadScene
        }
    }
    private void Unlock()
    {
        if(FindObjectOfType<PlayerMouse>().itemInTrigger.id==id)
        {
            FindObjectOfType<PlayerMouse>().itemInTrigger.isLocked = false;
        }
        else if(FindObjectOfType<PlayerMouse>().itemInTrigger.id ==4)
        {
            FindObjectOfType<PlayerMouse>().itemInTrigger.finalLocked[id] = false;
        }
    }
    private void UseLight()
    {
        if(!isLighted)
        {
            image.sprite = lightSprites[1];
            GetComponentInChildren<Light2D>().enabled = true;
            isLighted = true;
        }
        else
        {
            image.sprite = lightSprites[0];
            GetComponentInChildren<Light2D>().enabled = false;
            isLighted = false;
        }
    }
    private void Read()
    {

    }
    private void UnlockPuzzle()
    {

    }
}
