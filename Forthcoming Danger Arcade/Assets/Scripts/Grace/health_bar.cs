using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    public Slider hb;
    // GameObject p = GameObject.Find("../../Character/player");
    // Script ps = p.GetComponent<Script>();

    // Start is called before the first frame update
    void Start()
    {
        //GameObject p = GameObject.Find("s../Character/player");
        hb.maxValue = 100;
        hb.minValue = 0;
        hb.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // hb.value = p.health / 100;
    }

    public void updateSlider(int h)
    {
        hb.value = h;
    }
}
