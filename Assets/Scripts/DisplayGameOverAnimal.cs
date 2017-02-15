using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayGameOverAnimal : MonoBehaviour {
	Text animalPoints;

	// Use this for initialization
	void Start () {
		animalPoints = gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {		
		animalPoints.text = LevelManager.animalPoints.ToString ();
	}
}