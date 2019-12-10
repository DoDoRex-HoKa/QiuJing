using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class Bullet : MonoBehaviour
{
    public Vector3 dir;
    private void FixedUpdate()
    {
        transform.Translate(dir * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Player":
                GetComponent<Event>().SendEvent();
                Destroy(this);
                break;
            default:
                Destroy(this);
                break;
        }
    }
}
