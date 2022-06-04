using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Cinemachine;


public class LeftGate : MonoBehaviour
{
    public TextMeshProUGUI LeftCount;
    public CinemachineVirtualCamera vcam;
    public GameObject cupPrefab;

    #region Singleton
    public static LeftGate instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion

    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        #region NegativeGate
        if (other.gameObject.CompareTag("-2"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.DestroyForLeftGate(2));


        }

        else if (other.gameObject.CompareTag("-10"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.DestroyForLeftGate(10));

        }
        else if (other.gameObject.CompareTag("-6"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.DestroyForLeftGate(6));

        }
        else if (other.gameObject.CompareTag("bolu2"))
        {
            int child = GameManager.instance.leftParent.transform.childCount / 2;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.DestroyForLeftGate(child));
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
            other.GetComponent<Collider>().enabled = false;
            if (GameManager.instance.leftParent.transform.childCount>0)
            {
                StartCoroutine(Shake());

            }
            StartCoroutine(GameManager.instance.DestroyForLeftGate(3));
        }
        #endregion
        #region PozitiveGate
        else if (other.gameObject.CompareTag("+8"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(8));

        }
        else if (other.gameObject.CompareTag("+12"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(12));
        }
        else if (other.gameObject.CompareTag("x3"))
        {
            int child = GameManager.instance.rightParent.transform.childCount * 3;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(child));
        }
        else if (other.gameObject.CompareTag("+6"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(6));
        }
        else if (other.gameObject.CompareTag("x2"))
        {
            int child = GameManager.instance.leftParent.transform.childCount * 2;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(child));
        }
        else if (other.gameObject.CompareTag("+7"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(7));
        }
        else if (other.gameObject.CompareTag("+14"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(GameManager.instance.InstantiateForLeftGate(14));
        }
        #endregion
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("-2") || other.gameObject.CompareTag("bolu2") || other.gameObject.CompareTag("x3") || 
    //        other.gameObject.CompareTag("-10") || other.gameObject.CompareTag("+8") || other.gameObject.CompareTag("+12"))
    //    {
    //       // GameManager.instance.BebeleriDiz();
    //    }  
    //}

  //  IEnumerator DestroyMe(int adet)
  //  {

		//for (int i = 0; i < adet; i++)
		//{
		//	while (GameManager.instance.leftParent.transform.childCount > 0)
		//	{
  //              Vector3 obj2Pos = obj.transform.position;
  //              GameManager.instance.DestroyLeftChild();
  //              GameObject obj2 = Instantiate(cupPrefab, obj2Pos, Quaternion.identity); // yukarý fýrlama efekti için sahte obje
  //              obj2.transform.DOMoveY(50, 2).OnComplete(() => {
  //                  Destroy(obj2);
  //              });
  //          }
		//}

  //      for (int i = 0; i < adet; i++)
  //      {
  //          int count = GameManager.instance.leftParent.transform.childCount;
  //          int text = GameManager.instance.leftParent.transform.childCount + 1;

  //          if (count > 0)
  //          {
  //              GameObject obj = GameManager.instance.leftParent.transform.GetChild(0).gameObject;
  //              Vector3 obj2Pos = obj.transform.position;
  //              obj.transform.parent = null;
  //              StartCoroutine(DestroySahteObje(obj));
  //              GameManager.instance.Coffes.Remove(obj);
  //              obj.transform.position = new Vector3(0,100,0);
  //              for (int j = 0; j < GameManager.instance.leftParent.transform.childCount; j++)
  //              {
  //                  Vector3 position = GameManager.instance.leftParent.transform.GetChild(j).transform.position;
  //                  GameManager.instance.leftParent.transform.GetChild(j).transform.position =
  //                      new Vector3(position.x, j - 1, position.z);
  //              }
  //              GameObject obj2 = Instantiate(cupPrefab, obj2Pos, Quaternion.identity); // yukarý fýrlama efekti için sahte obje
  //              obj2.transform.DOMoveY(50, 2).OnComplete(() => {
  //                  Destroy(obj2);
  //              });
                     
  //              count = GameManager.instance.leftParent.transform.childCount;
  //              LeftCount.text = text.ToString(); 
  //          }
  //          else
  //          {
  //              //losePanel
  //          }
  //          yield return new WaitForSeconds(.01f);
  //      }
  //  }


    public IEnumerator InstantiateMe(int sayac)
    {
        for (int i = 0; i < sayac; i++)
        {
            int number = GameManager.instance.leftParent.transform.childCount;
            int text = GameManager.instance.leftParent.transform.childCount + 1;

            if (number > 0)
            {             
                Vector3 instantateChild = new Vector3(transform.position.x, 0, transform.position.z);
                for (int j = 0; j < GameManager.instance.leftParent.transform.childCount; j++)
                {
                    Vector3 position = GameManager.instance.leftParent.transform.GetChild(j).transform.position;
                    GameManager.instance.leftParent.transform.GetChild(j).transform.position =
                        new Vector3(position.x, j + 1, position.z);
                }
                GameObject coffe = Instantiate(cupPrefab, instantateChild, Quaternion.Euler(-90, 0, 0), transform);
                GameManager.instance.Coffes.Add(GameManager.instance.leftParent.transform.GetChild(GameManager.instance.leftParent.transform.childCount - 1).gameObject);
                LeftCount.text = text.ToString();
                coffe.transform.position = new Vector3(coffe.transform.position.x, GameManager.instance.leftParent.transform.GetChild(GameManager.instance.leftParent.transform.childCount - 1).position.y + 1, coffe.transform.position.z);
                //GameManager.instance.yPosLeft+=1;
            }
            yield return new WaitForSeconds(.01f);
        }    
    }

     public IEnumerator Shake()
     {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
        yield return new WaitForSeconds(0.5f);
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
     }

    public IEnumerator DestroySahteObje(GameObject obj)
    {
        yield return new WaitForSeconds(2);
        Destroy(obj);

    }
}
