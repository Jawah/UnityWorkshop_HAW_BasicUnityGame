// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handlying Enemy Collision and Shooting
public class EnemyBehaviour : MonoBehaviour
{
    public GameObject shot;
	private GameObject shotHolder;

    [SerializeField]
    private float startShootingIn;
    [SerializeField]
    private float fireRate;

	void Awake()
    {
		shotHolder = GameObject.Find ("ShotHolder");
	}

	void Start ()
    {
        // InvokeRepeating() is a great function for continous behaviour.
        // It starts a function after x seconds and repeats that function again after y seconds until canceled.
		InvokeRepeating ("Shoot", startShootingIn, fireRate);
	}

	void Shoot()
    {
        // If unclear, see 'Weapon' script.
		GameObject tempShot = Instantiate (shot, gameObject.transform.position, shot.transform.rotation);
		tempShot.transform.parent = shotHolder.transform;
	}

	void OnDisable()
    {
        // As said, we need to cancel the Invoke() when the GameObjects is disabled.
		CancelInvoke ();
	}

	void OnTriggerEnter(Collider other)
    { 
        // At collision with anything else, destroy both GameObjects.
		if (other.gameObject.CompareTag(Tags.OBSTACLE_TAG) || other.gameObject.CompareTag(Tags.ENEMY_TAG) || other.gameObject.CompareTag(Tags.PLAYER_SHOT_TAG) || other.gameObject.CompareTag(Tags.ENEMY_SHOT_TAG) || other.gameObject.CompareTag(Tags.OBSTACLE_STRONG_TAG))
        {
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
