using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorHealthDisplay : MonoBehaviour
{
	[SerializeField]
	private int currentHealth = 6;

	[Header("UI Element")]
	[SerializeField]
	private Image heart1 = null;

	[SerializeField]
	private Image heart2 = null;

	[SerializeField]
	private Image heart3 = null;

	[Header("Heart Textures")]
	[SerializeField]
	private Sprite heartImageFull;
	
	[SerializeField]
	private Sprite heartImagePartial;

	[SerializeField]
	private Sprite heartImageEmpty;


	public void DisplayHealth()
	{
		currentHealth = ActorLevelManager.instance.GetHealth();
		if (currentHealth == 6)
		{
			heart1.sprite = heartImageFull;

			heart2.sprite = heartImageFull;

			heart3.sprite = heartImageFull;
		}


		if (currentHealth == 5)
		{
			heart1.sprite = heartImagePartial;

			heart2.sprite = heartImageFull;

			heart3.sprite = heartImageFull;
		}


		if (currentHealth == 4)
		{
			heart1.sprite = heartImageEmpty;

			heart2.sprite = heartImageFull;

			heart3.sprite = heartImageFull;
		}


		if (currentHealth == 3)
		{
			heart1.sprite = heartImageEmpty;

			heart2.sprite = heartImagePartial;

			heart3.sprite = heartImageFull;
		}


		if (currentHealth == 2)
		{
			heart1.sprite = heartImageEmpty;

			heart2.sprite = heartImageEmpty;

			heart3.sprite = heartImageFull;
		}


		if (currentHealth == 1)
		{
			heart1.sprite = heartImageEmpty;

			heart2.sprite = heartImageEmpty;

			heart3.sprite = heartImagePartial;
		}

		if (currentHealth == 0)
		{
			heart1.sprite = heartImageEmpty;

			heart2.sprite = heartImageEmpty;

			heart3.sprite = heartImageEmpty;
		}
	}

}
