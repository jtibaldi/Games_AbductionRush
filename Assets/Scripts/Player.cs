using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int selectedController;
	bool playerIsGone = false;
	public GameObject levelComponents;

	public float moveSentivity = 0.20f;
	public float speed;
	public static int life = 3;
	float fireDelay = 0.15f;
	float coolDownTimerFire = 0;
	float crossHairBoundaryRadius = 0.5f;
	float moveX;
	float moveY;
	private SpriteRenderer[] myRenderer;
	private Shader shaderGUItext;
	private Shader shaderSpritesDefault;
	private bool wasHit = false;
	private bool controlsEnable = true;
	private float timeOfHit;

	public GameObject bulletRightPrefab;
	public GameObject bulletLeftPrefab;
	public GameObject abductionrayPrefab;
	GameObject abductionray;

	// Use this for initialization
	void Start () {		
		myRenderer = gameObject.GetComponents<SpriteRenderer> ();
		shaderGUItext = Shader.Find("GUI/Text Shader");
		shaderSpritesDefault = Shader.Find("Sprites/Default");
		selectedController = Constants.KEYBOARD_CONTROL;
		abductionray = Instantiate(abductionrayPrefab, new Vector2(1.55f, 1.7f), GetComponent<Transform>().rotation) as GameObject;
		abductionray.GetComponent<Renderer> ().enabled = false;
	}

	public void playerUpdate () {
		Vector3 posP1 = GetComponent<Transform> ().position;
		Vector3 posP2 = abductionray.GetComponent<Transform> ().position;

		float screenRatio = 16.0f / 9.0f;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		if (controlsEnable) {
			if (posP1.x + crossHairBoundaryRadius >= widthOrtho) {
				posP1.x = widthOrtho - crossHairBoundaryRadius;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, this.GetComponent<Rigidbody2D> ().velocity.y);
			}
			if (posP1.x - crossHairBoundaryRadius <= -widthOrtho) {
				posP1.x = -widthOrtho + crossHairBoundaryRadius;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, this.GetComponent<Rigidbody2D> ().velocity.y);
			}
			if (posP1.y >= (Camera.main.orthographicSize - 0.3f)) {
				posP1.y = Camera.main.orthographicSize - 0.3f;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, 0);
			}
			if (posP1.y <= (-Camera.main.orthographicSize + 4.4f)) {
				abductionray.GetComponent<AudioSource> ().Play ();
				abductionray.GetComponent<Renderer> ().enabled = true;
				posP1.y = -Camera.main.orthographicSize + 4.4f;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, 0);
			} else {
				abductionray.GetComponent<AudioSource> ().Stop ();
				abductionray.GetComponent<Renderer> ().enabled = false;
			}
		}
		if (posP2.x + crossHairBoundaryRadius >= widthOrtho) {
			posP2.x = widthOrtho - crossHairBoundaryRadius;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, abductionray.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP2.x - crossHairBoundaryRadius <= -widthOrtho) {
			posP2.x = -widthOrtho + crossHairBoundaryRadius;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, abductionray.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (posP2.y >= (Camera.main.orthographicSize - 1.8f)) {
			posP2.y = Camera.main.orthographicSize - 1.8f;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2 (abductionray.GetComponent<Rigidbody2D> ().velocity.x, 0);
		}
		if (posP2.y <= (-Camera.main.orthographicSize + 2.2f)) {
			posP2.y = -Camera.main.orthographicSize + 2.2f;
			abductionray.GetComponent<Rigidbody2D> ().velocity = new Vector2 (abductionray.GetComponent<Rigidbody2D> ().velocity.x, 0);
		}
		GetComponent<Transform> ().position = posP1;
		abductionray.GetComponent<Transform> ().position = posP2;
		if (wasHit) {
			timeOfHit += Time.deltaTime;
			if (timeOfHit > 0.08f) {
				normalSprite ();
				wasHit = false;
				timeOfHit = 0;
			}
		}
		if (life <= 0) {			
			Destroy (abductionray.gameObject);
			Instantiate (levelComponents.GetComponent<LevelComponent> ().explosionPrefab, new Vector2 (this.transform.position.x - 0.2f, this.transform.position.y), GetComponent<Transform> ().rotation); 
			Instantiate (levelComponents.GetComponent<LevelComponent> ().explosionPrefab, new Vector2 (this.transform.position.x + 0.2f, this.transform.position.y), GetComponent<Transform> ().rotation); 
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		abductionray.GetComponent<Transform> ().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y - 2.1f); 
		abductionray.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D>().velocity; 
		if (controlsEnable) {
			switch (selectedController) {
			case Constants.KEYBOARD_CONTROL:
				{
					coolDownTimerFire -= Time.deltaTime;
					if (Input.GetKey (KeyCode.RightArrow)) {
						if (!this.GetComponent<AudioSource> ().isPlaying) {
							this.GetComponent<AudioSource> ().Play ();
						}
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x + moveSentivity, this.GetComponent<Rigidbody2D> ().velocity.y);
					} 
					if (Input.GetKey (KeyCode.LeftArrow)) {
						if (!this.GetComponent<AudioSource> ().isPlaying) {
							this.GetComponent<AudioSource> ().Play ();
						}
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x - moveSentivity, this.GetComponent<Rigidbody2D> ().velocity.y);
					}
					if (Input.GetKey (KeyCode.UpArrow)) {
						if (!this.GetComponent<AudioSource> ().isPlaying) {
							this.GetComponent<AudioSource> ().Play ();
						}
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, this.GetComponent<Rigidbody2D> ().velocity.y + moveSentivity);
					}
					if (Input.GetKey (KeyCode.DownArrow)) {
						if (!this.GetComponent<AudioSource> ().isPlaying) {
							this.GetComponent<AudioSource> ().Play ();
						}
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, this.GetComponent<Rigidbody2D> ().velocity.y - moveSentivity);
					} 
					if (Input.GetKey (KeyCode.Z) && coolDownTimerFire <= 0) {
						coolDownTimerFire = fireDelay;
						Instantiate (bulletLeftPrefab, this.transform.position, GetComponent<Transform> ().rotation);
					}
					if (Input.GetKey (KeyCode.X) && coolDownTimerFire <= 0) {
						coolDownTimerFire = fireDelay;
						Instantiate (bulletRightPrefab, this.transform.position, GetComponent<Transform> ().rotation);
					}
					break;
				}
			case Constants.PAD_CONTROL:
				{
					moveX = Input.GetAxis ("Horizontal");
					moveY = Input.GetAxis ("Vertical");
					if (moveX > 0.5) {
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, this.GetComponent<Rigidbody2D> ().velocity.y);
					} else if (moveX < -0.5) {
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, this.GetComponent<Rigidbody2D> ().velocity.y);
					} else if (moveY > 0.5) {
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, -moveY * speed);
					} else if (moveY < -0.5) {
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, -moveY * speed);
					}
					if (moveX > -0.5 && moveX < 0.5) {                        
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, this.GetComponent<Rigidbody2D> ().velocity.y);
					}
					if (moveY > -0.5 && moveY < 0.5) {                        
						this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, 0);
					}
					break;
				}		
			} 
		}
	}

	void whiteSprite() {
		myRenderer[0].material.shader = shaderGUItext;
		myRenderer[0].color = Color.white;
	}

	void normalSprite() {
		myRenderer[0].material.shader = shaderSpritesDefault;
		myRenderer[0].color = Color.white;
	}

	public Vector2 getPosition()
	{
		//return this.GetComponent<Rigidbody2D>().position;
		return this.transform.position;
	}

	void OnTriggerEnter2D(Collider2D Collider)
	{
		if (Collider.gameObject.tag == "enemybullet") {									
			Destroy (Collider.gameObject);
			whiteSprite ();
			life -= 1;
			wasHit = true;
		}
	}

	void OnBecameInvisible() 
	{
		playerIsGone = true;
	}

	void OnTriggerStay2D(Collider2D Collider) 
	{	
		if (Collider.gameObject.tag == "Enemy") 
		{
			whiteSprite ();
			life -= 1;
			wasHit = true;
		}
	}

	public bool isDead() 
	{
		if (life <= 0) {
			return true;
		} else {
			return false;
		}
	}

	public GameObject getAbductionRay() 
	{
		return abductionray;
	}

	public bool isPlayerGone() 
	{
		return playerIsGone;
	}

	public void disableControls() 
	{
		controlsEnable = false;
	}

	public void enableControls() 
	{
		controlsEnable = true;
	}
}