using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform respawnPoint;
    public GameObject playerPrefab;
    public GameObject portal;
    AudioSource portalSound;

    private void Awake(){
        instance = this;
        portal = portal.gameObject;
    }
    void Start()
    {
        portalSound = GetComponent<AudioSource>();
        portalSound.Play();
        this.portal = (GameObject)Instantiate(portal, respawnPoint.position, Quaternion.identity);
        Invoke("Respawn", 1f);
    }
	public void Die()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Respawn()
    {
        playerPrefab.SetActive(true);
        Destroy(this.portal);
    }
}
