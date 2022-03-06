using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
	#region Singleton
	public static UiController instance;
	void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this);
	}
	#endregion

	public GameObject winScreenPanel, gamePanel, loseScreenPanel, tapToStartButtonClick;
	public TextMeshProUGUI gamePanelScoreText, losePanelScoreText, winPanelScoreText,gamePanelLevelText;


	public void TapToStartButtonClick()
	{

	}

	public void NextLevelButtonClick()
	{

	}

	public void RestartButtonClick()
	{

	}
}
