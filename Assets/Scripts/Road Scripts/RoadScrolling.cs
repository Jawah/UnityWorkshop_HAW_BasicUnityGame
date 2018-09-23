// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for moving our road backwards and seamlessly re-attach the road piece to the front
// if it's come to far. This accomplishes our endless road.
// For better understanding check the Scene View while in Play Mode.
public class RoadScrolling : MonoBehaviour
{
	[SerializeField]
	private float speed;
	private GameObject roadStartPoint;

	void Awake ()
    {
        // The point at which the road pieces are reattached. We find it by name.
		roadStartPoint = GameObject.Find ("RoadStartPoint");
	}

	void FixedUpdate ()
    {	
        // Moving the Road Pieces to the back (with its transform). You could use the Translate() method alternatively.
		transform.position = new Vector3 (0.0f, 0.0f, transform.position.z - speed);
	}

    // When our road piece reaches a point outside of the Camera View it collides with a BoxCollider.
	void OnTriggerEnter (Collider point)
    {	
        // Comparing its Tag ensures us that it's really the right object.
		if (point.gameObject.CompareTag(Tags.ROAD_END_POINT_TAG))
        {	
            // And when we touch it, we set our road piece to the roadStartPoint Position.
			transform.position = roadStartPoint.transform.position;
		}
	}
}
