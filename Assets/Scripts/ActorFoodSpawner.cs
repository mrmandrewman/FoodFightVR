using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorFoodSpawner : MonoBehaviour
{
	public int MaxItems = 5;
	public ActorProjectile foodItems;
	Coroutine spawnCoRoutine;
	public float spawnRate = 2;

	private void Update()
	{
		
		if (transform.childCount < MaxItems && (spawnCoRoutine == null))
		{
			spawnCoRoutine = StartCoroutine("SpawnFood");
		}
	}

	IEnumerator SpawnFood()
	{
		yield return new WaitForSeconds(spawnRate);
		Instantiate(foodItems, transform.position, transform.rotation, transform);
		spawnCoRoutine = null;
	}

}
