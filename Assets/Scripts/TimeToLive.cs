using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
	[SerializeField]
	private float TTL = 2.0f;
	private float currentLifeTime = 0.0f;
	
    // Update is called once per frame
    void Update()
    {
		currentLifeTime += Time.deltaTime;

		if (currentLifeTime >= TTL)
		{
			Destroy(gameObject);
		}
    }
}
