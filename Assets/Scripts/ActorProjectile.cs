﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorProjectile : MonoBehaviour
{
	[SerializeField]
	private Rigidbody thisRigidbody = null;
	[SerializeField]
	private float throwPowerMultiplier = 1.5f;

	[SerializeField, Tooltip("How fast the object needs to be thrown to count as a projectile"), Range(0, 10)]
	private float activeProjectileSpeed = 2.0f;
	[SerializeField, Tooltip("How long the object will stay active after pick up")]
	private float timeToLive = 5.0f;

	[SerializeField]
	private GameObject splatterParticle = null;

	private bool b_activeProjectile = false;

	private void Update()
	{
		if (thisRigidbody.velocity.magnitude<activeProjectileSpeed)
		{
			b_activeProjectile = false;
			gameObject.tag = "Food";
		}
	}

	public void SetAsPlayerProjectile()
	{
		StartCoroutine("LifeSpan");
		StartCoroutine("CheckVelocity");
	}

	public void SetAsEnemyProjectile()
	{
		//gameObject.layer = 0;
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
		thisRigidbody.velocity *= throwPowerMultiplier;
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
			Quaternion targetSplatterRotation = Quaternion.LookRotation(transform.position - ActorLevelManager.instance.GetPlayerObject().transform.position);
			Instantiate(splatterParticle, transform.position, targetSplatterRotation);
			Destroy(gameObject);
			// deactivate mesh renderer
		}

		if (CompareTag("EnemyProjectile") && collision.gameObject.CompareTag("Player"))
		{
			ActorLevelManager.instance.ChangeHealth(-1);
		}
	}
}
