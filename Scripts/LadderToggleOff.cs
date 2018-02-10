using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderToggleOff : MonoBehaviour {

	Player player;

	void Start () {
		player = FindObjectOfType<Player> ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (player.gameObject.tag == "Player") {
			player.onLadder = false;
		}
	}
}
