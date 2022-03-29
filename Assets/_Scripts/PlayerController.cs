using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion
    float time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            // score islemleri.. animasyon.. efect.. collectiblen destroy edilmesi.. 
            Debug.Log("collectible");

        }
        else if (other.CompareTag("obstacle"))
        {
            // score islemleri.. animasyon.. efect.. obstaclein destroy edilmesi.. 
            // oyun bitebilir bunun kontrolu de burada yapilabilir..
            Debug.Log("obstacle");
        }
        else if (other.CompareTag("finish"))
        {
            // oyun sonu olaylari... animasyon.. score.. panel acip kapatmak
            // oyunu kazandi mi kaybetti mi kontntrolu gerekirse yapilabilir.
            // player durdurulur
            //PlayerMovement.instance.speed = 0;
            GameManager.instance.isContinue = false;
            GameManager.instance.hareket = false;
            GameManager.instance.yPosLeft = 0;
            GameManager.instance.yPosRight = 0;
            StartCoroutine(EndGame.instance.IncreaseTime());
            //kahvelerin hareketini de durdur
            UIController.instance.LeftCount.enabled = false;
            UIController.instance.RightCount.enabled = false;
            Debug.Log("btis cizgisindeki count" + " " + GameManager.instance.Coffes.Count);
            Debug.Log("left parent" + "" + GameManager.instance.leftParent.transform.childCount);
            Debug.Log("right parent" + "" + GameManager.instance.rightParent.transform.childCount);

          


        }
        else if (other.CompareTag("customer"))
        {
            other.GetComponent<Collider>().enabled = false;
           EndGame.instance.ServisEt(other.gameObject);
        }
    }
}
