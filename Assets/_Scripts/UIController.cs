using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class UIController : MonoBehaviour
{
    public GameObject tapToStartPanel, losePanel, winPanel,rightImage,leftImage;
    public TextMeshProUGUI RightCount, LeftCount,ScoreText,LevelText;
   
    public Animator anim;
    //public GameObject leftHand, rightHand;
    #region Singleton
    public static UIController instance;
    //public TextMeshProUGUI RightCount;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion
    public void tapToStart()
    {
        GameManager.instance.hareket = true;
        GameManager.instance.isContinue = true;
        PlayerMovement.instance.speed = 7;
        // .gameObject.SetActive(false);
        tapToStartPanel.SetActive(false);
       // Debug.Log("baþlarken coffe sayýsý "+" "+ GameManager.instance.Coffes.Count);
        //LeftCount.enabled = true;
        //RightCount.enabled =true;
        leftImage.SetActive(true);
        rightImage.SetActive(true);

    }
    public void coffeCountText()
    {
        int rightText = GameManager.instance.rightParent.transform.childCount;
        RightCount.text = rightText.ToString();
        int leftText = GameManager.instance.leftParent.transform.childCount;
        LeftCount.text = leftText.ToString();
    }
    public void LosePanel()
    {
       // if (GameManager.instance.Coffes.Count == 0 && GameManager.instance.hareket==true)
        //{
            
             losePanel.SetActive(true);
            //LeftCount.enabled = false;
            //RightCount.enabled = false;
            leftImage.SetActive(false);
            rightImage.SetActive(false);
            GameManager.instance.hareket = false;
            PlayerMovement.instance.speed = 0;
           // RetryClickButton();
            
       // }
    }
    public void WinPanel()
    {
        winPanel.SetActive(true);
        PlayerMovement.instance.speed = 0;
        GameManager.instance.hareket = false;
        RightCount.text ="0";
        LeftCount.text = "4";

    }
    public void Score()
    {
       int score= GameManager.instance.Coffes.Count;
        ScoreText.text = score.ToString();
    }
   
    public void NextLevelClickButton()
    {
        //level gönder
        Debug.Log("level gönder");
        LevelController.instance.NextLevelEvents();
    }
    public void ClickPlayBtn()
    {
        tapToStart();
    }
    public void clickbuton()
    {
        anim.SetBool("isTrue",true);
        //StartCoroutine(coin());
    }
    //IEnumerator coin()
    //{
     
    //    for (int i = 0; i < PlayerController.instance.coin; i++)
    //    {
    //        LevelController.instance.öncekicoin += i;

    //        yield return new WaitForSeconds(.2f);
    //    }
    //    UIController.instance.ScoreText.text = LevelController.instance.öncekicoin.ToString();


    //}
}
