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
