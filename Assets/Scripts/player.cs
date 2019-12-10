using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {


        
  
        

        Move(); 
    }

     void Move()
     {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
    //动画切换
        if (v>0) {   animator.SetBool("up", true);  }  else { animator.SetBool("up", false); }
        if(v<0){   animator.SetBool("down", true); } else { animator.SetBool("down", false); }
        if (h > 0) { animator.SetBool("right", true); } else { animator.SetBool("right", false); }
        if (h < 0) { animator.SetBool("left", true); } else { animator.SetBool("left", false); }







        if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 5.1f;
            }
            else
            {
                speed = 2.5f;
            }
            if (v!=0)
            {
                gameObject.transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime);
            } 
              else
            {
                gameObject.transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime);
            }

     }
      
}


