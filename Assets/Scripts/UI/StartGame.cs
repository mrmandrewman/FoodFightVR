using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public static StartGame instance = null;


	public float timeLeft = 180.0f;
	public Text startText;

	void Update()
	{

		timeLeft -= 1 * Time.deltaTime;
		startText.text = (timeLeft).ToString("0");
		if (timeLeft < 0)
		{
			Debug.Break();
			Application.Quit();
		}
	}
}