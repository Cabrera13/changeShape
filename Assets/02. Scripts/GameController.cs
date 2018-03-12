using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour {
	
	public GameObject cubeScript;
	public GameObject prefabCube;
	public GameObject playerScript;
	public GameObject Ui;
	public int score = 0;
	public int best = 0;

	public List<GameObject> ok;
	Vector3 posNewCube = Vector3.down;
	float time;

	public Vector3[] directions = { 
		Vector3.forward,
		Vector3.left,
		Vector3.left,
		Vector3.left,
		Vector3.left,
		Vector3.left,
		Vector3.forward
	};
	int indexCubeDirection = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 50; i++) {
			if (indexCubeDirection == 2 || indexCubeDirection == 6) {
				cubeScript.GetComponent<CubeScript> ().setShape (Random.Range (1, 4));
			} else {
				cubeScript.GetComponent<CubeScript> ().setShape (0);
			}

			createNewCube ();

		}
	}

	
	// Update is called once per frame
	void Update () {
		Ui.GetComponent<UIManager> ().setScore ("Score: " + score);
		Ui.GetComponent<UIManager> ().setBest ("Best Score: " + getBest ());
			time += Time.deltaTime * playerScript.GetComponent<PlayerScript> ().speed;
			if (time >= 20f) {
				time = 19f;
				createNewCube ();
				if (indexCubeDirection == 2 || indexCubeDirection == 6) {
					cubeScript.GetComponent<CubeScript> ().setShape (Random.Range (1, 4));
				} else {
					cubeScript.GetComponent<CubeScript> ().setShape (0);
				}
				Destroy (ok [0]);
				ok.RemoveAt (0);
			}


	}
	void createNewCube () {
		GameObject cube = Instantiate (prefabCube);
		if (indexCubeDirection == 6) {
			cube.transform.Rotate (new Vector3 (0, 90, 0));
		}
		posNewCube = posNewCube + directions[indexCubeDirection];
		cube.transform.position = posNewCube;
		indexCubeDirection = (indexCubeDirection + 1) % directions.Length;
		ok.Add (cube);
	}
	// getters and setters
	public void setScore (int sc) {
		score = sc;
	}
	public int getBest () {
		//PlayerPrefs is a library to store the information in local storage, doesn't matter if we stop the execution and we run it again, it's always saved in local.
		return PlayerPrefs.GetInt ("highscore");
	}
	public void setBest (int b) {
		//first parameter of setInt is the name of the variable that we want to store in local, and the second parameter is the integer variable.
		PlayerPrefs.SetInt ("highscore", b);
	}
	public int getScore () {
		return score;
	}
}
