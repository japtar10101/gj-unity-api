﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITest : MonoBehaviour
{
	public Button showTrophiesButton;

	int notificationQueued = 0;

	public void SignInButtonClicked()
	{
		GameJolt.UI.Manager.Instance.ShowSignIn((bool success) => {
			if (success)
			{
				showTrophiesButton.interactable = true;
				Debug.Log("Logged In");
			}
			else
			{
				Debug.Log("Dismissed");
			}
		});
	}

	public void SignOutButtonClicked()
	{
		if (GameJolt.API.Manager.Instance.CurrentUser != null)
		{
			showTrophiesButton.interactable = false;
			GameJolt.API.Manager.Instance.CurrentUser.SignOut();
		}
	}

	public void QueueNotification()
	{
		GameJolt.UI.Manager.Instance.QueueNotification(
			string.Format("Notification <b>#{0}</b>", ++notificationQueued));
	}

	public void Pause()
	{
		Time.timeScale = 0f;
	}

	public void Resume()
	{
		Time.timeScale = 1f;
	}
}
