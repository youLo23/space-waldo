using UnityEngine;
using System.Collections;

public class SurpriseMover : MonoBehaviour {

	private Vector3 velocity;
	public float speed;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		//velocity = transform.forward;
		velocity = new Vector3 (0, 0, 1);
		//rb = GetComponent<Rigidbody>();
		//rb.velocity = velocity * speed;
	}

	void Update(){
		transform.position += speed*velocity * Time.deltaTime;
	}
	
	// Update is called once per frame
	
}
