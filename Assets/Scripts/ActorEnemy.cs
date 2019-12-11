using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEnemy : MonoBehaviour
{
	[SerializeField]
	private Animator hitAnimation = null;
	[SerializeField]
	private float respawnTime = 5.0f;
	private Coroutine respawning = null;
	//[SerializeField]
	//private float scoreValue = 20;

	[SerializeField]
	private Transform playerTransform = null;
	[SerializeField]
	private Transform turretTransform = null;
	[SerializeField]
	private ActorProjectile projectile = null;
	[SerializeField]
	private float fireRate = 3;
	[SerializeField]
	private float projectileVelocity = 10;
	Coroutine shootCoroutine = null;


	private void AimAtPlayer()
	{
		Quaternion aimRotation = Quaternion.LookRotation((turretTransform.position - playerTransform.position));
		turretTransform.rotation = aimRotation;
	}

	private void Start()
	{
		shootCoroutine = StartCoroutine("Shoot");
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
			StopCoroutine(shootCoroutine);
			shootCoroutine = null;
			respawning = StartCoroutine("Respawn");
		}
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(respawnTime);
		hitAnimation.SetTrigger("Respawn");
		shootCoroutine = StartCoroutine("Shoot");
		respawning = null;
	}

	IEnumerator Shoot()
	{
		while (true)
		{
			yield return new WaitForSeconds(fireRate);
			ActorProjectile instance = Instantiate(projectile, turretTransform.position, turretTransform.rotation);
			instance.GetComponent<Rigidbody>().velocity = instance.transform.forward * -projectileVelocity;
			instance.SetAsEnemyProjectile();
		}
	}
}
