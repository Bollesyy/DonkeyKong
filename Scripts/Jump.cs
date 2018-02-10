using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	Player player;

	void Start(){
		player = GetComponent<Player> ();
	}

	void Update(){
		if (Input.GetKeyDown ("space")) {
			player.velocity = Vector2.up * player.jumpVelocity; 	
		}
	}
	

}
