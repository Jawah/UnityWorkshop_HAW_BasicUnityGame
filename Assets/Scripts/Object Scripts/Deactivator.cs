// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In our game a lot of GameObjects are instantiated.
// If we never disable or destroy them Unity won't unload them and after some time our Scene will have so
// many instantiated GameObjects, the game will start to lag.
// Here we deactivate the GameObjects after some time. Don't Destroy Objects as it costs more performance.
public class Deactivator : MonoBehaviour
{
	[SerializeField]
	private float lifeTime;

	void Start ()
    {
        // This method is called as soon as our GameObject is instantiated.
		StartCoroutine (DeactivateAfter());
	}

    IEnumerator DeactivateAfter()
    {
        // Wait for the value of lifeTime in seconds..
        yield return new WaitForSeconds(lifeTime);
        //..and deactivate yourself.
        gameObject.SetActive(false);
    }
}
