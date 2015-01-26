using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayScript : MonoBehaviour {
	public Text timeText;
	public Text scoreText;
	public int score;
	public int time;

	public GameObject menuEndGame;

	public GameObject []levelsVang;
	public int level;
	public bool endgame = false;
	// Use this for initialization
	void Start () {
		startGame();
		level = 0;
		this.StartCoroutine("Do");
	}
	public IEnumerator Do ()
	{
		bool add = true;
		while(add){
			yield return new WaitForSeconds (1);
			if(time > 0) {
				time --;
			}
			if(time <= 0 && !endgame) {
				endGame();
//				StopCoroutine("Do");
			}
		}
	}

	void endGame() {
		endgame = true;
		menuEndGame.SetActive(true);
		level ++;
	}

	void startGame() {
		menuEndGame.SetActive(false);
		endgame = false;
		time = 60;
		score = 0;
		for(int i = 0; i < levelsVang.Length; i++) {
			if(level == i) {
				levelsVang[i].SetActive(true);
			}else {
				levelsVang[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = time.ToString();
		scoreText.text = score.ToString();
	}

	public void replay() {
		startGame();
	}
}
