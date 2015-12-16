using UnityEngine;
using System.Collections;

public class BombeController : MonoBehaviour {

	public int cpt;		// Bombe reste
	public GameObject asteroid_explosion;
    public GameObject enemy_explosion;
    public GUIText Bomberest;

    private BombeController bombeController;
    private bool bombe;

    // Use this for initialization
    void Start () {
		bombe = true;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			bombeController = gameControllerObject.GetComponent<BombeController> ();
		} else {
			Debug.Log("Composant GameController introuvable");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bombe) {
			if(Input.GetKeyDown(KeyCode.B)){
				explosion_bombe();
				cpt--;		

				if (bombeController.getCpt() > 0){
                    GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
                    foreach (GameObject asteroid in asteroids) {
                        Instantiate(asteroid_explosion, asteroid.transform.position, asteroid.transform.rotation);
                        Destroy(asteroid);
                    }
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies) {
                        Instantiate(enemy_explosion, enemy.transform.position, enemy.transform.rotation);
                        Destroy(enemy);
                    }
					Debug.Log ("cptB: "+ bombeController.getCpt());
				}
            }
            UpdateBombe(cpt);
        }

	}

	public int getCpt(){
		return cpt;
	}

	void explosion_bombe(){

		Vector3 position_b;
		Quaternion rotation_b;
	
		rotation_b = new Quaternion(0,0,0,0); 
		position_b = new Vector3(0,0,10f);

		if (cpt == 0)
			bombe = false;
		else {
			for(int j = 0; j < 5; j++)
			Instantiate (asteroid_explosion, position_b ,rotation_b);
		}
	}
	void UpdateBombe(int cpt){
		if(cpt > -1)
		Bomberest.text = "Bombe : " + cpt;
	}


}
