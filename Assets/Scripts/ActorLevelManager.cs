using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorLevelManager : MonoBehaviour
{

	private static int currentScore = 0;
	[SerializeField]
	private ActorScoreDisplay scoreDisplay = null;

	private static int currentHealth = 6;
	[SerializeField]
	private ActorHealthDisplay healthDisplay = null;

	[SerializeField]
	private static GameObject playerGameObject = null;


	public static ActorLevelManager instance = null;
	// Start is called before the first frame update
	private void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public GameObject GetPlayerObject()
	{
		return playerGameObject;
	}

	public void AddPoints(int _points)
	{
		currentScore += _points;

		if (currentScore < 0)
		{
			currentScore = 0;
		}
		scoreDisplay.DisplayScore();
	}

	public int GetScore()
	{
		return currentScore;
	}

	public void ChangeHealth(int _health)
	{
		currentHealth += _health;

		if (currentHealth < 0)
		{
			currentHealth = 0;
		}
		healthDisplay.DisplayHealth();

		if (currentHealth == 0)
		{
			Debug.Break();
		}
	}

	public int GetHealth()
	{
		return currentHealth;
	}

}
