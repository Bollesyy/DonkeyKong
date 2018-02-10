using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAI : MonoBehaviour {
	
	public float speed;
	public float climbSpeed = 0.025f;
	public Rigidbody2D rb2d;
	public bool onLadder;


	void Start () {
		onLadder = false;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if (!onLadder) {
			speed = .025f;
			transform.position += new Vector3 (speed, 0, 0);
		}
		if (onLadder) {
			speed = 0f;
			Descend ();
		}
	}
	void Descend(){
		transform.position += new Vector3 (0, -climbSpeed, 0);
	}
}
