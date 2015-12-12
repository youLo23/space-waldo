using UnityEngine;
using System.Collections;

public class BombeController : MonoBehaviour {

	private bool bombe;
	public int cpt;		// Bombe reste
	public GameObject explosion;
	public GUIText Bomberest;

	
	// Use this for initialization
	void Start () {
		cpt = 3;
		bombe = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (bombe) {
			if(Input.GetKeyDown(KeyCode.B)){
				Debug.Log ("bombe affiche1");
				explosion_bombe();
				Debug.Log ("bombe affiche2");
				cpt--;
				Debug.Log ("bombe affiche3");
				UpdateBombe(cpt);
			}
		}

	}

	public int getCpt(){
		return cpt;
	}

	void explosion_bombe(){

		Vector3 position_b;
		Quaternion rotation_b;
	
		rotation_b=new Quaternion(0,0,0,0); 
		position_b = new Vector3(0,0,10f);

		if (cpt == 0)
			bombe = false;
		else {

			for(int j=0;j<5;j++)
			Instantiate (explosion,position_b ,rotation_b);

		}
	}
	void UpdateBombe(int cpt){
		if(cpt>=0)
		Bomberest.text = "Bombe : " + cpt;
	}


}
