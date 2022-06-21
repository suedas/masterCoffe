using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
	public bool hareket;
	bool isRight = false;
	//public int yPosRight, yPosLeft;
	public GameObject leftParent, rightParent;
	Vector3 mousePosition, tempMousePosition;
	public bool isContinue;
	public List<GameObject> Coffes = new List<GameObject>();
	public Transform coffePrefab;
	public Transform coffeAdd;


	private void Start()
	{
		hareket = false;
		DOTween.Init();
		//yPosLeft = leftParent.transform.childCount;
		//yPosRight = rightParent.transform.childCount;
		isContinue = true;

        //LevelController.instance.instantiateCoffe();
        for (int i = 0; i < 4; i++)
        {
			coffeAdd= Instantiate(coffePrefab, new Vector3(leftParent.transform.position.x, i+1, leftParent.transform.position.z), Quaternion.Euler(-90,0,0), leftParent.transform);
			//Debug.Log(leftParent.transform.childCount);
			for (int j = 0; j < leftParent.transform.childCount; j++)
			{
				Coffes.Add(leftParent.transform.GetChild(i).gameObject);
			}
			//Coffes.Add(coffeAdd.gameObject);

			// GameManager.instance.yPosLeft += 1;

		}
		
		//for (int i = 0; i < rightParent.transform.childCount; i++)
		//{
		//	Coffes.Add(rightParent.transform.GetChild(i).gameObject);
		//}
        UIController.instance.LeftCount.text = leftParent.transform.childCount.ToString();
        UIController.instance.RightCount.text = rightParent.transform.childCount.ToString();
    }

	private void Update()
	{
        //UIController.instance.coffeCountText();

        //     if (GameManager.instance.Coffes.Count < 0 && GameManager.instance.hareket == true)
        //     {
        //UIController.instance.LosePanel();

        //     }
      

		if (hareket)
        {
            leftParent.transform.position = new Vector3(leftParent.transform.position.x, Mathf.PingPong(Time.time * .3f, .2f), leftParent.transform.position.z);
            rightParent.transform.position = new Vector3(rightParent.transform.position.x, Mathf.PingPong(Time.time * .3f, .2f), rightParent.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
		{
			tempMousePosition = Input.mousePosition;
			mousePosition = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			mousePosition = Input.mousePosition;
			if (mousePosition.x - tempMousePosition.x > 0 && isContinue) // saða
			{
				isContinue = false;
				StartCoroutine(DelayAndContinue());
				isRight = true;

				Aktar();
			}
			else if (mousePosition.x - tempMousePosition.x < 0 && isContinue) // sola
			{
				isContinue = false;
				StartCoroutine(DelayAndContinue());
				isRight = false;
				Aktar();
			}
		}
	}

	IEnumerator DelayAndContinue()
	{
		yield return new WaitForSeconds(.1f);
		isContinue = true;
	}


	public void Aktar()
    {
        if (hareket==true)
        {
			if (isRight) // saða sürükleniyorsa
			{
				if (leftParent.transform.childCount > 0)
				{					
					StartCoroutine(SagaGit2(leftParent.transform.GetChild(leftParent.transform.childCount - 1).gameObject));
				}
			}
			else if (!isRight) // sola sürükleniyorsa
			{
				if (rightParent.transform.childCount > 0)
				{				
					StartCoroutine(SolaGit2(rightParent.transform.GetChild(rightParent.transform.childCount - 1).gameObject));
				}
			}
		}
		
	}

	//IEnumerator SagaGit(GameObject obj, float yukseklik)
	//{
	//	Vector3 position;
	//	float sayac = 0;
	//	//GameObject obj2 = Instantiate(coffePrefab.gameObject, obj2.transform.position, Quaternion.identity);
	//	if (rightParent.transform.childCount > 0)
	//	{
	//		position = new Vector3(2, rightParent.transform.childCount, 0);
	//	}
	//	else
	//	{
	//		position = rightParent.transform.position;
	//	}
	//	while (obj.transform.position.x < 2 && isRight)
	//	{
	//		float y = Mathf.Lerp(yPosLeft, position.y, sayac);
	//		sayac += .05f;
	//		obj.transform.position = new Vector3(obj.transform.position.x + .2f, y + Ypos(obj.transform.position.x), obj.transform.position.z);
	//		obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (2 - obj.transform.position.x) * 90));
	//		yield return new WaitForSeconds(.01f);
	//	}
	//	obj.transform.position = new Vector3(2, yukseklik, obj.transform.position.z);
	//	obj.transform.rotation = Quaternion.Euler(Vector3.zero);
 //       Scale(obj);
 //       //Destroy(obj2);
 //       yPosRight += 1;
	//	yPosLeft -= 1;
	//	BebeleriSirala();
	//}

	//IEnumerator SolaGit(GameObject obj, float yukseklik)
	//{
	//	Vector3 position;
	//	float sayac = 0;
	//	//GameObject obj2 = Instantiate(coffePrefab.gameObject, obj2.transform.position, Quaternion.identity);
	//	if (leftParent.transform.childCount > 0)
	//	{
	//		position = new Vector3(2, leftParent.transform.childCount, 0);
	//	}
	//	else
	//	{
	//		position = leftParent.transform.position;
	//	}
	//	while (obj.transform.position.x > -2 && !isRight)
	//	{
	//		float y = Mathf.Lerp(yPosRight, position.y, sayac);
	//		sayac += .05f;
	//		obj.transform.position = new Vector3(obj.transform.position.x - .2f, y + Ypos(obj.transform.position.x), obj.transform.position.z);
	//		obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (2 - obj.transform.position.x) * 90));
	//		yield return new WaitForSeconds(.01f);
	//	}
	//	obj.transform.position = new Vector3(-2, yukseklik, obj.transform.position.z);
	//	obj.transform.rotation = Quaternion.Euler(Vector3.zero);
	//	Scale(obj);

	//	yPosRight -= 1;
	//	yPosLeft += 1;
	//	BebeleriSirala();
	//}


	IEnumerator SagaGit2(GameObject obj)
	{
		DestroyLeftChild();
		Vector3 position;
		float sayac = 0;
		float tempY = 0;
		if (leftParent.transform.childCount > 0) tempY = leftParent.transform.childCount;
		GameObject obj2 = Instantiate(coffePrefab.gameObject, obj.transform.position, Quaternion.Euler(-90, 0, 0));
		if (rightParent.transform.childCount > 0)
		{
			position = new Vector3(2, rightParent.transform.childCount, 0);
		}
		else
		{
			position = rightParent.transform.position;
		}
		while (obj2.transform.position.x < 2 && isRight)
		{
			float y = Mathf.Lerp(tempY, position.y, sayac);
			sayac += .05f;
			obj2.transform.position = new Vector3(obj2.transform.position.x + .2f, y + Ypos(obj2.transform.position.x), obj2.transform.position.z);
			obj2.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, (2 - obj2.transform.position.x) * 90));
			yield return new WaitForSeconds(.015f);
		}		
		Destroy(obj2);
		CreateRightChild();
		//yPosRight += 1;
		//yPosLeft -= 1;
		//BebeleriSirala();
	}

	IEnumerator SolaGit2(GameObject obj)
	{
		DestroyRightChild();
		Vector3 position;
		float sayac = 0;
		float tempY = 0;
		if (rightParent.transform.childCount > 0) tempY = rightParent.transform.childCount;
		GameObject obj2 = Instantiate(coffePrefab.gameObject, obj.transform.position, Quaternion.Euler(-90, 0, 0));
		if (leftParent.transform.childCount > 0)
		{
			position = new Vector3(2, leftParent.transform.childCount, 0);
		}
		else
		{
			position = leftParent.transform.position;
		}
		while (obj2.transform.position.x > -2 && !isRight)
		{
			float y = Mathf.Lerp(tempY, position.y, sayac);
			sayac += .05f;
			obj2.transform.position = new Vector3(obj2.transform.position.x - .2f, y + Ypos(obj2.transform.position.x), obj2.transform.position.z);
			obj2.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, (2 - obj2.transform.position.x) * 90));
			yield return new WaitForSeconds(.015f);
		}
		Destroy(obj2);
		CreateLeftChild();
		//yPosRight -= 1;
		//yPosLeft += 1;
		//BebeleriSirala();
	}

	public float Ypos(float x)
	{
		if (x < -1.8f)
		{
			return Mathf.Sin(Mathf.Deg2Rad * 0) * 3;
		}
		else if (x >= -1.8f && x < -1.6f) return Mathf.Sin(Mathf.Deg2Rad * 9) * 3;
		else if (x >= -1.6f && x < -1.4f) return Mathf.Sin(Mathf.Deg2Rad * 18) * 3;
		else if (x >= -1.4f && x < -1.2f) return Mathf.Sin(Mathf.Deg2Rad * 27) * 3;
		else if (x >= -1.2f && x < -1f) return Mathf.Sin(Mathf.Deg2Rad * 36) * 3;
		else if (x >= -1f && x < -.8f) return Mathf.Sin(Mathf.Deg2Rad * 45) * 3;
		else if (x >= -.8f && x < -.6f) return Mathf.Sin(Mathf.Deg2Rad * 54) * 3;
		else if (x >= -.6f && x < -.4f) return Mathf.Sin(Mathf.Deg2Rad * 63) * 3;
		else if (x >= -.4f && x < -.2f) return Mathf.Sin(Mathf.Deg2Rad * 72) * 3;
		else if (x >= -.2f && x < 0f) return Mathf.Sin(Mathf.Deg2Rad * 81) * 3;
		else if (x >= 0f && x < .2f) return Mathf.Sin(Mathf.Deg2Rad * 90) * 3;
		else if (x >= .2f && x < .4f) return Mathf.Sin(Mathf.Deg2Rad * 99) * 3;
		else if (x >= .4f && x < .6f) return Mathf.Sin(Mathf.Deg2Rad * 108) * 3;
		else if (x >= .6f && x < .8f) return Mathf.Sin(Mathf.Deg2Rad * 117) * 3;
		else if (x >= .8f && x < 1f) return Mathf.Sin(Mathf.Deg2Rad * 126) * 3;
		else if (x >= 1f && x < 1.2f) return Mathf.Sin(Mathf.Deg2Rad * 135) * 3;
		else if (x >= 1.2f && x < 1.4f) return Mathf.Sin(Mathf.Deg2Rad * 144) * 3;
		else if (x >= 1.4f && x < 1.6f) return Mathf.Sin(Mathf.Deg2Rad * 153) * 3;
		else if (x >= 1.6f && x < 1.8f) return Mathf.Sin(Mathf.Deg2Rad * 162) * 3;
		else if (x >= 1.8f && x < 2f) return Mathf.Sin(Mathf.Deg2Rad * 171) * 3;
		else if (x >= 2f) return Mathf.Sin(Mathf.Deg2Rad * 180) * 3;
		else return 0;
	}

	public void Scale(GameObject obj)
	{
		Vector3 tempScale = new Vector3(1, .09f, 1);
		obj.transform.DOScale(new Vector3(1.1f, 0.13f, 1.1f), .1f).SetEase(Ease.Flash).OnComplete(() =>
		{
			obj.transform.DOScale(tempScale, .1f).SetEase(Ease.Flash);
		});
	}

	public void BebeleriSirala()
    {
        for (int i = 0; i < rightParent.transform.childCount; i++)
        {
			rightParent.transform.GetChild(i).SetSiblingIndex((int)rightParent.transform.GetChild(i).transform.position.y);
        }

		for (int i = 0; i < leftParent.transform.childCount; i++)
		{
			leftParent.transform.GetChild(i).SetSiblingIndex((int)leftParent.transform.GetChild(i).transform.position.y);
		}

	
	}

	public void BebeleriDiz()
    {
		BebeleriSirala();
		for (int i = 0; i < rightParent.transform.childCount-1; i++)
		{
			if(rightParent.transform.GetChild(i+1).transform.position.y - rightParent.transform.GetChild(i).transform.position.y > 1)
            {
				rightParent.transform.GetChild(i + 1).transform.position = new Vector3(rightParent.transform.GetChild(i).transform.position.x,
					 rightParent.transform.GetChild(i).transform.position.y+1, rightParent.transform.GetChild(i).transform.position.z);

			}
		}

		for (int i = 0; i < leftParent.transform.childCount-1; i++)
		{
			if (leftParent.transform.GetChild(i + 1).transform.position.y - leftParent.transform.GetChild(i).transform.position.y > 1)
			{
				leftParent.transform.GetChild(i + 1).transform.position = new Vector3(leftParent.transform.GetChild(i).transform.position.x,
					 leftParent.transform.GetChild(i).transform.position.y + 1, leftParent.transform.GetChild(i).transform.position.z);

			}
		}
	}

	public void CreateLeftChild()
	{
		GameObject coffe = Instantiate(coffePrefab.gameObject,
			new Vector3(-2,leftParent.transform.childCount+.8f,leftParent.transform.position.z),
			 Quaternion.Euler(-90, 0, 0), leftParent.transform);
		coffe.SetActive(false);
		StartCoroutine(DelayAndSetActive(coffe));
		Coffes.Add(coffe);
		UIController.instance.coffeCountText();
	}

	public void CreateRightChild()
	{
		GameObject coffe = Instantiate(coffePrefab.gameObject,
			new Vector3(2, rightParent.transform.childCount+.8f , rightParent.transform.position.z),
			 Quaternion.Euler(-90, 0, 0), rightParent.transform);
		coffe.SetActive(false);
		StartCoroutine(DelayAndSetActive(coffe));
		Coffes.Add(coffe);
		UIController.instance.coffeCountText();
	}

	public void DestroyLeftChild()
	{
		if(leftParent.transform.childCount > 0)
		{
			Coffes.Remove(leftParent.transform.GetChild(leftParent.transform.childCount - 1).gameObject);
			Destroy(leftParent.transform.GetChild(leftParent.transform.childCount - 1).gameObject);
			UIController.instance.coffeCountText();
		}
   
		
	}

	public void DestroyRightChild()
	{
		if(rightParent.transform.childCount > 0)
		{
			Coffes.Remove(rightParent.transform.GetChild(rightParent.transform.childCount - 1).gameObject);
			Destroy(rightParent.transform.GetChild(rightParent.transform.childCount - 1).gameObject);
			UIController.instance.coffeCountText();
		}
	
	}

	public IEnumerator DestroyForLeftGate(int adet)
	{

		for (int i = 0; i < adet; i++)
		{
			if (leftParent.transform.childCount > 0)
			{
				Vector3 obj2Pos = leftParent.transform.GetChild(leftParent.transform.childCount - 1).transform.position;
				DestroyLeftChild();
				GameObject obj2 = Instantiate(coffePrefab.gameObject, obj2Pos, Quaternion.Euler(-90, 0, 0)); // yukarý fýrlama efekti için sahte obje
				obj2.transform.DOJump(new Vector3(Random.Range(-50,50), 60, Random.Range(10, 50)), 5, 1, 5f).OnComplete(() => {

					//obj2.transform.DOMoveY(50, 2).OnComplete(() => {
					Destroy(obj2);
				});			
			}
            else
            {
                if (rightParent.transform.childCount==0)
                {
					UIController.instance.LosePanel();
                }
            }
			
			yield return new WaitForSeconds(.05f);
		}		
	}


	public IEnumerator DestroyForRightGate(int adet)
	{

		for (int i = 0; i < adet; i++)
		{
			if (rightParent.transform.childCount > 0)
			{
				Vector3 obj2Pos = rightParent.transform.GetChild(rightParent.transform.childCount - 1).transform.position;
				DestroyRightChild();
				GameObject obj2 = Instantiate(coffePrefab.gameObject, obj2Pos, Quaternion.Euler(-90, 0, 0)); // yukarý fýrlama efekti için sahte obje
				obj2.transform.DOJump(new Vector3(Random.Range(-50, 50), 60, Random.Range(10, 50)), 5, 1, 5f).OnComplete(() => {
					//obj2.transform.DOMoveY(50, 2).OnComplete(() => {
					Destroy(obj2);
				});
			}

			else
			{
				if (leftParent.transform.childCount == 0)
				{
					UIController.instance.LosePanel();
				}
			}

			yield return new WaitForSeconds(.05f);
		}
	}

	public IEnumerator InstantiateForLeftGate(int adet)
	{
		for (int i = 0; i < adet; i++)
		{
			if (leftParent.transform.childCount > 0)
			{
				CreateLeftChild();
			}
			yield return new WaitForSeconds(.05f);
		}
	}

	public IEnumerator InstantiateForRightGate(int adet)
	{
		for (int i = 0; i < adet; i++)
		{
			if (rightParent.transform.childCount > 0)
			{
				CreateRightChild();
			}
			yield return new WaitForSeconds(.05f);
		}
	}



	IEnumerator DelayAndDestroyObj(GameObject obj)
	{
		yield return new WaitForSeconds(2f);
		Destroy(obj);
	}

	IEnumerator DelayAndSetActive(GameObject obj)
	{
		yield return new WaitForSeconds(.2f);
		if(obj != null ) obj.SetActive(true);
	}
}
