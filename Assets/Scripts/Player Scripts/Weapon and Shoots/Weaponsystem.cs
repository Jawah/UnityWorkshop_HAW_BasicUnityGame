// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Activate additional cannons if the WeaponLevel through PowerUps (Wrenches) reached a specific value.
// Also check for PowerUp collisions.
public class Weaponsystem : MonoBehaviour {

	[SerializeField]
	private int weaponLevel = 0;

	[SerializeField]
	private int incrementOnPowerUp = 20;

	[SerializeField]
	private int weaponLevelToPoints = 250;

    // Referencing our extra cannons.
	public GameObject levelTwoWeapon_1;
	public GameObject levelTwoWeapon_2;
	public GameObject levelThreeWeapon_1;
	public GameObject levelThreeWeapon_2;

	void Update()
    {
        // Checking our weaponLevel in a switching case statement and activating cannons if we gathered enough points.
		switch (weaponLevel)
        {
			case 80:
				levelTwoWeapon_1.SetActive(true);
				levelTwoWeapon_2.SetActive(true);
				break;
			case 600:
				levelThreeWeapon_1.SetActive(true);
				levelThreeWeapon_2.SetActive(true);
				break;
			default:
				// Nothing, first cannon is always active by default.
				break;
		}
	}

    // We want to check collision between our cannon (symbolic for car) and PowerUps.
	void OnTriggerEnter(Collider other)
    {
        // If we collide with a PowerUp..
		if (other.gameObject.CompareTag(Tags.POWER_UP_TAG))
        {
            //.. check if we have over 250 points..
			if (weaponLevel >= weaponLevelToPoints)
            {
                //.. if we do, add the points to our gameScore..
				GameManager.score += incrementOnPowerUp;
			}
            else
            {
                //.. otherwise add the to our weaponLevel points.
				weaponLevel += incrementOnPowerUp;
			}
            // Deactivate the PowerUp GameObject.
			other.gameObject.SetActive (false);
		}
	}
}
