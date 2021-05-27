using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed = 20f;
	public int damage = 100;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

		Destroy(gameObject, 2f);
	}

}
