using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家靠近门，门关闭
public class OpenTheDoor : MonoBehaviour
{
    Animator animator;
    public BoxCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            collider2D.enabled = true;
            animator.SetTrigger("close");
        }
    }
}
