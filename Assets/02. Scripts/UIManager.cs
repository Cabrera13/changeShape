using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text score;
	public Text bestScore;
	public Text gameOver;
	public Text press;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void setScore (string x) {
		score.text = x;
	}
	public void setBest (string x) {
		bestScore.text = x;
	}
	public void setGameOver (string x) {
		gameOver.text = x;
	}
	public void setPress (string x) {
		press.text = x;
	}
}
