using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {	
	public GameObject levelComponents;
	public Vector2 PlayerPosition;

	private float moveToX;
	private float speed = 1;
	private float bulletSpeed = 5;
	private int life = 100;

	private SpriteRenderer[] myRenderer;
	private Shader shaderGUItext;
	private Shader shaderSpritesDefault;
	private bool wasHit = false;
	private float timeOfHit;
	private float shootFirstTime;
	private float shootSecondTime;
	private float shootThirdTime;


	// Use this for initialization
	void Start () {
		myRenderer = gameObject.GetComponents<SpriteRenderer> ();
		shaderGUItext = Shader.Find("GUI/Text Shader");
		shaderSpritesDefault = Shader.Find("Sprites/Default");
	}
	
	// Update is called once per frame
	void Update () {		
		shootFirstTime += Time.deltaTime;
		shootSecondTime += Time.deltaTime;
		shootThirdTime += Time.deltaTime; 

		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, new Vector2(moveToX,transform.position.y), step);			

		if (life <= 0) 
		{
			Destroy (gameObject);
			Instantiate(levelComponents.GetComponent<LevelComponent> ().explosionPrefab, new Vector2(this.transform.position.x-0.2f, this.transform.position.y), GetComponent<Transform> ().rotation); 
			Instantiate(levelComponents.GetComponent<LevelComponent> ().explosionPrefab,  new Vector2(this.transform.position.x+0.2f, this.transform.position.y), GetComponent<Transform> ().rotation); 
		}
		if (wasHit) 
		{
			timeOfHit += Time.deltaTime;
			if (timeOfHit > 0.08f) {
				normalSprite();
				wasHit = false;
				timeOfHit = 0;
			}
		}


		if (shootFirstTime > 3) {			
			Vector2 direction = PlayerPosition - (Vector2)this.transform.position;
			direction.Normalize ();
			GameObject bullet = Instantiate (levelComponents.GetComponent<LevelComponent> ().enemyBullet, this.transform.position, GetComponent<Transform> ().rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			shootFirstTime = 0;
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

	public void moveTo(float _moveToX) 
	{		
		moveToX = _moveToX;
	}

	void OnTriggerEnter2D(Collider2D Collider)
	{
		if (Collider.gameObject.tag == "bullet") {									
			whiteSprite ();
			life -= 30;
			wasHit = true;
		}
	}

	public void setPlayerPosition(Vector2 _PlayerPosition) 
	{
		PlayerPosition = _PlayerPosition; 
	}
}
