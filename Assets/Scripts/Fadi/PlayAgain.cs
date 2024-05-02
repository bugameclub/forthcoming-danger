
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public float totalTime = 3;
    public LoadLevel LoadLevel;
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
