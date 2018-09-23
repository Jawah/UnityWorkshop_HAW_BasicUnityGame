// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The only use of this class is to manage our Buttons in the MainMenu.
// Therefore Starting and Quiting the game.
// Remember to import the UnityEngine.SceneManagement namespace so that we have access to Scene relevant function.
public class ButtonController : MonoBehaviour
{
	public void StartGame()
    {
		SceneManager.LoadScene ("Main");
	}

	public void ExitGame()
    {
		Application.Quit ();
	}
}
