using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelManager levelScript;
	public enum GameState { InitializeLogoScreen, LogoScreen, InitializeTitleScreen, TitleScreen, InitializePlayerNameScreen, PlayerNameScreen, InitializeGameScreen, GameScreen, InitializeGameOver, GameOver }
	public GameObject canvas;
	public GameObject TitleScreenCanvas;
	//public GameObject PointsScreenCanvas;
	public GameObject PlayerNameScreenCanvas;
	public GameObject RankingScreenCanvas;
	AudioSource GameManagerAudio;
	bool rakingpass = false;

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
		RankingScreenCanvas.SetActive (false);
		PlayerNameScreenCanvas.SetActive (false);
		GameManagerAudio = GetComponent<AudioSource> ();
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
			GameManagerAudio.clip = Resources.Load<AudioClip> ("Music/ovniRushMenu");	
			GameManagerAudio.Play ();
			GameManagerAudio.loop = true;
			if (cameFromGame) 
			{
				levelScript.DestroyGameObjects();
				RankingScreenCanvas.SetActive (false);
				cameFromGame = false;
			}
			canvas.SetActive (false);		    
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
					GameManagerAudio.Stop ();
					GameManagerAudio.loop = false;
				}
			}
			break;
		case GameState.InitializePlayerNameScreen:
			PlayerNameScreenCanvas.SetActive (true);
			gameState = GameState.PlayerNameScreen;
			break;
		case GameState.PlayerNameScreen:
			if(Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) { //chequear nombre (text) para ver que no sea vacio
				Debug.Log("hello");
				rakingpass = true;
				gameState = GameState.InitializeGameOver;
			}
			break;
		case GameState.InitializeGameScreen:
			canvas.SetActive (true);
			LevelManager.animalPoints = 0;
			LevelManager.chopperPoints = 0;
			PlayerNameScreenCanvas.SetActive (false);
			RankingScreenCanvas.SetActive (false);
			TitleScreenCanvas.SetActive (false);
			levelScript.LevelSetup (); 
			gameState = GameState.GameScreen;
			break;
		case GameState.GameScreen:
			levelScript.levelUpdate ();
			break;	
		case GameState.InitializeGameOver:			
			GameManagerAudio.clip = Resources.Load<AudioClip> ("Music/ovniRushGameOver");	
			GameManagerAudio.Play ();
			canvas.SetActive (false);
			Player.life = 3;
			if (isInRanking() && !rakingpass) {
				gameState = GameState.InitializePlayerNameScreen;
			} else {
				gameState = GameState.GameOver;
				PlayerNameScreenCanvas.SetActive (false);
				RankingScreenCanvas.SetActive (true);
				rakingpass = false;
			}
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

	bool isInRanking() 
	{
		if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingTenPoints")) {
			return true;
		} else {
			return false;
		}	
	}

	void caculateRankingPosition() 
	{
		if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingTenPoints")) {
			if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingNinePoints")) {
				if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingEightPoints")) {
					if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingSevenPoints")) {
						if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingSixPoints")) {
							if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingFivePoints")) {
								if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingFourPoints")) {
									if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingThreePoints")) {
										if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingTwoPoints")) {
											if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingOnePoints")) {
												PlayerPrefs.SetInt ("RankingOnePoints", LevelManager.animalPoints);
											} else {
												PlayerPrefs.SetInt ("RankingTwoPoints", LevelManager.animalPoints);
											}
										} else {
											PlayerPrefs.SetInt ("RankingThreePoints", LevelManager.animalPoints);
										}
									} else {
										PlayerPrefs.SetInt ("RankingFourPoints", LevelManager.animalPoints);
									}
								} else {
									PlayerPrefs.SetInt ("RankingFivePoints", LevelManager.animalPoints);
								}
							} else {
								PlayerPrefs.SetInt ("RankingSixPoints", LevelManager.animalPoints);
							}
						} else {
							PlayerPrefs.SetInt ("RankingSevenPoints", LevelManager.animalPoints);
						}
					} else {
						PlayerPrefs.SetInt ("RankingEightPoints", LevelManager.animalPoints);
					}			
				}else{
					PlayerPrefs.SetInt ("RankingNinePoints", LevelManager.animalPoints);
				}
			}else{
				PlayerPrefs.SetInt ("RankingTenPoints", LevelManager.animalPoints);
			}
		}
	}
}
