using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Composant GameController introuvable");
		}
	}

	void OnTriggerEnter(Collider other) {

		if (!other.tag.Equals ("Boundary")) {
			Debug.Log (other);
			Destroy (gameObject);
			Destroy (other.gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.addScore(scoreValue);
			
		}
	}

	void OnCollisionEnter(Collision other) {

		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag.Equals ("Asteroid"))
			return;
		Destroy(gameObject);
		Destroy (other.gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.gameObject.tag.Equals ("Player")) {

			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		}

}
