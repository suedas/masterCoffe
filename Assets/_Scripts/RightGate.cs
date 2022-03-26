using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Cinemachine;

public class RightGate : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject cupPrefab;

    #region Singleton
    public static RightGate instance;
    //public TextMeshProUGUI RightCount;
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
            StartCoroutine(DestroyMe(4));
            
        }

        else if (other.gameObject.CompareTag("-10"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(10));

        }
        else if (other.gameObject.CompareTag("bölü2"))
        {
            int child = SwerveMovement.instance.rightParent.childCount / 2;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(child));
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
            //vcam.transform.DOShakeRotation(0.2f, 30, fadeOut: true);
            other.GetComponent<Collider>().enabled = false;        
            StartCoroutine(DestroyMe(3));
            if (GameManager.instance.rightParent.transform.childCount>0)
            {
                StartCoroutine(LeftGate.instance.Shake());

            }
            //Debug.Log("engelll");
        }
        #endregion
        #region PozitiveGate
        else if (other.gameObject.CompareTag("+8"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(8));

        }
        else if (other.gameObject.CompareTag("+12"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(12));
        }
        else if (other.gameObject.CompareTag("x3"))
        {
            int child = SwerveMovement.instance.rightParent.childCount * 3;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(child));
        }
        #endregion
    }

    IEnumerator DestroyMe(int adet)
    {
        for (int i = 0; i < adet; i++)
        {
            int count = GameManager.instance.rightParent.transform.childCount;
           // int text = SwerveMovement.instance.rightParent.childCount + 1;

            if (count > 0)
            {
                if(GameManager.instance.yPosRight > .5f)GameManager.instance.yPosRight-=1;
                GameObject obj = GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount  - 1).gameObject;
                Vector3 obj2Pos = obj.transform.position;
                obj.transform.parent = null;
                StartCoroutine(DestroySahteObje(obj));
                GameManager.instance.Coffes.Remove(obj);
                obj.transform.position = new Vector3(0, 100, 0);
                for (int j = 0; j < GameManager.instance.rightParent.transform.childCount; j++)
                {
                    Vector3 position = GameManager.instance.rightParent.transform.GetChild(j).transform.position;
                    GameManager.instance.rightParent.transform.GetChild(j).transform.position =
                        new Vector3(position.x, j - 1, position.z);
                }
                GameObject obj2 = Instantiate(cupPrefab, obj2Pos, Quaternion.identity);
                obj2.transform.DOMoveY(50, 2).OnComplete(() => {
                    Destroy(obj2);
                });
                GameManager.instance.BebeleriSirala();
                //GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount -i- 1).parent = null;
                //GameManager.instance.Coffes.Remove(GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount -i- 1).gameObject);
                //GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount -i- 1).DOMoveY(50,2).OnComplete(()=> {
                //    Destroy(GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount -i- 1).gameObject);
                //});


                count = GameManager.instance.rightParent.transform.childCount;
               // RightCount.text = text.ToString(); 
            }
            yield return new WaitForSeconds(.01f);
        }
        

            
    }
    IEnumerator InstantiateMe(int sayac)
    {
        for (int i = 0; i < sayac; i++)
        {
            int number = GameManager.instance.rightParent.transform.childCount;
           // int text = SwerveMovement.instance.rightParent.childCount + 1;
            if (number > 0)
            {
               
                Vector3 instantateChild = new Vector3(transform.position.x, 0, transform.position.z);
                for (int j = 0; j < GameManager.instance.rightParent.transform.childCount; j++)
                {
                    Vector3 position = GameManager.instance.rightParent.transform.GetChild(j).transform.position;
                    GameManager.instance.rightParent.transform.GetChild(j).transform.position =
                        new Vector3(position.x,j+1,position.z);
                }
                GameObject coffe = Instantiate(cupPrefab, instantateChild, Quaternion.identity, transform);
                GameManager.instance.Coffes.Add(GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount - 1).gameObject);
                coffe.transform.position = new Vector3(coffe.transform.position.x, GameManager.instance.yPosRight, coffe.transform.position.z);
                GameManager.instance.yPosRight+=1;
                // RightCount.text = text.ToString(); 

            }
            GameManager.instance.BebeleriSirala();
            yield return new WaitForSeconds(.01f);
        }
       
    }

    public IEnumerator DestroySahteObje(GameObject obj)
    {
        yield return new WaitForSeconds(2);
        Destroy(obj);

    }
    //IEnumerator Shake()
    //{
    //    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
    //    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
    //    yield return new WaitForSeconds(0.5f);
    //    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    //    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;

    //}
    //private void Update()
    //{
    //    if (SwerveMovement.instance.hareket == true)
    //    {
    //        pingPongRight();
    //    }
    //}
    //public void pingPongRight()
    //{
    //    transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * .3f, .2f), transform.position.z);

    //}
}
