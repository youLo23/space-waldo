using UnityEngine;
using System.Collections;

public class DestroyedByBoundary : MonoBehaviour {
	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Debug.Log (other.tag + " a ete detruit");
		Destroy(other.gameObject);
	}

}
