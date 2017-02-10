using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelManager levelScript;

	// Use this for initialization
	void Awake () {
		levelScript = GetComponent<LevelManager> ();
		InitGame ();
	}

	void InitGame() 
	{
		levelScript.LevelSetup (); 
	}

	// Update is called once per frame
	void Update () {

	}
}
