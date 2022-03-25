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
        SwerveMovement.instance.hareket = true;
        PlayerMovement.instance.speed = 4;
        //PlayButton.gameObject.SetActive(false);
        tapToStartPanel.SetActive(false);
        Debug.Log("butona basýldý ");

    }
    public void coffeCountText()
    {
        int rightText = SwerveMovement.instance.rightParent.childCount;
        RightCount.text = rightText.ToString();
        int leftText = SwerveMovement.instance.leftParent.childCount;
        LeftCount.text = leftText.ToString();
    }
    public void LosePanel()
    {
        if (SwerveMovement.instance.Coffes.Count == 0)
        {
            losePanel.SetActive(true);
            PlayerMovement.instance.speed = 0;
        }
    }
    public void WinPanel()
    {
        winPanel.SetActive(true);
        PlayerMovement.instance.speed = 0;

    }
    public void Score()
    {
       int score= SwerveMovement.instance.Coffes.Count;
        ScoreText.text = score.ToString();
    }

}
