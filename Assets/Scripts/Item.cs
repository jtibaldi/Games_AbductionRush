using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool goUp = true;
    private bool goLeft = true;

    // Use this for initialization
    void Start()
    {
        if (transform.position.x > 0)
        {
            goLeft = true;
        }
        else
        {
            goLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 2)
        {
            goUp = false;
        }
        if (this.transform.position.y < 1.2f)
        {
            goUp = true;
        }
        if (goUp)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f * Time.deltaTime);
        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.5f * Time.deltaTime);
        }
        if (goLeft)
        {
            this.transform.position = new Vector2(this.transform.position.x - 1.3f * Time.deltaTime, this.transform.position.y);
        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x + 1.3f * Time.deltaTime, this.transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag != "enemybullet" && Collider.gameObject.tag != "Enemy" && Collider.gameObject.tag != "bullet")
        {
            Destroy(this.gameObject);
        }
    }
}