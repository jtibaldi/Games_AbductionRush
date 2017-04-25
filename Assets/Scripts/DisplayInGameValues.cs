using UnityEngine;
using UnityEngine.UI;

public class DisplayInGameValues : MonoBehaviour {
	Text lives;
    Text score;


	// Use this for initialization
	void Start () {
		Transform livesTransform = transform.Find("lives_quantity");
        Transform scoreTransform = transform.Find("points_quantity");
        lives = livesTransform.GetComponent<Text>();
        score = scoreTransform.GetComponent<Text>();        
    }
	
	// Update is called once per frame
	void Update () {		
		lives.text = Player.life.ToString ();
        score.text = LevelManager.animalPoints.ToString();
    }
}
