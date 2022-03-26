using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    public GameObject tapToStartPanel, losePanel, winPanel;
    public TextMeshProUGUI RightCount, LeftCount,ScoreText;
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
        PlayerMovement.instance.speed = 4;

        // .gameObject.SetActive(false);
        tapToStartPanel.SetActive(false);
        Debug.Log("butona basýldý ");

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
        if (GameManager.instance.Coffes.Count == 0 && GameManager.instance.hareket==true)
        {
            
            losePanel.SetActive(true);
            GameManager.instance.hareket = false;
            PlayerMovement.instance.speed = 0;
            RetryClickButton();
            
        }
    }
    public void WinPanel()
    {
        winPanel.SetActive(true);
       // PlayerMovement.instance.speed = 0;

    }
    public void Score()
    {
       int score= GameManager.instance.Coffes.Count;
        ScoreText.text = score.ToString();
    }
    public void RetryClickButton()
    {
        //ayný levelý tekrar aç
        Debug.Log("kaybettin");
        LevelController.instance.RestartLevelEvents();
        //losePanel.SetActive(false);
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
}
