using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

	Player player;

	public float fallMultiplier = 2.5f;


	Rigidbody2D rb;

	void Awake(){
		player = GetComponent<Player> ();
	}

	void FixedUpdate(){
		//checks if player is falling and applies fallMultiplier
		if (player.velocity.y < 0) {
			player.velocity += Vector2.up * player.gravity * (fallMultiplier - 1) * Time.deltaTime;
		} 
		}
}
