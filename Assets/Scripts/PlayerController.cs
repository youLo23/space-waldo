﻿using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;

	private Vector3 relative;
	private RaycastHit hit;
		//we hit

	void Start (){
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement*speed;
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (rb.velocity.z * tilt, 0.0f, rb.velocity.x * -tilt);
	}

	void Update () {
	}




}