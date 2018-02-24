using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;


public class FirebaseScript : MonoBehaviour {
	public InputField Email, Password;

	public void LoginButtonPressed()
	{
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync (Email.text, Password.text).
		ContinueWith ((obj) => {
			SceneManager.LoadSceneAsync ("LoggedInScene");
		});
	}

	public void LoginAnonymousButtonPressed()
	{
		FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().
		ContinueWith ((obj) => {
			SceneManager.LoadSceneAsync ("LoggedInAnonScene");
		});
	}

	public void CreateNewUserButtonPressed()
	{
		FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync (Email.text, Password.text).
		ContinueWith ((obj) => {
			SceneManager.LoadSceneAsync ("LoggedInScene");
		});
	}
}	
