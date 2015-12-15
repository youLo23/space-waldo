using UnityEngine;
using System.Collections;

public class LuckyContactDetector : MonoBehaviour {

	private BombeController bombController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null) {
            bombController = gameControllerObject.GetComponent<BombeController>();
		} else {
			Debug.Log("Composant GameController introuvable");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag.Equals("Player")) {
            bombController.cpt++;
            Destroy(gameObject);
		}
	}
}
