using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEnemy : MonoBehaviour
{
	[SerializeField]
	private Animator hitAnimation;
	[SerializeField]
	private float respawnTime = 5.0f;
	private Coroutine respawning = null;
	[SerializeField]
	private float scoreValue = 20;

	[SerializeField]
	private Transform playerTransform = null;
	[SerializeField]
	private Transform turretTransform = null;
	[SerializeField]
	private ActorProjectile projectile = null;
	[SerializeField]
	private float fireRate = 3;

	private void AimAtPlayer()
	{
		Quaternion aimRotation = Quaternion.LookRotation((turretTransform.position - playerTransform.position));
		turretTransform.rotation = aimRotation;
	}

	private void Update()
	{
		AimAtPlayer();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("PlayerProjectile") && respawning == null)
		{
			// Apply Points


			// Handle animations
			hitAnimation.SetTrigger("Hit");
			respawning = StartCoroutine("Respawn");
		}
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(respawnTime);
		hitAnimation.SetTrigger("Respawn");
		respawning = null;
	}
}
