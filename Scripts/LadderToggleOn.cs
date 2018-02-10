using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderToggleOn : MonoBehaviour {

	Player player;

	void Start () {
		player = FindObjectOfType<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			player.onLadder = true;

		}
	}


}

