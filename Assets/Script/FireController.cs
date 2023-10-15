using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireController : MonoBehaviour
{
    public int life =4;
    BoxCollider2D bcollider2d;
    public GameObject Fire;
    public GameObject Ball;
    public Text lossText;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Fire.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (life <= 0)
        //{
        //    // Life is less than or equal to 0, pause the game
     
        //}
    }
    void OnCollisionEnter2D (Collision2D other){
        if(life>0){
            life-=1;
            Fire.gameObject.SetActive(true);
        }
        if(life<=0){
            Ball.gameObject.SetActive(false);
            lossText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
