// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The PlayerMovement class is responsible to move the Player and to disable him if he collides with an obstacle.
public class PlayerMovement : MonoBehaviour
{
	public PlayerAnimations anim;
    public GameObject animationHolder;
    public GameObject playerExplosion;

    [SerializeField] // SerializeField to serialize and show private variables in the Inspector.
	private float speed = 15.0f;
	private Rigidbody rb;

    // We use Awake for referencing something (in this case our Rigidbody).
	void Awake ()
    {
        // As we want to change the velocity of the car, we need his Rigidbody.
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
    {
		MovePlayer();
	}

	private void MovePlayer()
    {
        // The Input values of WASD and the ArrowKeys. It's a predefined setting and can be changed @ Edit -> Project Settings -> Input.
		// The values can be either 1 or -1 (right or left) when we use a Keyboard. With a controller, we also get mid-values.
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		// Play Animations according to Input.
		// The Rest is done through the Animator.
		if (verticalMovement < 0)
        {			
			anim.Car_Backwards ();
		}
        else if (horizontalMovement < 0)
        {			
			anim.Car_Left (); 
		}
        else if (horizontalMovement > 0)
        {			
			anim.Car_Right ();
		}

        // Vector3 is a three-dimensional value describing x, y and z.
		Vector3 movement = new Vector3 (horizontalMovement, 0.0f, verticalMovement);

        // We change the velocity on one or more axis and multiply by speed (otherwise the values would be just 1 or -1).
		rb.velocity = movement * speed;
	}

    // OnTriggerEnter is called when we collide with another Collider (marked as "is Trigger).
	void OnTriggerEnter(Collider other)
    {
        // "other" saves us the reference to the other Collider which we can use to get the other GameObject.
        // Comparing its Tag we can ensure which GameObject we Collide with. Check the "Tags" script for more information.
		if (other.gameObject.CompareTag(Tags.OBSTACLE_TAG) || other.gameObject.CompareTag(Tags.ENEMY_TAG) || other.gameObject.CompareTag(Tags.ENEMY_SHOT_TAG) || other.gameObject.CompareTag(Tags.OBSTACLE_STRONG_TAG))
        {
            // We Instantiate() our GameObject (in this case: playerExplosion), set its position/rotation and save it in a variable.
			GameObject tempExplosion = Instantiate (playerExplosion, transform.position, transform.rotation);
            // Now we want to change the parent GameObject of the instantiated one.
			tempExplosion.transform.parent = animationHolder.transform;

            // After the car collides with an obstacle, both GameObjects are disabled.
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}