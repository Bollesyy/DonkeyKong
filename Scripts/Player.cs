using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {


	public enum PlayerStates
	{
		grounded,
		airborne,
		onLadder,
	};

	public float jumpHeight = 4f;
	public float timeToJumpApex = 0.4f;
	public PlayerStates playerState;
	public bool onLadder;
	public bool isClimbing;

	float accelerationTimeAirborne = 0.2f;
	float accelerationTimeGrounded = 0.1f;
	public float jumpVelocity;
	public float gravity;
	float moveSpeed = 6f;
	float velocityXSmoothing;
	float posX;
	public float climbSpeed;
	public Vector2 velocity;
	private Vector2 input;
	Controller2D controller;


	void Start () {
		isClimbing = false;
		climbSpeed = 0;
		controller = GetComponent<Controller2D>();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		playerState = PlayerStates.grounded;
	}

	void Update(){
			
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if (playerState == PlayerStates.onLadder) {
			gravity = 0;
		}else{
			gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		}

		if (playerState == PlayerStates.grounded) {
			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		}

		if (Input.GetKeyDown (KeyCode.Space) && playerState == PlayerStates.grounded) {
			velocity.y = jumpVelocity;
		}

		if (velocity.y > 0) {
			playerState = PlayerStates.airborne;
			onLadder = false;
		}


		if (Input.GetKey (KeyCode.W) && onLadder && playerState != PlayerStates.airborne) {
			isClimbing = true;
			velocity.x = 0;
			climbSpeed = .025f;
			gravity = 0;
			playerState = PlayerStates.onLadder;
			transform.position += new Vector3 (0, climbSpeed, 0);
		} if (Input.GetKeyUp(KeyCode.W) && onLadder) {
			isClimbing = false;
			playerState = PlayerStates.onLadder;
			gravity = 0;
		}

		if (Input.GetKey (KeyCode.S) && onLadder && playerState != PlayerStates.airborne) {
			isClimbing = true;
			velocity.x = 0;
			climbSpeed = .025f;
			gravity = 0;
			playerState = PlayerStates.onLadder;
			transform.position += new Vector3 (0, -climbSpeed, 0);
		}  if (Input.GetKeyUp(KeyCode.S) && onLadder) {
			isClimbing = false;
			playerState = PlayerStates.onLadder;
			gravity = 0;
		}

		if (!controller.collisions.below && !onLadder) {
			playerState = PlayerStates.airborne;
			//if (playerState == PlayerStates.airborne) {
				//gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
				//climbSpeed = 0;
			} 
		//}


		if (controller.collisions.below) {
			playerState = PlayerStates.grounded;
			if (playerState == PlayerStates.grounded) {
				climbSpeed = 0;
			}
		}
			
			float targetVelocityX = input.x * moveSpeed;
			velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
			velocity.x = input.x * moveSpeed;
			velocity.y += gravity * Time.deltaTime;
			controller.Move (velocity * Time.deltaTime);
		
	}

	struct RaycastOrigins{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}
}
