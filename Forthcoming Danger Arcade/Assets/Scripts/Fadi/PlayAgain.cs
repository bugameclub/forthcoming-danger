
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public LoadLevel LoadLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.H))
        {
            LoadLevel.loadLevel("TestingA");
        }
    }
}
