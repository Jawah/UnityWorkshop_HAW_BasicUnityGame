// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class although named 'Mover' is not only responsible for moving GameObjects
// but also checking collision and adding points to our highscore accordingly.
public class Mover : MonoBehaviour
{
	[SerializeField]
	private float speed = 25.0f;
	private Rigidbody rb;

	void Awake ()
    {
		rb = GetComponent<Rigidbody>();
	}
    
	void Start ()
    {
		rb.velocity = Vector3.forward * speed;
	}

    // Because we use this script not only on our Bullet but also on other Objects we need to check
    // what exactly is colliding with what. And add points if suitable.
	void OnTriggerEnter(Collider other)
    {    
        // The simplest case: Our bullet collides with an enemy bullet. Deactivate both.
		if (gameObject.CompareTag(Tags.PLAYER_SHOT_TAG) && other.gameObject.CompareTag(Tags.ENEMY_SHOT_TAG))
        {
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
        // Our bullet or the enemy bullet collides with a strong obstacle (barrier). Deactivate only the bullet.
		else if ((gameObject.CompareTag(Tags.PLAYER_SHOT_TAG) || gameObject.CompareTag(Tags.ENEMY_SHOT_TAG)) && other.gameObject.CompareTag(Tags.OBSTACLE_STRONG_TAG))
        {
			gameObject.SetActive (false);
		}

        // Our bullet or the enemy bullet collides with a weaker obstacle (tire). Deactivate both and add 5 points to our highscore.
		else if ((gameObject.CompareTag(Tags.PLAYER_SHOT_TAG) || gameObject.CompareTag(Tags.ENEMY_SHOT_TAG)) && other.gameObject.CompareTag(Tags.OBSTACLE_TAG))
        {	
			GameManager.score += 5;
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
		else if ((gameObject.CompareTag(Tags.PLAYER_SHOT_TAG) || gameObject.CompareTag(Tags.ENEMY_SHOT_TAG)) && other.gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            // Our bullet or the enemy bullet collides with an enemy car. Deactivate both and add 25 points to our highscore.
            GameManager.score += 25;
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
