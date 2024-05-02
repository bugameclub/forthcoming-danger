using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlay : MonoBehaviour
{
    public LoadLevel LoadLevel;
    // Update is called once per frame
    public float totalTime = 3;
    void Update()
    {
        if (totalTime > 0)
        {
            //Subtract elapsed time every frame
            totalTime -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.H))
            {
                LoadLevel.loadLevel("TestingA");
            }

            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                LoadLevel.loadLevel("TestingB");
            }
        }
    }
}
