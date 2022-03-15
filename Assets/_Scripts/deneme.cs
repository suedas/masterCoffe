using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public Rigidbody leftHand, rightHand;
    void OyunSonu()
    {
        
    }
    Vector3 goLeft;
    Vector3 goRight;
    int listCount = SwerveMovement.instance.Coffes.Count;

    private void OnTriggerEnter(Collider other)
    {
               
        if (other.CompareTag("finish"))
        {
            
            LeftGate.instance.LeftCount.enabled = false;
            RightGate.instance.RightCount.enabled = false;
           
            StartCoroutine(Stop());
           

        }
    }
    IEnumerator Stop()
    {
        PlayerMovement.instance.speed = 0;
        yield return new WaitForSeconds(.5f);
        leftHand.AddForce(0, 0, 50,ForceMode.Acceleration);
        rightHand.AddForce(0, 0, 50,ForceMode.Acceleration);
        float leftPosZ = 121;
        float rightPosZ = 121;
        for (int i = 0; i < listCount; i++)
        {
            if (i % 2 == 0)
            {
                SwerveMovement.instance.Coffes[i].transform.parent = null;

                goLeft = new Vector3(-3, 0.5f, leftPosZ);
                SwerveMovement.instance.Coffes[i].transform.position = goLeft;
                yield return new WaitForSeconds(.25f);
                leftPosZ += 2;
                Debug.Log("sola git");
            }
            if (i % 2 == 1)
            {
                SwerveMovement.instance.Coffes[i].transform.parent = null;

                goRight = new Vector3(3, 0.5f, rightPosZ);
                SwerveMovement.instance.Coffes[i].transform.position = goRight;
                yield return new WaitForSeconds(.25f);
                rightPosZ += 2;
                Debug.Log("saga git");
            }
            if (SwerveMovement.instance.leftParent.childCount == 0 && SwerveMovement.instance.rightParent.childCount == 0)
            {
             
                rightHand.velocity = Vector3.zero;
                leftHand.velocity = Vector3.zero;
            }
        }
        

    }

}
