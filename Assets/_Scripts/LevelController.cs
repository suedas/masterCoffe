using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	#region Singleton
	public static LevelController instance;
	void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this);
	}
	#endregion

	public List<GameObject> LevelPrefabs = new();
	public Transform coffePrefab;
	public GameObject[] coffe;
	public int öncekicoin;
	public int currentLevelNo, totalLevelNo;
	// ui kýsmýna totallevelno yazdýrýlýyor.. currentlevelno sadece level objelerinin instantiate edilmesini kontrol ediyor..

	public GameObject currentLevelObj;

	private void Start()
	{
		PlayerPrefs.DeleteAll();
		totalLevelNo = PlayerPrefs.GetInt("totallevelno");
		if (totalLevelNo == 0)
		{
			totalLevelNo = 1;
			PlayerPrefs.SetInt("totallevelno", totalLevelNo);
		}
		CreateLevel();

	}

	public void CreateLevel()
	{
		if (totalLevelNo > LevelPrefabs.Count)
		{
			currentLevelNo = Random.Range(1, LevelPrefabs.Count + 1);
			UIController.instance.LevelText.text = currentLevelNo.ToString();

		}
		else
		{
			currentLevelNo = totalLevelNo;
			UIController.instance.LevelText.text = currentLevelNo.ToString();

		}
		if (currentLevelObj == null)
		{
			currentLevelObj = Instantiate(LevelPrefabs[currentLevelNo - 1], Vector3.zero, Quaternion.identity);
			UIController.instance.LevelText.text = currentLevelNo.ToString();

		}
		else
		{
			Destroy(currentLevelObj);
			currentLevelObj = Instantiate(LevelPrefabs[currentLevelNo - 1], Vector3.zero, Quaternion.identity);
			UIController.instance.LevelText.text = currentLevelNo.ToString();

		}
	}

	public void NextLevelEvents()
	{
		totalLevelNo++;
		PlayerPrefs.SetInt("totallevelno", totalLevelNo);
		CreateLevel();
		UIController.instance.winPanel.SetActive(false);
		GameObject.Find("PlayerMain").transform.position = Vector3.zero;	
		UIController.instance.tapToStartPanel.SetActive(true);
		UIController.instance.leftImage.SetActive(true);
		UIController.instance.rightImage.SetActive(true);
		DestroyCoffe();
		instantiateCoffe();
		Debug.Log(GameManager.instance.Coffes.Count);


		//LeftGate.instance.InstantiateMe(4);
	}
	public void DestroyCoffe()
    {
		coffe = GameObject.FindGameObjectsWithTag("coffe");
		for (int i = 0; i < coffe.Length; i++)
		{
			Destroy(coffe[i]);
		}

	}

	public void RestartLevelEvents()
	{
		Destroy(currentLevelObj);
		currentLevelObj = Instantiate(LevelPrefabs[currentLevelNo - 1], Vector3.zero, Quaternion.identity);
		UIController.instance.losePanel.SetActive(false);
		GameObject.Find("PlayerMain").transform.position = Vector3.zero;
		UIController.instance.tapToStartPanel.SetActive(true);
		UIController.instance.leftImage.SetActive(true);
		UIController.instance.rightImage.SetActive(true);
		instantiateCoffe();


	}
	public void instantiateCoffe()
    {

        for (int i = 0; i < 4; i++)
        {
			Instantiate(coffePrefab,new Vector3(GameManager.instance.leftParent.transform.position.x, i, GameManager.instance.leftParent.transform.position.z),Quaternion.identity,GameManager.instance.leftParent.transform);
			//GameManager.instance.Coffes.Add(coffePrefab.gameObject);
			GameManager.instance.yPosLeft += 1;

		}
		for (int i = 0; i < GameManager.instance.leftParent.transform.childCount; i++)
		{
			GameManager.instance.Coffes.Add(GameManager.instance.leftParent.transform.GetChild(i).gameObject);
		}
		for (int i = 0; i < GameManager.instance.rightParent.transform.childCount; i++)
		{
			GameManager.instance.Coffes.Add(GameManager.instance.rightParent.transform.GetChild(i).gameObject);
		}

	}
}
