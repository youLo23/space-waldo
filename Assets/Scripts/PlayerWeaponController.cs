using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform spawn;
	public float fireRate;
	public float updateRate;

	private float nextFire;
	private float nextUpdate;
	private AudioSource audi;

	// Use this for initialization
	void Start () {
		audi = GetComponent<AudioSource >();
	}
	
	// Update is called once per frame
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
}
