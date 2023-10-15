using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed =15f;
    Rigidbody2D rbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rbody2D =this.GetComponent<Rigidbody2D> ();
;    }

    // Update is called once per frame
    void Update()
    {
        moveLoR ();
;    }
    float LoR (){
        return Input.GetAxis ("Horizontal");
    }
    
    public void moveLoR (){
        rbody2D.velocity = LoR()* new Vector2(speed,0) ; 
    }
}
