using UnityEngine;
using System.Collections;

public class BombeController : MonoBehaviour {

	private bool bombe;
	private int cpt;		// Bombe reste




	// Use this for initialization
	void Start () {
		cpt = 3;
		bombe = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bombe) {
			if(Input.GetKeyDown(KeyCode.B)){
				explosion();
				cpt--;
			}
		}
	}

	void explosion(){

		if (cpt <= 0)
			bombe = false;
		else {



		}
	}



}
