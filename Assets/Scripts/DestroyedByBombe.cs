using UnityEngine;
using System.Collections;

public class DestroyedbyBombe : MonoBehaviour {


	void OntriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
