using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    //public GameObject surpriseBox;
    private GameController gameController;
    public int scoreValue;
    public float force;

    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Composant GameController introuvable");
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag.Equals("Asteroid")) {
            return;
        }
        if (other.tag.Equals("Boundary") || other.CompareTag("Enemy")) {
            return;
        }
        //Instantiate (surpriseBox, transform.position, transform.rotation);
        //surpriseBox.GetComponent<Rigidbody>().AddForce(transform.forward*force);
        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        //Instantiate (surpriseBox, transform.position, transform.rotation);
        float prob = Random.Range(0, 100);
        if (prob < 10) {
            //Debug.Log("Range = " + prob);
            gameController.instantiateBox(transform.position, transform.rotation);
        }

        if (other.tag.Equals("Player")) {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.addScore(scoreValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
