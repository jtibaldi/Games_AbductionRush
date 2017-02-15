using UnityEngine;
using System.Collections;

public class CompanyLogo : MonoBehaviour {
	private bool canFade;
	private Color alphaColor;
	private float timeToFade = 1.5f;

	// Use this for initialization
	void Start () {
		canFade = false;
		alphaColor = this.GetComponent<SpriteRenderer> ().material.color;
		alphaColor.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (canFade) 
		{
			this.GetComponent<SpriteRenderer> ().material.color = Color.Lerp (this.GetComponent<SpriteRenderer> ().material.color, alphaColor, timeToFade * Time.deltaTime);
		}
	}

	public void mustFade() 
	{
		canFade = true;
	}
}
