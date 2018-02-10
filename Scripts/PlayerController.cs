using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public enum PlatformerStates
	{
		grounded,
		climbing,
		airborne
	}
	[Header("Set in Inspector")]
	public PlatformerStates playerState;
	public float maxSpeed = .25f;
	public float jumpHeight= 2f;
	public float climbSpeed = .15f;

	public bool onLadder;
	public bool isGrounded;


	void Start () 
	{
		playerState = PlatformerStates.grounded;

	}

	void Update ()
	{
		if (!onLadder && playerState != PlatformerStates.airborne) {
			playerState = PlatformerStates.grounded;
		}
		if (onLadder && Input.GetKey("w")) 
		{
			playerState = PlatformerStates.climbing;
			Climb ();
		}
		if (onLadder && Input.GetKey("s")) 
		{
			playerState = PlatformerStates.climbing;
			Descend ();
		}
		if (playerState == PlatformerStates.grounded && Input.GetKey("d")) 
		{
			MoveRight ();
		}
		if (playerState == PlatformerStates.grounded && Input.GetKey("a")) 
		{
			MoveLeft ();
		}
		if (playerState == PlatformerStates.grounded && Input.GetKeyDown("space")) 
		{
			Jump ();
		}

	
	}

	void MoveRight(){
		transform.position += new Vector3 (maxSpeed, 0, 0);
	}
	void MoveLeft(){
		transform.position += new Vector3 (-maxSpeed, 0, 0);
	}
	void Climb(){
		transform.position += new Vector3 (0, climbSpeed, 0);
	}
	public void Descend(){
		transform.position += new Vector3 (0, -climbSpeed, 0);
	}
	void Jump(){
		transform.position += new Vector3 (0, jumpHeight, 0);
	}






}
