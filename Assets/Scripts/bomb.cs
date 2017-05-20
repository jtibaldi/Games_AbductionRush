using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
    public GameObject levelComponents;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().position = new Vector2(this.GetComponent<Rigidbody2D>().position.x, this.GetComponent<Rigidbody2D>().position.y - 8f * Time.deltaTime);
        if (this.GetComponent<Rigidbody2D>().position.y <= -4.7)
        {
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x - 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
            Instantiate(levelComponents.GetComponent<LevelComponent>().explosionPrefab, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y), GetComponent<Transform>().rotation);
            Destroy(this.gameObject);
        }
    }
}
