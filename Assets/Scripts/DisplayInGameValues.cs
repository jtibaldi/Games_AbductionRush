using UnityEngine;
using UnityEngine.UI;

public class DisplayInGameValues : MonoBehaviour {
	Text lives;
    Text bombs;
    Text score;


	// Use this for initialization
	void Start () {
		Transform livesTransform = transform.Find("lives_quantity");
        Transform bombsTransform = transform.Find("bomb_quantity");
        Transform scoreTransform = transform.Find("points_quantity");
        lives = livesTransform.GetComponent<Text>();
        score = scoreTransform.GetComponent<Text>();
        bombs = bombsTransform.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {		
		lives.text = Player.life.ToString ();
        bombs.text = Player.bombs.ToString();
        score.text = LevelManager.animalPoints.ToString();
    }
}
