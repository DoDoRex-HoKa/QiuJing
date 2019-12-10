using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class Event : MonoBehaviour
{
    public enum Type { LightOff = 0, CheckDoor = 1, Fire = 2, NPC_Move = 3, CloseDoor = 4, HuaRongDao=5,Puzzle=6,PlayerDefeat=7}
    public Type type;
    public int id;
    public bool onlyOnce;
    bool first=true;
    public void SendEvent()
    {
        FindObjectOfType<EventController>().Execute(type,id,this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlyOnce)
        {
            if(first)
            {
                SendEvent();
                first = false;
            }
        }
        else
        {
            SendEvent();
        }
    }
}
