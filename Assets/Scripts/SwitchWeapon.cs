using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		
		if (other.tag.Equals ("Player")) {
			Debug.Log ("box collider collision ");
			
		}
	}
}
