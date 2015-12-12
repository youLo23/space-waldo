using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
	private Rigidbody rb;

	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform spawn;
	public float fireRate;
	private float nextFire;
	private float nextUpdate;
	public float updateRate;
	private Vector3 relative;
	private RaycastHit hit;
	private AudioSource audi;
		//we hit

	void Start (){
		audi = GetComponent<AudioSource >();
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
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, spawn.position, spawn.rotation);
			audi.Play();
		}

		if (Time.time > nextUpdate) {
			nextUpdate = Time.time + updateRate;
			//relative = transform.InverseTransformDirection(0, 0, 1);
			//Debug.Log (Camera.main.transform.forward);
		}

	}

	/*public void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)){
				Debug.Log (GetComponent<Collider>().tag);
				transform.Rotate(0,90,0);
			}
			
			else{
				Debug.Log("pas clikay");
			}
			
		}

	}*/
}