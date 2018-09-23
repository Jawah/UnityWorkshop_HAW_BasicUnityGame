// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class for instantitating shots (and calling right sounds and animations).
public class Weapon : MonoBehaviour
{
	public GameObject shot;
    // A 'Holder' for giving a better overview in our game hierarchy in Play Mode and minimazing trash.
    // Therefore decalaring a parent to the shot and hiding it under it.
	public GameObject shotHolder;

	[SerializeField]
	private float fireRate = 0.5f;
	[SerializeField]
	private float nextFire = 0f;
	private PlayerAnimations anim;
	private AudioSource audioSource;

	void Awake ()
    {	
        // Our Weapon script is on the Cannon which is a child of our Player.
        // To reference the player we use transform.parent.
		anim = transform.parent.GetComponent<PlayerAnimations> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update ()
    {
        // If we press the space, our game is running/not paused and we waited the threshold for our next shot:
		if (Input.GetKeyDown(KeyCode.Space)  && Time.time > nextFire && !GameManager.isPaused) {
			
            // Here we calculate if we can already shoot again as we want to have a 1/2 second delay between our shots.
            // Write it out for better understanding. Time.time returns the time since the start of the game.
			nextFire = Time.time + fireRate;

            // Call our Shoot Animation. Check PlayerMovement for more examples.
			anim.Car_Shoot ();
            
            // If the name of the GameObject this script is one, is "MainCannon", play the Shoot sound.
			if (gameObject.name == Tags.MAIN_CANNON)
            {	
				audioSource.Play ();
			}

            // We Instantiate() our GameObject (in this case: shot), set its position/rotation (same es cannon) and save it in a variable.
            GameObject tempShot = Instantiate (shot, transform.position, transform.rotation);
            // Now we want to change the parent GameObject of the instantiated one.
            tempShot.transform.parent = shotHolder.transform;
		}
	}
}
