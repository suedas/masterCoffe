using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public int coin;
    public GameObject para;
    public Transform paraTarget;
    public int lastMoney;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            // oyun sonu olaylari... animasyon.. score.. panel acip kapatmak
            // oyunu kazandi mi kaybetti mi kontntrolu gerekirse yapilabilir.
            // player durdurulur
            //PlayerMovement.instance.speed = 0;
            GameManager.instance.isContinue = false;
            GameManager.instance.hareket = false;
            //GameManager.instance.yPosLeft = 0;
            //GameManager.instance.yPosRight = 0;
            StartCoroutine(EndGame.instance.IncreaseTime());
            //kahvelerin hareketini de durdur
            UIController.instance.leftImage.SetActive(false);
            UIController.instance.rightImage.SetActive(false);

            coin = GameManager.instance.Coffes.Count;
            lastMoney = System.Int32.Parse(UIController.instance.ScoreText.text);


        }
        else if (other.CompareTag("customer"))
        {
            other.GetComponent<Collider>().enabled = false;
            EndGame.instance.ServisEt(other.gameObject);
            GameObject obj = Instantiate(para, other.transform.position, Quaternion.identity);
            obj.transform.DOMove(paraTarget.transform.position, .5f);
            obj.transform.DOScale(2f, .48f).OnComplete(() => 
            {
                lastMoney += 2;
                UIController.instance.ScoreText.text = lastMoney.ToString();
                Destroy(obj);
            });

        }
    }
}
