// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This class handles our gamestate and changing the UI, Audio and Scores accordingly.
public class GameManager : MonoBehaviour
{
	public static int score = 0;
	public GameObject player;
	public GameObject gameoverTxt;
	public GameObject restartTxt;
	public GameObject pauseTxt;
	public Text scoreTxt;
	public Text pToPauseTxt;
	public static bool isPaused = false;
	public static bool isGameOver = false;

    // The AudioManager is responsible for pausing, starting or changing our GameAudio.
	public AudioManager am;

	void Awake ()
    {
        // Referencing our Player through code instead of the Inspector.
		player = GameObject.Find ("Player");
	}
	
	void Update ()
    {
        // As we use and change the text of Text Components we have to import the UnityEngine.UI namespace.
		scoreTxt.text = "Score: " + score;

        // Check if our Player is alive and if he is not, stoping the game and enabling our GameOver Text elements.
		if (!player.activeSelf)
        {
			gameoverTxt.SetActive (true);
			restartTxt.SetActive (true);

			StartCoroutine (StopScene());
			isGameOver = true;
		}
        else
        {
			gameoverTxt.SetActive (false);
			restartTxt.SetActive (false);
			isGameOver = false;
		}

		// If the game is neither over nor it is paused, keep our game running with the default timeScale of one.
		if (!isGameOver && !pauseTxt.activeSelf)
        {
			Time.timeScale = 1;
		}

        // Check for 'P' input and stop/pause our game (timeScale = 0, Pause Text enable, ..)
		if (!pauseTxt.activeSelf && Input.GetKeyDown (KeyCode.P) && !isGameOver)
        {
            am.StopAllAudio();

			Time.timeScale = 0;
			pauseTxt.SetActive (true);
			pToPauseTxt.text = "Press 'P' to resume!";
			isPaused = true;

		}

        // And checking for another 'P' while our game is paused to continue it.
        else if (pauseTxt.activeSelf && Input.GetKeyDown(KeyCode.P) && !isGameOver)
        {
			am.PlayAllAudio ();

			Time.timeScale = 1;
			pauseTxt.SetActive (false);
			pToPauseTxt.text = "Press 'P' to pause!";
			isPaused = false;
		}

		// Restart the game with 'R' input only when our Player is dead/not active.
        // Reseting our score and reloading the Scene.
		if (!player.activeSelf && Input.GetKeyDown(KeyCode.R)) {

			GameManager.score = 0;
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);

		}

	}

    // A Coroutine which wait 2 1/2 seconds before stoping the game.
    // Coroutines are declared with the return Type IEnumerator and have a yield return (most of the time).
	IEnumerator StopScene ()
    {
		yield return new WaitForSeconds(2.5f);
		Time.timeScale = 0;
	}
}
