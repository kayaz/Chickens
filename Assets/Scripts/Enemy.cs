using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int health = 100;
	public GameObject deathEffect;
	public GameObject impactEffect;

	public void TakeDamage(int damage)
	{
		health -= damage;

		GameObject hitEffect = Instantiate(impactEffect, transform.position, Quaternion.identity);

		if (health <= 0)
		{
			Die();
		}

		Destroy(hitEffect, 2f);
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}