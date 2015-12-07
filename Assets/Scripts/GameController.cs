using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnvalue;
	public int hazardCount;
	public float spawnwait;
	public float wavewait;
	public float startwait;
	public GUIText scoreText;
	public GUIText gameoverText;
	public GUIText restartText;
	public GUIText BombeText;
	private int score;
	private bool gameOver, restart;
	private bool bombe;



	void Start(){
		Debug.Log ("Yohohoho");
		restart = false;
		gameOver = false;
		gameoverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
		Bombepr();
	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	/*void bombe(){
	
	
	
	}*/






	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startwait);

		while(!gameOver){
			for (int i = 0; i<hazardCount; i++) {
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazard, spawnposition, spawnrotation);
				yield return new WaitForSeconds(spawnwait);
			}

			yield return new WaitForSeconds(wavewait);
		}
		Debug.Log ("Game Over!");
		restart = true;
		restartText.text = "Press 'R' to restart";

		
	}

	public void addScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	public void GameOver(){
		gameOver = true;
		gameoverText.text = "Game Over.";

	}

	void UpdateScore(){
		scoreText.text = "Score : " + score;
	}
	void Bombepr(){
		BombeText.text = "Presse B to Bombe";
	}


}
