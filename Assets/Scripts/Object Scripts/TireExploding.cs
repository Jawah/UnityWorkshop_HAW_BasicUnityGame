// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script for our TireObstacle explosion.

public class TireExploding : MonoBehaviour {

    // Animation Holder as we use Holders for everything else.
	public GameObject animationHolder;
    // Our TireExplosion Object.
	public GameObject tireExplosion;

	void Awake ()
    {
		animationHolder = GameObject.Find ("AnimationHolder");
	}

    // We use OnDisable() because we want this function to start when the GameObject (in this case the TireObstacle) is disabled.
	void OnDisable()
    {
        // If unclear, see 'Weapon' script.
		GameObject tempExplosion = Instantiate (tireExplosion, transform.position, transform.rotation);
		tempExplosion.transform.parent = animationHolder.transform;

		gameObject.SetActive (false);
	}
}
