using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayGameOverChopper : MonoBehaviour {
	Text chopperPoints;

	// Use this for initialization
	void Start () {
		chopperPoints = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		chopperPoints.text = LevelManager.chopperPoints.ToString();
	}
}
