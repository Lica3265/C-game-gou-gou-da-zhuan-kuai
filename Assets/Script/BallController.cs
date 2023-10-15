using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;
    public float speedX= 2f ;
    public float speedY= 5f ;
    Rigidbody2D rbody2D;
    CircleCollider2D ccollider2d; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rbody2D =this.GetComponent<Rigidbody2D> ();
        ccollider2d = this.GetComponent<CircleCollider2D> ();
        Invoke ("StartBall",1); 
    }
    // Update is called once per frame
    void Update()
    {
 
         if(Input.GetKey(KeyCode.Space)){
            StartBall();
        }
    }
    void StartBall (){
        if(isStop()){
            rbody2D.velocity =  new Vector2 (speedX,speedY);
            transform.SetParent (null);
            ccollider2d.enabled = true; 
        }
    }
    bool isStop(){
        return rbody2D.velocity==Vector2.zero;
    }

    void OnCollisionEnter2D (Collision2D other){
        speedX+=0.1f;
        speedY+=0.1f;
        lockSpeed();
        if(other.gameObject.CompareTag("Brick")){
            other.gameObject.SetActive(false);
            gameManager.UpdateScore();
            GenerateBall();
        }
   
        }
    void lockSpeed ()
    {
        Vector2 lockspeed = new Vector2 (resetspeedX(),resetspeedY());
        rbody2D.velocity = lockspeed;
    }
    float resetspeedX (){
        float curspeedX = rbody2D.velocity.x;
        if (curspeedX < 0)
        {
            return -speedX;
        }
        else
        {
            return speedX;
        }
    }
    float resetspeedY (){
        float curspeedY = rbody2D.velocity.y;
        if (curspeedY<0)
        {
            return -speedY;
        }
        else
        {
            return speedY;
        }
    }
    void GenerateBall()
    {
        GameObject newBall = Instantiate(gameObject, transform.position, Quaternion.identity);
        Rigidbody2D newBallRigidbody = newBall.GetComponent<Rigidbody2D>();


        Vector2 currentVelocity = rbody2D.velocity;
        newBallRigidbody.velocity = new Vector2(currentVelocity.x, currentVelocity.y);
    }

}
