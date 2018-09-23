// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The PlayerAnimation class is for holding all possible Car Animations that we have.
// So that we don't have to write them into our PlayerMovement class.
public class PlayerAnimations : MonoBehaviour {

    // In our Animator we have all of our Animations saved and the dependencies they have.
	private Animator animator;

	void Awake ()
    {
		animator = GetComponent<Animator> ();
	}

	public void Car_Forward()
    {
        // Animations have Tags which we also reference in our Tags class.
		animator.Play (Tags.ANIMATION_DRIVE);
	}

	public void Car_Backwards()
    {
		animator.Play (Tags.ANIMATION_BACKWARDS);
	}

	public void Car_Left()
    {
		animator.Play (Tags.ANIMATION_LEFT);
	}

	public void Car_Right()
    {
		animator.Play (Tags.ANIMATION_RIGHT);
	}

	public void Car_Shoot()
    {
		animator.Play (Tags.ANIMATION_PLAYER_SHOOT);
	}

}
