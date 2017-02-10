using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int selectedController;

	public float moveSentivity = 0.20f;
	public float speed;
	float crossHairBoundaryRadius = 0.5f;
	float moveX;
	float moveY;

	public GameObject abductionrayPrefab;
	GameObject abductionray;

	// Use this for initialization
	void Start () {		
		selectedController = Constants.KEYBOARD_CONTROL;
		abductionray = Instantiate(abductionrayPrefab, new Vector2(1.55f, 1.7f), GetComponent<Transform>().rotation) as GameObject;
		abductionray.GetComponent<Renderer> ().enabled = false;
	}

	void Update () {
		Vector3 posP1 = GetComponent<Transform>().position;
		Vector3 posP2 = abductionray.GetComponent<Transform> ().position;
		float screenRatio = 16.0f / 9.0f;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (posP1.x + crossHairBoundaryRadius >= widthOrtho)
		{
			posP1.x = widthOrtho - crossHairBoundaryRadius;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,this.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP1.x - crossHairBoundaryRadius <= -widthOrtho)
		{
			posP1.x = -widthOrtho + crossHairBoundaryRadius;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,this.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP1.y >= (Camera.main.orthographicSize - 0.3f))
		{
			posP1.y = Camera.main.orthographicSize - 0.3f;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(this.GetComponent<Rigidbody2D> ().velocity.x,0);
		}
		if (posP1.y <= (-Camera.main.orthographicSize + 4.4f)) {
			abductionray.GetComponent<Renderer> ().enabled = true;
			posP1.y = -Camera.main.orthographicSize + 4.4f;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, 0);
		} else 
		{
			abductionray.GetComponent<Renderer> ().enabled = false;
		}
		if (posP2.x + crossHairBoundaryRadius >= widthOrtho)
		{
			posP2.x = widthOrtho - crossHairBoundaryRadius;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,abductionray.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP2.x - crossHairBoundaryRadius <= -widthOrtho)
		{
			posP2.x = -widthOrtho + crossHairBoundaryRadius;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,abductionray.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP2.y >= (Camera.main.orthographicSize - 1.8f))
		{
			posP2.y = Camera.main.orthographicSize - 1.8f;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2(abductionray.GetComponent<Rigidbody2D> ().velocity.x,0);
		}
		if (posP2.y <= (-Camera.main.orthographicSize + 2.2f))
		{
			posP2.y = -Camera.main.orthographicSize + 2.2f;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2(abductionray.GetComponent<Rigidbody2D> ().velocity.x, 0);
		}
		GetComponent<Transform>().position = posP1;
		abductionray.GetComponent<Transform>().position = posP2;
		/*
		if (Input.GetKeyUp (KeyCode.C)) {
			abductionray.GetComponent<Renderer> ().enabled = false;
			abductionray.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; 
		}*/
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		abductionray.GetComponent<Transform> ().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y - 2.1f); 
		abductionray.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D>().velocity; 
		switch (selectedController)
		{
		case Constants.KEYBOARD_CONTROL:
			{
				if (Input.GetKey (KeyCode.RightArrow)) {
					this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x + moveSentivity, this.GetComponent<Rigidbody2D> ().velocity.y);
					//this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x + 0.1f, this.GetComponent<Transform>().position.y);
				} 
				if (Input.GetKey (KeyCode.LeftArrow)) {
					this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x - moveSentivity, this.GetComponent<Rigidbody2D> ().velocity.y);
					//this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x - 0.1f, this.GetComponent<Transform>().position.y);
				}
				if (Input.GetKey (KeyCode.UpArrow)) {
					this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, this.GetComponent<Rigidbody2D> ().velocity.y + moveSentivity);
					//this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y + 0.1f);
				}
				if (Input.GetKey (KeyCode.DownArrow)) {
					this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, this.GetComponent<Rigidbody2D> ().velocity.y - moveSentivity);
					//this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y - 0.1f);
				} 
				/*
				if (Input.GetKey (KeyCode.C)) {					
					abductionray.GetComponent<Renderer> ().enabled = true;
					abductionray.GetComponent<Transform> ().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y - 2.1f); 
					abductionray.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D>().velocity; 
				}*/
				if (Input.GetKey (KeyCode.Z))
			 	{
					//Shoot Left	
				}
				if (Input.GetKey (KeyCode.X))
				{
					//Shoot Right	
				}
				break;
			}
		case Constants.PAD_CONTROL:
			{
				moveX = Input.GetAxis("Horizontal");
				moveY = Input.GetAxis("Vertical");
				if (moveX > 0.5)
				{
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, this.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (moveX < -0.5)
				{
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, this.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (moveY > 0.5)
				{
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -moveY * speed);
				}
				else if (moveY < -0.5)
				{
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -moveY * speed);
				}
				if (moveX > -0.5 && moveX < 0.5)
				{                        
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
				}
				if (moveY > -0.5 && moveY < 0.5)
				{                        
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
				}
				break;
			}		
		}        
	}

	public Vector2 getPosition()
	{
		return this.GetComponent<Rigidbody2D>().position;
	}  			
}