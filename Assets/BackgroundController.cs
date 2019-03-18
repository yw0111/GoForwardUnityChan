using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    //Scroll Speed
    private float scrollSpeed = -0.03f;
    //Background end location
    private float deadLine = -16;
    //Background start location
    private float startLine = 15.8f;

    //Use this for initialization
    private void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //Move background
        transform.Translate(this.scrollSpeed, 0, 0); 

        //If out of screen, move to right of screen
        if (transform.position.x < this.deadLine )
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}