using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D Collider)
	{
		if (Collider.gameObject.tag == "Enemy") {						
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible() 
	{
		Destroy (gameObject);
	}
}
