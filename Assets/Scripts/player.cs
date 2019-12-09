using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {


        
  
        

        Move(); 
    }

     void Move()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
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


