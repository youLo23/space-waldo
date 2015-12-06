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
	private int score;

	void Start(){
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startwait);

		while(true){
			for (int i = 0; i<hazardCount; i++) {
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazard, spawnposition, spawnrotation);
				yield return new WaitForSeconds(spawnwait);
			}

			yield return new WaitForSeconds(wavewait);
		}
	}

	public void addScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score : " + score;
	}
}
