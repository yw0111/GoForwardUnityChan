using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    //Cube Movement Speed
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    //Audioclip
    public AudioClip blockSound;
 

    //Use this for initialization
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update ()
    {
        // Move Cube
        transform.Translate(this.speed, 0, 0);
        
        //Destroy when out of screen
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
    }

    //Audio Source
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubePrefab" || collision.gameObject.tag == "Ground"){
        GetComponent<AudioSource>().PlayOneShot(blockSound);

        }

        
    }
}