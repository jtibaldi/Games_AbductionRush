using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour {
	public static int animalPoints = 0;
	public static int chopperPoints = 0;
    public enum LevelState { Respawn, Running, CompletePreparation, Complete, Pause, GameOver, Exit }
    public static LevelState levelState;

    public GameObject Player;
	public GameObject backgroundPrefab;
	public GameObject levelComponents;
	public GameObject background;
	public GameObject foreground;
    public GameObject actionText;
	private List<EnhacedPosition> animalSpawnPoints = new List<EnhacedPosition> ();
	private List<EnhacedPosition> enemySpawnPoints = new List<EnhacedPosition> ();
	private int levelConstructor;
	private int currentLevel;
	private float lastEnemy;
	private bool animalSpawnSuccessfully = true;
	private bool enemySpawnSuccessfully = true;
	private bool playerIsDead;
	private bool isLevelCompleted;

	private float enemySpawnTime = 10.0f;
	private Color alphaColor;
	private float timeToFade = 1.5f;
	private float fadeTimer = 0;
    private float actionTimer = 0;
    private bool createPlayerOnce = false;
    private bool updateEnemiesOnLastTime = false;


	public void LevelSetup() 
	{		
		levelConstructor = 1;
		currentLevel = 1;
		createLevel ();
		InvokeRepeating ("increaseLevel", 90, 90); //Poner en 180 una vez probado el cambio de nivel
		InvokeRepeating ("spawnAnimal", 0, 5);
		InvokeRepeating ("spawnEnemy", 2, enemySpawnTime);
        levelState = LevelState.Respawn;
		//Set Animals Spawn Points
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-8f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-7f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-6f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-5f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-4f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-3f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-2f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(-1f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(0f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(1f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(2f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(3f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(4f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(5f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(6f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(7f,-4.4f),true));
		animalSpawnPoints.Add (new EnhacedPosition(new Vector2(8f,-4.4f),true));
		//Set Enemies Spawn Points (Destination) 
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-7f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-4.5f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-2f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-7f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-4.5f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-2f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-7f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-4.5f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-2f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-7f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-4.5f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-2f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-7f,0.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-4.5f,0.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(-2f,0.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(7f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(4.5f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(2f,4.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(7f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(4.5f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(2f,3.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(7f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(4.5f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(2f,2.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(7f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(4.5f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(2f,1.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(7f,0.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(4.5f,0.3f), true));
		enemySpawnPoints.Add(new EnhacedPosition(new Vector2(2f,0.3f), true));
		//Player = Instantiate(levelComponents.GetComponent<LevelComponent> ().player, new Vector2(0,0), GetComponent<Transform> ().rotation) as GameObject;
	}

	public void levelUpdate() 
	{
        Debug.Log(levelState);
        switch (levelState) {
        case LevelState.Respawn:
                {
                    if (!updateEnemiesOnLastTime)
                    {
                        foreach (EnhacedPosition pos in enemySpawnPoints)
                        {
                            try
                            {
                                if (pos.getCurrentGameObject() != null)
                                {
                                    pos.getCurrentGameObject().GetComponent<Enemy>().enemyUpdate();
                                    if (pos.getCurrentGameObject().GetComponent<Enemy>().isDead())
                                    {
                                        pos.setAvailability(true);
                                        Destroy(pos.getCurrentGameObject());
                                    }
                                    pos.getCurrentGameObject().GetComponent<Enemy>().setPlayerPosition(Player.transform.position);
                                }
                            }
                            catch (NullReferenceException e)
                            {

                            }
                        }
                        updateEnemiesOnLastTime = true;
                    }
                    actionTimer += Time.deltaTime;
                    CancelInvoke("spawnEnemy");
                    CancelInvoke("increaseLevel");
                    CancelInvoke("spawnAnimal");
                    if (actionTimer > 0 && actionTimer < 1)
                    {
                        actionText.SetActive(true);
                        actionText.GetComponent<UnityEngine.UI.Text>().text = "3";
                    }
                    if (actionTimer > 1 && actionTimer < 2)
                    {
                        actionText.GetComponent<UnityEngine.UI.Text>().text = "2";
                    }
                    if (actionTimer > 2 && actionTimer < 3)
                    {
                        actionText.GetComponent<UnityEngine.UI.Text>().text = "1";
                    }
                    if (actionTimer > 3 && actionTimer < 4)
                    {
                        if (!createPlayerOnce)
                        {
                            Player = Instantiate(levelComponents.GetComponent<LevelComponent>().player, new Vector2(0, 0), GetComponent<Transform>().rotation) as GameObject;
                            createPlayerOnce = true;
                        }
                        actionText.GetComponent<UnityEngine.UI.Text>().text = "ACTION!";
                    }
                    if (actionTimer > 4 && actionTimer < 6)
                    {
                        actionText.SetActive(false);
                        actionTimer = 0;
                        InvokeRepeating("increaseLevel", 90, 90); //Poner en 180 una vez probado el cambio de nivel
                        InvokeRepeating("spawnAnimal", 0, 5);
                        InvokeRepeating("spawnEnemy", 2, enemySpawnTime);
                        levelState = LevelState.Running;
                        createPlayerOnce = false;
                        updateEnemiesOnLastTime = true;
                    }
                }
                
                break;

		case LevelState.Running:
			{					
				foreach (EnhacedPosition pos in animalSpawnPoints) {					
					try {
						if (pos.getCurrentGameObject () != null) {	
							pos.getCurrentGameObject ().GetComponent<Animal> ().animalUpdate ();   ///aca esta el error 
							if (pos.getCurrentGameObject ().GetComponent<Animal> ().isDead ()) {												
								pos.setAvailability (true);
								Destroy (pos.getCurrentGameObject ());
							}
						}					
					}catch(NullReferenceException e) 
					{
						
					}
				}

				foreach (EnhacedPosition pos in enemySpawnPoints) {					
					try {
						if (pos.getCurrentGameObject () != null) {	
							pos.getCurrentGameObject ().GetComponent<Enemy> ().enemyUpdate ();
							if (pos.getCurrentGameObject ().GetComponent<Enemy> ().isDead ()) {
								pos.setAvailability (true);
								Destroy (pos.getCurrentGameObject ());
							}
							pos.getCurrentGameObject ().GetComponent<Enemy> ().setPlayerPosition (Player.transform.position);
						}
					}catch(NullReferenceException e) 
					{
					
					}
				}
				Player.GetComponent<Player> ().playerUpdate ();                                
				if (Player.GetComponent<Player> ().isDead () || Input.GetKeyDown(KeyCode.Escape)) {
					Player.GetComponent<Player> ().getAbductionRay ().GetComponent<AudioSource> ().Stop();
					Player.GetComponent<AudioSource> ().Stop ();
					Destroy (Player.GetComponent<Player> ().getAbductionRay ().gameObject);
					Destroy (Player.gameObject);
					levelState = LevelState.GameOver;
					CancelInvoke ("spawnEnemy");
					CancelInvoke ("increaseLevel");
					CancelInvoke ("spawnAnimal");
					foreach (EnhacedPosition pos in enemySpawnPoints) 
					{
						if (pos.getCurrentGameObject () != null) {
							pos.getCurrentGameObject ().GetComponent<AudioSource> ().Stop ();						
							Destroy (pos.getCurrentGameObject ());
						}
					}
					foreach (EnhacedPosition pos in animalSpawnPoints) 
					{
						Destroy (pos.getCurrentGameObject ());
					}
					enemySpawnPoints.Clear ();
					animalSpawnPoints.Clear ();	
					enemySpawnTime = 10.0f;
					GameManager.gameState = GameManager.GameState.InitializeGameOver;
				}
				if (!animalSpawnSuccessfully) {
					spawnAnimal ();
				}

				if (!enemySpawnSuccessfully) {
					spawnEnemy ();
				}
			}
			break;
		case LevelState.CompletePreparation:						
			foreach (EnhacedPosition pos in enemySpawnPoints) {
				if (pos.getCurrentGameObject () != null) {
					pos.getCurrentGameObject ().GetComponent<Enemy> ().setLifeToCero ();
					pos.getCurrentGameObject ().GetComponent<Enemy> ().cleanEnemyBulletsFromScreen (); 
					pos.getCurrentGameObject ().GetComponent<Enemy> ().enemyUpdate ();
					if (pos.getCurrentGameObject ().GetComponent<Enemy> ().isDead ()) {
						pos.setAvailability (true);
						Destroy (pos.getCurrentGameObject ());
					}
				}
			}
			foreach (EnhacedPosition pos in animalSpawnPoints) {
				if (pos.getCurrentGameObject () != null) {					
					pos.setAvailability (true);
					Destroy (pos.getCurrentGameObject ());
				}
			}
			Player.GetComponent<Player> ().cleanFriendlyBulletsFromScreen ();
			Player.GetComponent<Player> ().disableControls ();
			Player.GetComponent<Player> ().getAbductionRay ().GetComponent<Renderer>().enabled = false;
			Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 150 * Time.deltaTime);
			levelState = LevelState.Complete;					
			break;
		case LevelState.Complete: 			 
			Player.GetComponent<Player> ().playerUpdate ();
			if (Player.GetComponent<Player> ().isPlayerGone()) 
			{	
				createLevel ();
				CancelInvoke ("increaseLevel");
				InvokeRepeating ("increaseLevel", 90, 90);
				Player.GetComponent<Player> ().enableControls ();
				Player.GetComponent<Rigidbody2D> ().position = new Vector2 (0, 0);
				Player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				Player.GetComponent<Player> ().setPlayerNotGone ();
				levelState = LevelState.Running;			
			}
			break;
		case LevelState.Pause:
			break;
		case LevelState.GameOver:			
			break;
		}
	}

	public int selectRandomPosition(List<EnhacedPosition> positions) 
	{		
		System.Random rnd = new System.Random();
		int randomPositionIndex = rnd.Next (0, positions.Count - 1);
		return randomPositionIndex;
	}

	public int selectRandomSpawnAnimal () 
	{
		System.Random rnd = new System.Random();
		return(rnd.Next (1, 5));
	}

	void spawnAnimal() 
	{		
		animalSpawnSuccessfully = true;
		int pos = selectRandomPosition (animalSpawnPoints);
		if (animalSpawnPoints [pos].isAvailable ()) {
			switch (levelConstructor) {
			case 1:	//Wood
				switch (selectRandomSpawnAnimal ()) {
				case Constants.SPAWNANIMAL1:			
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().rabbitPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL2:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().wolfPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL3:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().deerPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL4:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().bearPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				}
				break;
			case 2:	//Farm
				switch (selectRandomSpawnAnimal ()) {
				case Constants.SPAWNANIMAL1:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().duckPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL2:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().sheepPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL3:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().cowPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL4:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().horsePrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				}
				break;
			case 3: //Desert
				switch (selectRandomSpawnAnimal ()) {
				case Constants.SPAWNANIMAL1:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().snakePrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL2:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().foxPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL3:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().antelopePrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL4:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().jaguarPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				}
				break;
			case 4: //Artic
				switch (selectRandomSpawnAnimal ()) {
				case Constants.SPAWNANIMAL1:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().penguinPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL2:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().whiteWolfPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL3:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().reindeerPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
					animalSpawnPoints [pos].setAvailability (false);
					break;
				case Constants.SPAWNANIMAL4:									
					animalSpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().reindeerPrefab, animalSpawnPoints [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject); 
					animalSpawnPoints [pos].setAvailability (false);
					break;
				}
				break;
			}
		} else 
		{
			animalSpawnSuccessfully = false;
		}
	} 

	void spawnEnemy() 
	{		
		enemySpawnSuccessfully = true;
		int pos = selectRandomPosition (enemySpawnPoints);
		if (enemySpawnPoints [pos].isAvailable ()) 
		{
			float posX;
			if (enemySpawnPoints [pos].getPosition ().x < 0) 
			{
				posX = -9.8f;
				enemySpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().chopperLeftPrefab, new Vector2(posX, enemySpawnPoints [pos].getPosition ().y), GetComponent<Transform> ().rotation) as GameObject); 
			}
			else 
			{
				posX = 9.8f;
				enemySpawnPoints [pos].setCurrentGameObject (Instantiate (levelComponents.GetComponent<LevelComponent> ().chopperRightPrefab, new Vector2(posX, enemySpawnPoints [pos].getPosition ().y), GetComponent<Transform> ().rotation) as GameObject); 
			}
			enemySpawnPoints [pos].getCurrentGameObject().GetComponent<Enemy>().moveTo (enemySpawnPoints [pos].getPosition ().x);		
			enemySpawnPoints [pos].setAvailability (false);
		} 
		else 
		{
			enemySpawnSuccessfully = false;
		}
	}

	public void createLevel() 
	{		
		switch (levelConstructor) {
		case 1:
			Destroy (background);
			background = Instantiate(levelComponents.GetComponent<LevelComponent> ().forestBackgroundPrefab, new Vector2(0,0), GetComponent<Transform> ().rotation) as GameObject;
			break;
		case 2:
			Destroy (background);
			background = Instantiate(levelComponents.GetComponent<LevelComponent> ().farmBackgroundPrefab, new Vector2(0,0), GetComponent<Transform> ().rotation) as GameObject;
			break;
		case 3:
			Destroy (background);
			background = Instantiate(levelComponents.GetComponent<LevelComponent> ().desertBackgroundPrefab, new Vector2(0,0), GetComponent<Transform> ().rotation) as GameObject;
			break;
		case 4:
			Destroy (background);
			background = Instantiate(levelComponents.GetComponent<LevelComponent> ().articBackgroundPrefab, new Vector2(0,0), GetComponent<Transform> ().rotation) as GameObject;
			break;
		}
	}

	public void increaseLevel() 
	{	
		levelState = LevelState.CompletePreparation;	
		if (levelConstructor == 4) {
			levelConstructor = 1;
		} else {
			levelConstructor++;
		}
		currentLevel++;
		CancelInvoke ("spawnEnemy");
		if (enemySpawnTime > 1) {
			enemySpawnTime -= 1;
		} else {
			enemySpawnTime = 1;
		}
		InvokeRepeating ("spawnEnemy", 2, enemySpawnTime); 
	}

	public void DestroyGameObjects()
	{
		Destroy(background.gameObject);

	}
}

public class EnhacedPosition 
{
	Vector2 position;
	bool available;
	GameObject gameObject;

	public EnhacedPosition(Vector2 _position, bool _available) 
	{		
		position = _position;
		available = _available;
	}

	public bool isAvailable() 
	{
		return available;
	}

	public Vector2 getPosition() 
	{
		return position;
	}

	public void setPosition(Vector2 _position) 
	{
		position = _position;
	} 

	public void setAvailability(bool _available) 
	{
		available = _available;
	}

	public GameObject getCurrentGameObject() 
	{
		return gameObject;
	}

	public void setCurrentGameObject(GameObject _gameObject) 
	{
		gameObject = _gameObject;
	}
}