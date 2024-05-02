using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainMP : MonoBehaviour
{
    public LoadLevel LoadLevel;
    public float totalTime = 3;
    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0)
        {
            //Subtract elapsed time every frame
            totalTime -= Time.unscaledDeltaTime;
        }
        else
        {
            if (Input.anyKey)
            {
                LoadLevel.loadLevel("Menu");
            }
        }
    }
}
