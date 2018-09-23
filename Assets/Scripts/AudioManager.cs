// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class for pausing, starting, fading or reseting our Ingame Music.
public class AudioManager : MonoBehaviour
{
	public float fadeOutValue = 100f;
	private float initialVolume;

    // AudioSource is our Audio handling Component.
    private AudioSource audioSource;
	private AudioSource[] allAudioSources;

	void Awake ()
    {
		audioSource = GetComponent<AudioSource> ();
	}

	void Start()
    {
        // AudioSources have custom variables/functions for returning and changing Audio Data.
		initialVolume = audioSource.volume;
	}

	void Update()
    {
        // If the game is over, start to fade out our Audio until it's volume reaches 0.
        if (GameManager.isGameOver && audioSource.volume > 0)
        {
            audioSource.volume -= initialVolume / fadeOutValue;
        }
        // When it's 0, stop it altogether.
        else if (GameManager.isGameOver)
        {
            audioSource.Stop();
        }
	}

    // When this method is called we want to find every Component of Type AudioSource (including other GameObjects)
    // then put it into an array, loop through it and call on every single one the Pause() function.
	public void StopAllAudio()
    {
		allAudioSources = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];

		foreach (AudioSource allAudio in allAudioSources)
        {
			allAudio.Pause ();
		}
	}

    // The same as above but now we want to resume it and call UnPause().
	public void PlayAllAudio() {

		allAudioSources = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];

		foreach (AudioSource allAudio in allAudioSources) {

			allAudio.UnPause();

		}

	}
}
