using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour
{
    //Cube Prefab
    public GameObject cubePrefab;

    //Time Calculation
    private float delta = 0;

    //Cube generation span
    private float span = 1.0f;

    //Cube generation position: x axis
    private float genPosX = 12;

    //Cube generation offset: y axis
    private float offsetY = 0.3f;
    //Cube distance: y axis
    private float spaceY = 6.9f;

    //Cube Generation offset: x axis
    private float offsetX = 0.5f;
    //Cube distance: x axis
    private float spaceX = 0.4f;

    //Cube Generation Limit
    private int maxBlockNum = 4;

    //Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;



        //span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            //Cube generation random number
            int n = Random.Range(1, maxBlockNum + 1);

            //Cube generation set number
            for (int i = 0; i < n; i++)
            {
                //Cube generation
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //Time until next cube generation
            this.span = this.offsetX + this.spaceX * n;
        }
    }


}


