using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singleton
	public static GameManager instance;
	void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this);
	}
	#endregion

	public bool isContinue; // player hareket etmesi veya dokunmatik calismasi buna bagli

	private void Start()
	{
		isContinue = true;
	}
}
