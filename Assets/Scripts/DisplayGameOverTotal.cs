using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayGameOverTotal : MonoBehaviour {
	Text totalPoints;

	// Use this for initialization
	void Start () {
		totalPoints = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		totalPoints.text = (LevelManager.animalPoints + LevelManager.chopperPoints).ToString();
	}
}
