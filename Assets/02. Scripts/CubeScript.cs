using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public enum ShapeType {TRIANGLE, SPHERE, RECTANGLE, NONE};

	public GameObject triangle;
	public GameObject sphere;
	public GameObject rectangle;

	public string type;
	// Use this for initialization
	void Start () {


	}
	// Update is called once per frame
	void Update () {
		
	}

	public void setShape (int random) {
		switch (random) {
		case 0:
			triangle.SetActive (false);
			sphere.SetActive (false);
			rectangle.SetActive (false);
			break;
		case 1:
			triangle.SetActive (true);
			sphere.SetActive (false);
			rectangle.SetActive (false);
			type = "triangle";
			break;
		case 2:
			triangle.SetActive (false);
			sphere.SetActive (true);
			rectangle.SetActive (false);
			type = "sphere";
			break;
		case 3:
			triangle.SetActive (false);
			sphere.SetActive (false);
			rectangle.SetActive (true);
			type = "rectangle";
			break;
		}
	}
	public string ok () {
		return type;
	}


}
