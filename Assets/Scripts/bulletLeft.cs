using UnityEngine;
using System.Collections;

public class bulletLeft : bullet {	
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2(-10,0);
	}
}
