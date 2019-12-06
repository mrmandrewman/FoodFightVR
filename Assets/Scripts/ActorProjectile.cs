using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorProjectile : MonoBehaviour
{
	[SerializeField]
	private Rigidbody thisRigidbody = null;
	[SerializeField, Tooltip("How fast the object needs to be thrown to count as a projectile"), Range(0, 10)]
	private float activeProjectileSpeed = 2.0f;
	[SerializeField, Tooltip("How long the object will stay active after pick up")]
	private float timeToLive = 5.0f;

	private bool b_activeProjectile = false;

	private void Update()
	{
		if (thisRigidbody.velocity.magnitude<activeProjectileSpeed)
		{
			b_activeProjectile = false;
			gameObject.tag = "Food";
			gameObject.layer = 0;
		}
	}

	public void SetAsPlayerProjectile()
	{
		StartCoroutine("LifeSpan");
		StartCoroutine("CheckVelocity");
	}

	public void SetAsEnemyProjectile()
	{
		StartCoroutine("LifeSpan");
		if (thisRigidbody.velocity.magnitude >= activeProjectileSpeed)
		{
			gameObject.tag = "EnemyProjectile";
			b_activeProjectile = true;
		}
	}
	
	public void RefreshLifeSpan()
	{
		// Refreshes the lifespan of the object when picked up
		StopCoroutine("LifeSpan");
	}

	IEnumerator LifeSpan()
	{
		// Destroys the game object after an amount of time
		yield return new WaitForSeconds(timeToLive);
		Destroy(gameObject);
	}

	IEnumerator CheckVelocity()
	{
		yield return new WaitForEndOfFrame();
		if (thisRigidbody.velocity.magnitude >= activeProjectileSpeed)
		{
			gameObject.tag = "PlayerProjectile";
			gameObject.layer = 8; // Player layer, stops the apple from colliding with tha player
			b_activeProjectile = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (b_activeProjectile)
		{
			// deactivate mesh renderer
			// play particle effect 
			// play impact sound
		}
	}
}
