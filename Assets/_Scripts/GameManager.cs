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
	public int yPosRight, yPosLeft;
	public GameObject leftParent, rightParent;
	Vector3 mousePosition, tempMousePosition;
	public bool isContinue;
	public List<GameObject> Coffes = new List<GameObject>();

	private void Start()
	{
		hareket = true;
		DOTween.Init();
		yPosLeft = leftParent.transform.childCount;
		yPosRight = rightParent.transform.childCount;
		isContinue = true;
        for (int i = 0; i < leftParent.transform.childCount; i++)
        {
			Coffes.Add(leftParent.transform.GetChild(i).gameObject);
        }
		for (int i = 0; i < rightParent.transform.childCount; i++)
		{
			Coffes.Add(rightParent.transform.GetChild(i).gameObject);
		}
	}

	private void Update()
	{
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
		yield return new WaitForSeconds(.05f);
		isContinue = true;
	}


	void Aktar()
	{
		if (isRight) // saða sürükleniyorsa
		{
			if (leftParent.transform.childCount > 0)
			{
				StartCoroutine(SagaGit(leftParent.transform.GetChild(leftParent.transform.childCount - 1).gameObject));
				leftParent.transform.GetChild(leftParent.transform.childCount - 1).parent = rightParent.transform;
			}
		}
		else if (!isRight) // sola sürükleniyorsa
		{
			if (rightParent.transform.childCount > 0)
			{
				StartCoroutine(SolaGit(rightParent.transform.GetChild(rightParent.transform.childCount - 1).gameObject));
				rightParent.transform.GetChild(rightParent.transform.childCount - 1).parent = leftParent.transform;
			}
		}
	}

	IEnumerator SagaGit(GameObject obj)
	{
		Vector3 position;
		float sayac = 0;
		if (rightParent.transform.childCount > 0)
		{
			position = new Vector3(2, rightParent.transform.childCount, 0);
		}
		else
		{
			position = rightParent.transform.position;
		}
		while (obj.transform.position.x < 2 && isRight)
		{
			float y = Mathf.Lerp(yPosLeft, position.y, sayac);
			sayac += .05f;
			obj.transform.position = new Vector3(obj.transform.position.x + .2f, y + Ypos(obj.transform.position.x), obj.transform.position.z);
			obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (2 - obj.transform.position.x) * 90));
			yield return new WaitForSeconds(.01f);
		}
		
		obj.transform.rotation = Quaternion.Euler(Vector3.zero);
		Scale(obj);
		obj.transform.position = new Vector3(2, yPosRight, obj.transform.position.z);
		yPosRight += 1;
		yPosLeft -= 1;
		BebeleriSirala();
	}

	IEnumerator SolaGit(GameObject obj)
	{
		Vector3 position;
		float sayac = 0;
		if (leftParent.transform.childCount > 0)
		{
			position = new Vector3(2, leftParent.transform.childCount, 0);
		}
		else
		{
			position = leftParent.transform.position;
		}
		while (obj.transform.position.x > -2 && !isRight)
		{
			float y = Mathf.Lerp(yPosRight, position.y, sayac);
			sayac += .05f;
			obj.transform.position = new Vector3(obj.transform.position.x - .2f, y + Ypos(obj.transform.position.x), obj.transform.position.z);
			obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (2 - obj.transform.position.x) * 90));
			yield return new WaitForSeconds(.01f);
		}
		obj.transform.position = new Vector3(-2, yPosLeft, obj.transform.position.z);
		obj.transform.rotation = Quaternion.Euler(Vector3.zero);
		Scale(obj);
		yPosRight -= 1;
		yPosLeft += 1;
		BebeleriSirala();
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
}
