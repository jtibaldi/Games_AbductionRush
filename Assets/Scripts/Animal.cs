using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
	public bool gameOver = false;

	bool rayCollision = false;
	bool floorCollision = false;
	bool dead = false;
	float lifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void animalUpdate () {		
		lifeTime += Time.deltaTime;

		if (lifeTime >= 10 && !isCollidingWithRay () && isCollidingWithFloor ()) {
			dead = true;
			lifeTime = 0;
		}

	}

	void OnTriggerEnter2D(Collider2D Collider) 
	{
		if (Collider.gameObject.tag == "abductedray") 
		{
			rayCollision = true;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, this.GetComponent<Rigidbody2D> ().velocity.y + 3);
		}
		if (Collider.gameObject.tag == "ovni") 
		{			
			//PlayerPrefs.SetInt ("CurrentScore", PlayerPrefs.GetInt ("CurrentScore") + 100);
			LevelManager.animalPoints += 100;
			dead = true;
			lifeTime = 0;
		}
	}

	void OnTriggerStay2D (Collider2D Collider) 
	{
		if (Collider.gameObject.tag == "floor") 
		{
			floorCollision = true;
		}
	} 

	void OnTriggerExit2D(Collider2D Collider) 
	{
		if (Collider.gameObject.tag == "abductedray") 
		{
			rayCollision = false;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}

		if (Collider.gameObject.tag == "floor") 
		{
			floorCollision = false;
		}
	}

	public bool isCollidingWithRay() 
	{
		return rayCollision;	
	}

	public bool isCollidingWithFloor() 
	{
		return floorCollision;
	}

	public bool isDead() 
	{
		return dead;
	}
}