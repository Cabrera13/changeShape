using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

	public enum ShapeType {TRIANGLE, SPHERE, RECTANGLE, NONE};

	Vector3 posInit;
	Vector3 posEnd;
	public float tValue;
	int currentIndex;
	int contador;
	public float speed = 1;
	public GameObject triangle;
	public GameObject sphere;
	public GameObject rectangle;
	public GameController gc;
	public GameObject Ui;
	public string shapeType;
	public ParticleSystem part;
	int points;
	int best;
	bool startGame;
	bool startG;
	bool buttonPressed = false;

	public AudioSource ok;
	public AudioClip xocar;
	public AudioClip pasar;
	public AudioClip bestS;
	public AudioClip st;

	public Button b;

	// Use this for initialization
	void Start () {
		points = 0;
		setShape (ShapeType.TRIANGLE);
		Ui.GetComponent<UIManager> ().setGameOver (" ");
		startGame = false;
		startG = true;
	}



	// Update is called once per frame
	void Update () {
		if (buttonPressed) {
				Ui.GetComponent<UIManager> ().setPress (" ");
				startGame = true;
				b.gameObject.SetActive (false);
				if (startG) {
					ok.PlayOneShot (st);
				}
				startG = false;
			if (Input.GetKeyDown ("space") || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)) {
				if (shapeType == "triangle") {
					setShape (ShapeType.RECTANGLE);
				} else if (shapeType == "rectangle") {
					setShape (ShapeType.SPHERE);
				} else if (shapeType == "sphere") {
					setShape (ShapeType.TRIANGLE);
				}

			}
		}
		if (startGame) {
			tValue += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (posInit, posEnd, tValue);
			if (tValue >= 1.0f) {
				startMove ();
			}
		}
	}
	void startMove () {
		posInit = transform.position;
		posEnd = transform.position + gc.directions[currentIndex];
		currentIndex = (currentIndex + 1) % gc.directions.Length;
		if (currentIndex == 5) {
			speed += 0.2f;
		} 
		tValue = 0.0f;
	}
	void setShape (ShapeType type) {
		switch (type) {
		case ShapeType.NONE:
			triangle.SetActive (false);
			sphere.SetActive (false);
			rectangle.SetActive (false);
			break;
		case ShapeType.TRIANGLE:
			triangle.SetActive (true);
			sphere.SetActive (false);
			rectangle.SetActive (false);
			shapeType = "triangle";
			break;
		case ShapeType.SPHERE:
			triangle.SetActive (false);
			sphere.SetActive (true);
			rectangle.SetActive (false);
			shapeType = "sphere";

			break;
		case ShapeType.RECTANGLE:
			triangle.SetActive (false);
			sphere.SetActive (false);
			rectangle.SetActive (true);	
			shapeType = "rectangle";
			break;
		}
	}
		void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponentInParent<CubeScript> ().ok() == shapeType) {
			points += 1;
			gc.GetComponent<GameController> ().setScore (points);
			ok.PlayOneShot (pasar);

		} else {
			ok.PlayOneShot (xocar);
			Ui.GetComponent<UIManager> ().setGameOver ("GAME OVER");
			best = gc.GetComponent<GameController> ().getBest ();
			if (best == 0) {
				gc.GetComponent<GameController> ().setBest (points);
				Invoke ("sound", 1);
			} else if (points > best) {
				gc.GetComponent<GameController> ().setBest (points);
				Invoke ("sound", 1);
			} 
			points = 0;
			gc.GetComponent<GameController> ().setScore (points);
			part.Play ();
			triangle.SetActive (false);
			sphere.SetActive (false);
			rectangle.SetActive (false);
			Invoke ("load", 2.5f);
			speed = 0;
			buttonPressed = false;
		}
	}
	void load () {
		SceneManager.LoadScene ("MainScene");
	}
	void sound () {
		ok.PlayOneShot (bestS);
	}
	public void setButtonPressed () {
		buttonPressed = true;
	}

}
