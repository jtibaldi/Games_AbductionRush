using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelManager levelScript;
	public enum GameState { InitializeLogoScreen, LogoScreen, InitializeTitleScreen, TitleScreen, InitializeGameScreen, GameScreen, InitializeGameOver, GameOver }
	public GameObject canvas;
	public GameObject TitleScreenCanvas;
	public GameObject PointsScreenCanvas;

	float timer = 0;
	float fadeTimer = 0;
	float timerBlink = 0;
	bool fadeTitleScreen =false;

	public GameObject companyLogoPrefab;
	GameObject companyLogo;

	public GameObject titlePrefab;
	GameObject title;

	bool cameFromGame = false;

	public static GameState gameState;
	// Use this for initialization
	void Awake () {
		levelScript = GetComponent<LevelManager> ();
		Cursor.visible = false;
		PlayerPrefs.SetInt ("CurrentScore", 0);
		gameState = GameState.InitializeLogoScreen;
		PointsScreenCanvas.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		switch (gameState) {
		case GameState.InitializeLogoScreen:
			canvas.SetActive (false);
			TitleScreenCanvas.SetActive (false);
			companyLogo = Instantiate (companyLogoPrefab, new Vector2 (0, 0), GetComponent<Transform> ().rotation) as GameObject;
			gameState = GameState.LogoScreen;
			break;
		case GameState.LogoScreen:
			timer += Time.deltaTime;
			if (timer > 3) {
				fadeTimer += Time.deltaTime;
				companyLogo.GetComponent<CompanyLogo>().mustFade();
				if (fadeTimer > 2) 
				{
					Destroy (companyLogo.gameObject);
					gameState = GameState.InitializeTitleScreen;
					fadeTimer = 0;
				}
			}
			break;
		case GameState.InitializeTitleScreen:
			if (cameFromGame) 
			{
				levelScript.DestroyGameObjects();
				cameFromGame = false;
			}
			canvas.SetActive (false);
			PointsScreenCanvas.SetActive (false);
			TitleScreenCanvas.SetActive (true);
			title = Instantiate (titlePrefab, new Vector2 (0, 0), GetComponent<Transform> ().rotation) as GameObject;
			gameState = GameState.TitleScreen;
			break;
		case GameState.TitleScreen:						
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.Escape)) {
					Application.Quit();
				} else {
					fadeTitleScreen = true;	
					TitleScreenCanvas.SetActive (false);
				}		
			}
			if (!fadeTitleScreen) 
			{
				timerBlink += Time.deltaTime;
				if (timerBlink > 1) {
					TitleScreenCanvas.SetActive (true);
					if (timerBlink > 2) 
					{
						timerBlink = 0;
					}
				} else 
				{
					TitleScreenCanvas.SetActive (false);
				}
			}


			if (fadeTitleScreen) {
				fadeTimer += Time.deltaTime;
				title.GetComponent<titleScreen> ().mustFade ();
				if (fadeTimer > 2) {
					Destroy (title.gameObject);
					gameState = GameState.InitializeGameScreen;
					fadeTimer = 0;
					fadeTitleScreen = false;
				}
			}
			break;
		case GameState.InitializeGameScreen:
			canvas.SetActive (true);
			LevelManager.animalPoints = 0;
			LevelManager.chopperPoints = 0;
			PointsScreenCanvas.SetActive (false);
			TitleScreenCanvas.SetActive (false);
			levelScript.LevelSetup (); 
			gameState = GameState.GameScreen;
			break;
		case GameState.GameScreen:
			levelScript.levelUpdate ();
			break;	
		case GameState.InitializeGameOver:
			canvas.SetActive (false);
			Player.life = 3;
			PointsScreenCanvas.SetActive (true);
			gameState = GameState.GameOver;
			break;
		case GameState.GameOver:
			if (Input.GetKeyDown (KeyCode.Escape)) {
				cameFromGame = true;
				gameState = GameState.InitializeTitleScreen;
			}
			if(Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
				gameState = GameState.InitializeGameScreen;
			}		
			break;
		}
	}

	public void setState(GameState state) 
	{
		gameState = state;
	}
}
