// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For Spawning continously objects (obstacles, enemies, consumables).
public class ObjectSpawner : MonoBehaviour
{
	public GameObject objectHolder;
    // We need an array of all possible Objects to spawn in a SpawnWave.
	public GameObject[] objects;

    // We need a random Position on the x axis, so they spawn differently every time.
    // Therefore we need a max x and min x value.
    [SerializeField]
    private int xMin;
    [SerializeField]
    private int xMax;

    // The time between SpawnWaves.
	[SerializeField]
	private float timeBetweenWaves = 10.0f;

    // The amount of objects in a SpawnWave.
    [SerializeField]
	private int amountOfObjectsInWave = 8;

    // And the time between spawning objects in a SpawnWave.
    // Especially for disallowing objects to spawn one in another.
	[SerializeField]
	private float timeBetweenObjects = 0.85f;
    
	void Start ()
    {
        // We'll use an endless Coroutine. InvokeRepeating() is an alternative.
		StartCoroutine(SpawnWaves());
	}

    IEnumerator SpawnWaves()
    {
        // For Endlessness.
        while (true)
        {
            // Wait the time between waves.
            yield return new WaitForSeconds(timeBetweenWaves);

            int x = 0;

            // Iterate 8 times through this while loop.
            while (x < amountOfObjectsInWave)
            {
                // Get a random object out of our objects array.
                int randObject = Random.Range(0, objects.Length);

                // Calculate a random Position. Only the x is random, the rest is from the objects itself and the ObjectSpawner GO.
                Vector3 randPos = new Vector3(
                    Random.Range(xMin, xMax),
                    objects[randObject].transform.position.y,
                    gameObject.transform.position.z
                );

                // Instantiate the GameObject and put it in the ObjectHolder.
                GameObject tempObject = Instantiate(objects[randObject], randPos, objects[randObject].transform.rotation);
                tempObject.transform.parent = objectHolder.transform;

                // Wait a short while before continuing the while loop.
                yield return new WaitForSeconds(timeBetweenObjects);
                // x++ because while
                x++;
            }
        }
    }
}
