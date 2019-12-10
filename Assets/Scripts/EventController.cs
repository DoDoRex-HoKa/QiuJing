using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using TMPro;
using System;
///<summary>
///
///<\summary>
public class EventController : MonoBehaviour
{
    public Light2D global;
    public TextMeshProUGUI message;
    public GameObject bullet;
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void Execute(Event.Type type,int id,Event e)
    {
        switch(type)
        {
            case Event.Type.LightOff:
                global.intensity = 0.03f;
                break;
            case Event.Type.CheckDoor:
                StartCoroutine(ShowMessage("这扇门被锁住了。"));
                break;
            case Event.Type.Fire:
                StartCoroutine(Fire(e,id,1f));
                break;
            case Event.Type.CloseDoor:
                break;
            case Event.Type.HuaRongDao:
                break;
            case Event.Type.Puzzle:
                break;
            case Event.Type.NPC_Move:
                break;
            case Event.Type.PlayerDefeat:
                break;
        }
    }

    private IEnumerator ShowMessage(string v)
    {
        message.text = v;
        message.enabled = true;
        yield return new WaitForSeconds(1f);
        message.enabled = false;
    }
    private IEnumerator Fire(Event e, int id,float time)
    {
        while(true)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.position = e.transform.position;
            switch (id)
            {
                case 0:
                    tempBullet.GetComponent<Bullet>().dir = Vector3.up;
                    break;
                case 1:
                    tempBullet.GetComponent<Bullet>().dir = Vector3.down;
                    break;
                case 2:
                    tempBullet.GetComponent<Bullet>().dir = Vector3.left;
                    break;
                case 3:
                    tempBullet.GetComponent<Bullet>().dir = Vector3.right;
                    break;
            }
            yield return new WaitForSeconds(time);
        }
    }
}
