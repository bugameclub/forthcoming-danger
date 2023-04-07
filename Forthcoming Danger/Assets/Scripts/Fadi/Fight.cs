using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    // Start is called before the first frame update
	ParticleSystem ps;
	bool trigger;
	public bool multi;
	public bool auto;
	public float wait = 2f;
	float timer = 0f;
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0)){
			//ps.enableEmission = true;
			trigger = true;
			if(multi && timer > wait){
				ps.Emit(10);
				timer = 0;
			}
		}
		if(trigger && !multi && timer > wait){
			timer = 0;
			ps.Emit(1);
		}
		if(Input.GetMouseButtonUp(0)){
			//ps.enableEmission = false;
			trigger = false;
		}
    }
}
