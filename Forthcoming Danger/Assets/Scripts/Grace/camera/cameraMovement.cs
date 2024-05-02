using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    public void followPlayer()
    {
        GameObject player = GameObject.Find("player");
        Vector3 playerPos = player.transform.position;
        Debug.Log(playerPos);

        transform.position = playerPos + (Vector3.back * 10);
    }
}
