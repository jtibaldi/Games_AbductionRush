using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public GameObject levelComponents;
    public Vector2 PlayerPosition;
    public bool gameOver = false;

    private float moveToX;
    private float speed = 1;
    private float bulletSpeed = 5;
    private int life = 3;
    private bool dead = false;

    private SpriteRenderer[] myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private bool wasHit = false;
    private float timeOfHit;
    private float shootFirstTime;
    private float shootSecondTime;
    private float shootThirdTime;
    private List<GameObject> bulletsOnScreen = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        myRenderer = gameObject.GetComponents<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    // Update is called once per frame
    public void tankUpdate()
    {
        shootFirstTime += Time.deltaTime;
        shootSecondTime += Time.deltaTime;
        shootThirdTime += Time.deltaTime;

        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, new Vector2(moveToX, transform.position.y), step);

        if (life <= 0)
        {
            dead = true;
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x - 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
        }
        if (wasHit)
        {
            timeOfHit += Time.deltaTime;
            if (timeOfHit > 0.08f)
            {
                normalSprite();
                wasHit = false;
                timeOfHit = 0;
            }
        }


        if (shootFirstTime > 3)
        {
            Vector2 direction = PlayerPosition - (Vector2)this.transform.position;
            direction.Normalize();
            GameObject bullet = Instantiate(levelComponents.GetComponent<LevelComponent>().enemyBullet, this.transform.position, GetComponent<Transform>().rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletsOnScreen.Add(bullet);
            shootFirstTime = 0;
        }
    }

    void whiteSprite()
    {
        myRenderer[0].material.shader = shaderGUItext;
        myRenderer[0].color = Color.white;
    }

    void normalSprite()
    {
        myRenderer[0].material.shader = shaderSpritesDefault;
        myRenderer[0].color = Color.white;
    }

    public void moveTo(float _moveToX)
    {
        moveToX = _moveToX;
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        Debug.Log("Collide");
        if (Collider.gameObject.tag == "bomb")
        {
            Destroy(Collider.gameObject);
            setLifeToCero();
            dead = true;
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x - 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
        }        
    }

    public void setPlayerPosition(Vector2 _PlayerPosition)
    {
        PlayerPosition = _PlayerPosition;
    }

    public bool isDead()
    {
        return dead;
    }

    public void setLifeToCero()
    {
        life = 0;
    }

    public void cleanEnemyBulletsFromScreen()
    {
        foreach (GameObject bullet in bulletsOnScreen)
        {
            try
            {
                Destroy(bullet.gameObject);
            }
            catch (MissingReferenceException e)
            {

            }
        }
        bulletsOnScreen.Clear();
    }
}