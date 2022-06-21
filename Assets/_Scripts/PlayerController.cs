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
        {   coin = GameManager.instance.Coffes.Count;
            lastMoney = System.Int32.Parse(UIController.instance.ScoreText.text);
            GameManager.instance.isContinue = false;
            //GameManager.instance.hareket = false;
            UIController.instance.leftImage.SetActive(false);
            UIController.instance.rightImage.SetActive(false);

            // oyun sonu olaylari... animasyon.. score.. panel acip kapatmak
            // oyunu kazandi mi kaybetti mi kontntrolu gerekirse yapilabilir.
            // player durdurulur
            //PlayerMovement.instance.speed = 0;

            StartCoroutine(EndGame.instance.IncreaseTime());

            //if (coin > 0)
            //{
            //    StartCoroutine(EndGame.instance.IncreaseTime());
            //}
            //else
            //{
            //    UIController.instance.LosePanel();
            //}




        }
        else if (other.CompareTag("customer"))
        {
            other.GetComponent<Collider>().enabled = false;
            EndGame.instance.ServisEt(other.gameObject);
            GameObject obj = Instantiate(para, other.transform.position, Quaternion.identity);
            obj.transform.DOMove(paraTarget.transform.position, .5f);
            obj.transform.DOScale(4f, .48f).OnComplete(() => 
            {
                lastMoney += 2;
                UIController.instance.ScoreText.text = lastMoney.ToString();
                Destroy(obj);
            });

        }
    }
}
