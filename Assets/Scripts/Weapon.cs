using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;
    public float bulletForce = 20f;
    private bool FacingRight = true;

    public GameObject projectile;
    public GameObject player;
    public Transform shotPoint;
    private Vector2 screenBounds;
    AudioSource shootingSound;

    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.parent.gameObject.transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            //Debug.Log("Lewa");
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ + offset));
            player.transform.rotation = Quaternion.Euler(0, 360, 0);

        }
        else
        {
            //Debug.Log("Prawa");
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, rotZ + offset));
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        if (transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        shootingSound.Play();
        GameObject bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * bulletForce, ForceMode2D.Impulse);

        Destroy(bullet, 2f);
    }
}