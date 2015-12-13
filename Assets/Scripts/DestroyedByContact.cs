using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	//public GameObject surpriseBox;
	private GameController gameController;
	public int scoreValue;
	public float force;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log("Composant GameController introuvable");
		}
	}

	void OnTriggerEnter(Collider other){

		if (!other.tag.Equals ("Boundary")) {
			//Debug.Log (other);
			Destroy (gameObject);
			Destroy (other.gameObject);
			//Instantiate (surpriseBox, transform.position, transform.rotation);
			//surpriseBox.GetComponent<Rigidbody>().AddForce(transform.forward*force);
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.addScore(scoreValue);

			//Instantiate (surpriseBox, transform.position, transform.rotation);
			float prob = Random.Range(0, 100);
			if(prob<10){
				//Debug.Log("Range = " + prob);
				gameController.instantiateBox(transform.position, transform.rotation);
			}
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
			gameController.GameOver();
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		}

}
