using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    //Game Over Text
    private GameObject gameOverText;

    //Run Distance Text
    private GameObject runLengthText;

    //Distance Run
    private float len = 0;

    //Run Speed
    private float speed = 0.03f;

    //Game over hantei
    private bool isGameOver = false;

    //Use this for initialization
    void Start()
    {
        //Find object from scene view
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength"); 
    }

    //Update is called once per frame
    void Update()
    {
       if (this.isGameOver == false)
        {
            //Update Run Length
            this.len += this.speed;

            //Show Run Length
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString ("F2") + "m";

        }

       //When game over
       if (this.isGameOver == true)
        {
            //Load clicked Scene
            if (Input.GetMouseButtonDown(0))
            {
                //Load GameScene
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver()
    {
        //Show Game Over when dead
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}