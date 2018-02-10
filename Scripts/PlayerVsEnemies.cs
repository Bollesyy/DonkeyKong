using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVsEnemies : MonoBehaviour {

	GameObject enemy;
	GameObject player;
	WeaponPickup weapon;
	Respawn respawn;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		weapon = GetComponent<WeaponPickup> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy" && weapon.hasWeapon) {
			Destroy (enemy);
		} else if (col.gameObject.tag == "Enemy" && !weapon.hasWeapon) {
			Destroy (player);
		}

		}
	}


