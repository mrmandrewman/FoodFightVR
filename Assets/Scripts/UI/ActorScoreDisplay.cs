using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorScoreDisplay : MonoBehaviour
{
	[SerializeField]
	private Text textScoreDisplay = null;

	private string scoreString;

	public void DisplayScore()
	{
		scoreString = ActorLevelManager.instance.GetScore().ToString().PadLeft(8,'0');
		textScoreDisplay.text = scoreString;
	}
}
