using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    //public Rigidbody leftHand, rightHand;
    bool sagdanGit;
   
    //Vector3 goLeft;
    //Vector3 goRight;
    //int listCount = SwerveMovement.instance.Coffes.Count;
    #region Singleton
    public static EndGame instance;
    //public TextMeshProUGUI RightCount;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion
   
    public void ServisEt(GameObject other)
    {
        if (GameManager.instance.leftParent.transform.childCount > 0 || GameManager.instance.rightParent.transform.childCount > 0)//GameManager.instance.Coffes.Count>0)
        {
            if (sagdanGit)
            {
                if (GameManager.instance.rightParent.transform.childCount > 0)
                {
                    GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount - 1).transform.DOJump(new Vector3( other.transform.position.x,other.transform.position.y+.2f,other.transform.position.z), 2, 1, .5f);
                    sagdanGit = false;
                    GameManager.instance.Coffes.Remove(GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount - 1).gameObject);
                    GameManager.instance.rightParent.transform.GetChild(GameManager.instance.rightParent.transform.childCount - 1).transform.parent = null;
                   
                }
                else
                {

                    sagdanGit = false;
                    ServisEt(other);
                }
            }
            else if (!sagdanGit)
            {
                if (GameManager.instance.leftParent.transform.childCount > 0)
                {
                    GameManager.instance.leftParent.transform.GetChild(GameManager.instance.leftParent.transform.childCount - 1).transform.DOJump(new Vector3(other.transform.position.x, other.transform.position.y + .2f, other.transform.position.z), 2, 1, .5f);
                    sagdanGit = true;
                    GameManager.instance.Coffes.Remove(GameManager.instance.leftParent.transform.GetChild(GameManager.instance.leftParent.transform.childCount - 1).gameObject);
                    GameManager.instance.leftParent.transform.GetChild(GameManager.instance.leftParent.transform.childCount - 1).transform.parent = null;
                    
                }
                else
                {
                    sagdanGit = true;
                    ServisEt(other);
                }
            }
        }
        else if (GameManager.instance.leftParent.transform.childCount==0 && GameManager.instance.rightParent.transform.childCount == 0)
        {
            PlayerMovement.instance.speed = 0;
            GameManager.instance.hareket = false;
            GameManager.instance.isContinue = false;
            StopCoroutine(IncreaseTime());
            UIController.instance.WinPanel();
        }
        //else 
        //{
        //    Debug.Log("wdjkhjfjhdbfhdhfsdhfdhfjh");
        //    StopCoroutine(IncreaseTime());
        //    PlayerMovement.instance.speed = 0;
        //    GameManager.instance.hareket = false;  
        //    UIController.instance.WinPanel();
        //}
        
    }

   public IEnumerator IncreaseTime()
    {
        PlayerMovement.instance.speed = 2;
        yield return new WaitForSeconds(.1f);
        while (GameManager.instance.Coffes.Count > 0)
        {
            if (PlayerMovement.instance.speed <= 15)
            {
                PlayerMovement.instance.speed += 0.1f;

            }
            yield return new WaitForSeconds(.05f);
        }




    }


    //IEnumerator Stop()
    //{

    //    //leftHand.AddForce(0, 0, 25, ForceMode.Acceleration);
    //    //rightHand.AddForce(0, 0, 25, ForceMode.Acceleration);
    //    float leftPosZ = 121;
    //    float rightPosZ = 121;
    //    yield return new WaitForSeconds(3f);
    //    for (int i = 0; i < listCount; i++)
    //    {
    //        //sondaki coffe alinmali burda bastaki coffe aliniyor.
    //        //zamanlama ayarlanmali
    //        if (i % 2 == 0)
    //        {
    //            SwerveMovement.instance.Coffes[listCount - i - 1].transform.parent = null;

    //            goLeft = new Vector3(-3, 0.5f, leftPosZ);
    //            //SwerveMovement.instance.Coffes[listCount-i-1].transform.position= goLeft;
    //            SwerveMovement.instance.Coffes[listCount - i - 1].transform.DOJump(goLeft,2f,1,1f);
    //            yield return new WaitForSeconds(.5f);
    //            leftPosZ += 2;
    //            Debug.Log("sola git");
    //        }
    //        if (i % 2 == 1)
    //        {
    //            SwerveMovement.instance.Coffes[listCount - i - 1].transform.parent = null;


    //            goRight = new Vector3(3, 0.5f, rightPosZ);
    //            //SwerveMovement.instance.Coffes[listCount - i-1].transform.position = goRight;
    //            SwerveMovement.instance.Coffes[listCount - i - 1].transform.DOJump(goRight, 2f, 1, 1f);
    //            yield return new WaitForSeconds(.5f);
    //            rightPosZ += 2;
    //            Debug.Log("saga git");
    //        }
    //        if (SwerveMovement.instance.leftParent.childCount == 0 && SwerveMovement.instance.rightParent.childCount == 0)
    //        {
    //            rightHand.velocity = Vector3.zero;
    //            leftHand.velocity = Vector3.zero;
    //            yield return new WaitForSeconds(.5f);
    //            winPanel.SetActive(true);

    //        }
    //    }


    //}
}
