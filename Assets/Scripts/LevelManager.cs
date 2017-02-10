using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public GameObject backgroundPrefab;
	public GameObject levelComponents;
	public GameObject background;
	public GameObject foreground;
	private List<GameObject> animals = new List<GameObject> ();
	private List<AnimalPosition> positions = new List<AnimalPosition> ();
	private int levelConstructor;
	private int currentLevel;

	public void LevelSetup() 
	{		
		levelConstructor = 1;
		currentLevel = 1;
		InvokeRepeating ("increaseLevel", 0, 180);
		InvokeRepeating ("spawnAnimal", 0, 5);
		positions.Add (new AnimalPosition(new Vector2(-8f,-4.4f),true));
		positions.Add (new AnimalPosition(new Vector2(-7f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(-6f,-4.4f),true));
		positions.Add (new AnimalPosition(new Vector2(-5f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(-4f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(-3f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(-2f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(-1f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(0f,-4.4f),true));
		positions.Add (new AnimalPosition(new Vector2(1f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(2f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(3f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(4f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(5f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(6f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(7f,-4.4f),false));
		positions.Add (new AnimalPosition(new Vector2(8f,-4.4f),false));
	}

	public void Update() 
	{	
		
	}

	public int selectRandomPosition() 
	{		
		System.Random rnd = new System.Random();
		int randomPositionIndex = rnd.Next (0, 16);
		return randomPositionIndex;
	}

	public int selectRandomSpawnAnimal () 
	{
		System.Random rnd = new System.Random();
		return(rnd.Next (1, 5));
	}

	void spawnAnimal() 
	{		
		int pos = selectRandomPosition ();
		switch (levelConstructor) {
		case 1:	//Wood
			switch (selectRandomSpawnAnimal ()) {
			case Constants.SPAWNANIMAL1:			
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().rabbitPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL2:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().wolfPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL3:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().deerPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL4:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().bearPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			}
			break;
		case 2:	//Farm
			switch (selectRandomSpawnAnimal ()) {
			case Constants.SPAWNANIMAL1:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().duckPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL2:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().sheepPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL3:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().cowPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL4:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().horsePrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			}
			break;
		case 3: //Desert
			switch (selectRandomSpawnAnimal ()) {
			case Constants.SPAWNANIMAL1:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().snakePrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL2:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().foxPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL3:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().antelopePrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL4:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().jaguarPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			}
			break;
		case 4: //Artic
			switch (selectRandomSpawnAnimal ()) {
			case Constants.SPAWNANIMAL1:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().penguinPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL2:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().whiteWolfPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL3:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().reindeerPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			case Constants.SPAWNANIMAL4:				
				animals.Add (Instantiate (levelComponents.GetComponent<LevelComponent> ().polarbearPrefab, positions [pos].getPosition (), GetComponent<Transform> ().rotation) as GameObject);
				positions [pos].setAvailability (false);
				break;
			}
			break;
		}						
	} 

	public void increaseLevel() 
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
		if (levelConstructor == 4) {
			levelConstructor = 1;
		} else {
			levelConstructor++;
		}
		currentLevel++;
	}
}

public class AnimalPosition 
{
	public Vector2 position;
	public bool available;

	public AnimalPosition(Vector2 _position, bool _available) 
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
}