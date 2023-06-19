using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractableObject : MonoBehaviour
{
	bool in_range = false;
	public enum ObjectType // your custom enumeration
	{
		money, 
		ammo, 
		weapon,
		healthPack
	};
	//Edit test 4
	public int item_val;
	public int ammo_type;
	public ObjectType type;
	InventoryManager inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
	
	void addMoney(){
		inventory.addMoney(item_val);
	}
	
	void addAmmo(){
		inventory.addAmmo(ammo_type,item_val);
	}
	
	void addHealthPack(){
		inventory.addHealthPack(item_val);
	}
	void pickWeapon(){
		inventory.pickWeapon(item_val);
	}
    void Update()
    {
        if(in_range){
			if(Input.GetKeyDown(KeyCode.E)){
				if(type == ObjectType.money){
					addMoney();
					gameObject.SetActive(false);
				} else if(type == ObjectType.ammo){
					addAmmo();
					gameObject.SetActive(false);
				} else if(type == ObjectType.weapon){
					pickWeapon();
					gameObject.SetActive(false);
				} else if(type == ObjectType.healthPack){
					addHealthPack();
					gameObject.SetActive(false);
				}
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D player){
		if(player.tag == "Player"){
			in_range = true;
		}
	}
	void OnTriggerExit2D(Collider2D player){
		if(player.tag == "Player"){
			in_range = false;
		}
	}
}
