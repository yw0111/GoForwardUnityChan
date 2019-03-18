using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    //Animation Component
    Animator animator;

    //Component for moving UnityChan
    Rigidbody2D rigid2D;

    //Ground Location
    private float groundLevel = -3.0f;

    //Jump Speed Decrement
    private float dump = 0.8f;

    // Jump Speed
    float jumpVelocity = 20;

    //Game over location
    private float deadLine = -9;


    //Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator> ();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        //Control Animator Parameter
        this.animator.SetFloat("Horizontal", 1);

        //See if on ground
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //Make volume 0 when jump
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //If click on gound
        if (Input.GetMouseButtonDown (0) && isGround)
        {
            //Add power upwards
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //If No click decrease upwards power
        if (Input.GetMouseButton (0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //Make game over when pass deadline
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Destroy Unity Chan
            Destroy(gameObject);
        }

    }
}