using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnvalue;
	public int hazardCount;
	public float spawnwait;
	public float wavewait;
	public float startwait;
	public GUIText scoreText;
	public GUIText gameoverText;
	public GUIText restartText;
	public GUIText BombeText;
	public GUIText HSText;
	public GameObject surpriseBox;
	private int score;
	private bool readyToInstantiate;
	private bool gameOver, restart;
	private bool bombe;
	public int highScore = 0;
	string highScoreKey = "HighScore";



	void Start(){
		HSText.text = "";
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		Debug.Log (Directory.GetCurrentDirectory());
		restart = false;
		gameOver = false;
		gameoverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
		//StartCoroutine (instBox ());
		Bombepr();
	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startwait);

		while(true){
			for (int i = 0; i<hazardCount; i++) {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)]; 
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazard, spawnposition, spawnrotation);
				yield return new WaitForSeconds(spawnwait);
			}

			yield return new WaitForSeconds(wavewait);

            if (gameOver) {
                restartText.text = "Press \"R\" for  Restart";
                restart = true;
                break;
            }
        }
		Debug.Log ("Game Over!");
	}

	public void saveScore(){

		for (int i = 0; i<5; i++){
			
			highScoreKey = "HighScore"+(i+1).ToString();
			highScore = PlayerPrefs.GetInt(highScoreKey,0);
	
			if(score>highScore){
				int temp = highScore;
				PlayerPrefs.SetInt(highScoreKey,score);
					score = temp;
			}
		}

		string scoreText = "";
		for (int j = 0; j<5; j++){
			highScoreKey = "HighScore"+(j+1).ToString();
			string hs = "Highscore"+(j+1)+": ";
			scoreText =  scoreText+ hs + PlayerPrefs.GetInt(highScoreKey) + "\n";
		}
		HSText.text = scoreText;

		//HSText.text = "\nScore\n " + score;
		//string path = Directory.GetCurrentDirectory() + "\\scores.txt";
		/*char[] stringSeparators = new char[] { '\n' };
		TextAsset t = Resources.Load ("scores") as TextAsset;
		string[] mo = t.text.Split (stringSeparators);
		LinkedList<string> listScore = new LinkedList<string> (mo);
		//Debug.Log ("scores :\n" + t.text);
		int count = 0;
		//string tls = "";
		foreach (string txt in mo) {
			Debug.Log ("tour de boucle " + count);
			Debug.Log (txt);
			string playerScore = Regex.Match (txt, @"\d+").Value;
			int pScore = System.Int32.Parse (playerScore);
			Debug.Log(count + " " +pScore);
			count++;
			//tls += txt + " ";
			if(score >= pScore){
				listScore.AddBefore(listScore.Find(txt), 
				                    new LinkedListNode<string>("Player " + score + " "));
				break;
			}
		}
		string tls = "";
		foreach (string txt in listScore) {
			tls += txt + " ";
		}

		Debug.Log ("Tous les scores : " + tls);*/

		/*using (StreamWriter file = 
		       new StreamWriter(@path, true))
		{
			file.WriteLine("Player Name " + score);
		}*/


	}


	public void addScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	public void GameOver(){
		gameOver = true;
		gameoverText.text = "GAME OVER !";
		saveScore ();

	}

	IEnumerator instBox(Vector3 position, Quaternion rotation){
		yield return new WaitForSeconds(0.5f);
		Instantiate (surpriseBox, position, rotation);

	}
	public void instantiateBox(Vector3 position, Quaternion rotation){
		StartCoroutine(instBox (position, rotation));
	}

	void UpdateScore(){
		scoreText.text = "Score : " + score;
	}
	void Bombepr(){
		BombeText.text = "Presse B to Bombe";
	}


}
