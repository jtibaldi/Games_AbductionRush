using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	public AudioClip sound;
	AudioSource EnemyBulletAudio;

	// Use this for initialization
	void Start () {
		EnemyBulletAudio = GetComponent<AudioSource>();	
		EnemyBulletAudio.PlayOneShot(sound, 0.7F);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D Collider)
	{
		
	}

	void OnBecameInvisible() 
	{
		Destroy (gameObject);	
	}
}
