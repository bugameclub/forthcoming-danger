using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

	public int health_pack_capacity = 5;
	public int num_health_packs = 0;
	public int health_per_pack = 25;
	
	public int[] ammo = {0,0,0,0,0,0};
	
	public int[] weapon = {0,-1};
	public int current_weapon_slot = 0;
	
	public int money = 0;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
			current_weapon_slot = 0;
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			current_weapon_slot = 1;
		}
    }
	
	public void pickWeapon(int weaponId){
		weapon[current_weapon_slot] = weaponId;
	}
	
	
	
	public bool useAmmo (int ammoType){
		if(ammo[ammoType] > 0){
			ammo[ammoType]--;
			return true;
		}
		return false;
	}
	
	public void addAmmo(int ammoType, int val){
		ammo[ammoType] += val;
	}
	
	
	public int useHealthPack(){
		if(num_health_packs != 0){
			num_health_packs--;
			return health_per_pack;
		}
		return 0;
	}
	
	public void addHealthPack(int val){
		num_health_packs += val;
		//Add health pack limit?????
	}
	
	
	
	
	public int getMoney(){
		return money;
	}
	public int useMoney(int val){
		if(val >= money){
			money -= val;
			return val;
		}
		
		return 0;
	}
	public void addMoney(int val){
		money += val;
	}
	
}
