using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RankPos
{
    int score;
    string name;

    public RankPos(int _score, string _name)
    {
        score = _score;
        name = _name;
    }

    public void setScore(int _score)
    {
        score = _score;
    }

    public void setName(string _name)
    {
        _name = name;
    }

    public int getScore()
    {
        return score;
    }

    public string getName()
    {
        return name;
    }
}

public class GameManager : MonoBehaviour {
	public LevelManager levelScript;
	public enum GameState { InitializeLogoScreen, LogoScreen, InitializeTitleScreen, TitleScreen, InitializePlayerNameScreen, PlayerNameScreen, InitializeGameScreen, GameScreen, InitializeGameOver, GameOver }
	public GameObject canvas;
	public GameObject TitleScreenCanvas;
	public GameObject PlayerNameScreenCanvas;
	public GameObject RankingScreenCanvas;
    
    private List<RankPos> ranking = new List<RankPos>();    
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
	void FixedUpdate () {
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
			ranking.Clear ();
			if (PlayerPrefs.GetString ("RankingOneName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingOneScore"), "EMPTY")); }
			else {ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingOneScore"), PlayerPrefs.GetString ("RankingOneName")));}
			if (PlayerPrefs.GetString ("RankingTwoName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingTwoScore"), "EMPTY")); }
			else {ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingTwoScore"), PlayerPrefs.GetString("RankingTwoName")));}
			if (PlayerPrefs.GetString ("RankingThreeName") == "") {	ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingThreeScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingThreeScore"), PlayerPrefs.GetString("RankingThreeName"))); }
			if (PlayerPrefs.GetString ("RankingFourName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingFourScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingFourScore"), PlayerPrefs.GetString("RankingFourName"))); }
			if (PlayerPrefs.GetString ("RankingFiveName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingFiveScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingFiveScore"), PlayerPrefs.GetString("RankingFiveName"))); }
			if (PlayerPrefs.GetString ("RankingSixName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingSixScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingSixScore"), PlayerPrefs.GetString("RankingSixName"))); }
			if (PlayerPrefs.GetString ("RankingSevenName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingSevenScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingSevenScore"), PlayerPrefs.GetString("RankingSevenName"))); }
			if (PlayerPrefs.GetString ("RankingEightName") == "") {	ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingEightScore"), "EMPTY")); }
			else { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingEightScore"), PlayerPrefs.GetString ("RankingEightName"))); }
			if (PlayerPrefs.GetString ("RankingNineName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingNineScore"), "EMPTY")); }
			else { ranking.Add(new RankPos(PlayerPrefs.GetInt("RankingNineScore"), PlayerPrefs.GetString("RankingNineName"))); }
			if (PlayerPrefs.GetString ("RankingTenName") == "") { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingTenScore"), "EMPTY")); }
			else { ranking.Add (new RankPos (PlayerPrefs.GetInt ("RankingTenScore"), PlayerPrefs.GetString ("RankingTenName"))); } 
			PlayerNameScreenCanvas.SetActive (true);
			gameState = GameState.PlayerNameScreen;
			break;
		case GameState.PlayerNameScreen:
			if(Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) { //chequear nombre (text) para ver que no sea vacio				                    				  
					rakingpass = true;
                    Transform playerNameTransform = PlayerNameScreenCanvas.transform.Find("PlayerName");
                    Text playerName = playerNameTransform.GetComponent<Text>();
                    ranking.Add(new RankPos(LevelManager.animalPoints, playerName.text));                                        
                    ranking.Sort((x, y) => y.getScore().CompareTo(x.getScore()));                    
                    ranking.RemoveAt(ranking.Count - 1);
					playerName.text = "";
                    PlayerPrefs.SetInt("RankingOneScore", ranking[0].getScore());
                    PlayerPrefs.SetString("RankingOneName", ranking[0].getName());
                    PlayerPrefs.SetInt("RankingTwoScore", ranking[1].getScore());
                    PlayerPrefs.SetString("RankingTwoName", ranking[1].getName());
                    PlayerPrefs.SetInt("RankingThreeScore", ranking[2].getScore());
                    PlayerPrefs.SetString("RankingThreeName", ranking[2].getName());
                    PlayerPrefs.SetInt("RankingFourScore", ranking[3].getScore());
                    PlayerPrefs.SetString("RankingFourName", ranking[3].getName());
                    PlayerPrefs.SetInt("RankingFiveScore", ranking[4].getScore());
                    PlayerPrefs.SetString("RankingFiveName", ranking[4].getName());
                    PlayerPrefs.SetInt("RankingSixScore", ranking[5].getScore());
                    PlayerPrefs.SetString("RankingSixName", ranking[5].getName());
                    PlayerPrefs.SetInt("RankingSevenScore", ranking[6].getScore());
                    PlayerPrefs.SetString("RankingSevenName", ranking[6].getName());
                    PlayerPrefs.SetInt("RankingEightScore", ranking[7].getScore());
                    PlayerPrefs.SetString("RankingEightName", ranking[7].getName());
                    PlayerPrefs.SetInt("RankingNineScore", ranking[8].getScore());
                    PlayerPrefs.SetString("RankingNineName", ranking[8].getName());
                    PlayerPrefs.SetInt("RankingTenScore", ranking[9].getScore());
                    PlayerPrefs.SetString("RankingTenName", ranking[9].getName());                    
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
				RankingScreenCanvas.GetComponent<DisplayRanking> ().UpdateRanking();
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
		if (LevelManager.animalPoints > PlayerPrefs.GetInt ("RankingTenScore")) {
			return true;
		} else {
			return false;
		}	
	}
}