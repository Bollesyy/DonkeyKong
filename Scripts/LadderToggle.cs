using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderToggle : MonoBehaviour {

	private Player player;
	private BarrelAI barrel;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		barrel = FindObjectOfType<BarrelAI> ();
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			player.onLadder = true;
		}
		if (col.gameObject.tag  == "Enemy") 
		{
			barrel.onLadder = true;
		}
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag  == "Player") 
		{
			player.onLadder = false;
			player.isClimbing = false;
			player.playerState = Player.PlayerStates.grounded;


		}
		if (col.gameObject.tag  == "Enemy") 
		{
			barrel.onLadder = false;
		}
	}
}
