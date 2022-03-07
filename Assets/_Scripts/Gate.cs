using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        #region NegativeGate
        if (other.gameObject.CompareTag("-2"))
        {//listeden de silencek mi

            if (GameObject.FindWithTag("sol"))
            {//kontrolü unutma child ý var mý diye 
                if (SwerveMovement.instance.leftParent.childCount > 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);


                    }
                    Debug.Log("ssssssss");
                    //Transform child = gameObject.transform.GetChild(transform.childCount - 3);
                    //Destroy(child.gameObject);

                    Debug.Log("sol" + SwerveMovement.instance.leftParent.childCount);


                }
                else
                {
                    //losePanel
                }


            }
            else if (GameObject.FindWithTag("sag"))
            {
                if (SwerveMovement.instance.rightParent.childCount > 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);


                    }
                }
                else
                {
                    //losePanel
                }
            }
        }

        else if (other.gameObject.CompareTag("-10"))
        {
            if (GameObject.FindWithTag("sol"))
            {//kontrolü unutma child ý var mý diye 
                if (SwerveMovement.instance.leftParent.childCount > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);


                    }

                }
                else
                {
                    //losePanel
                }

            }
            else if (GameObject.FindWithTag("sag"))
            {
                if (SwerveMovement.instance.rightParent.childCount > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);


                    }
                }
                else
                {
                    //losePanel
                }
            }
        }
        else if (other.gameObject.CompareTag("bölü2"))
        {
            if (GameObject.FindWithTag("sol"))
            {//kontrolü unutma child ý var mý diye 
                if (SwerveMovement.instance.leftParent.childCount > 1)
                {
                    for (int i = 0; i < SwerveMovement.instance.leftParent.childCount / 2; i++)
                    {
                        Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);


                    }

                }
                else
                {
                    //losePanel
                }

            }
            else if (GameObject.FindWithTag("sag"))
            {
                if (SwerveMovement.instance.rightParent.childCount > 1)
                {
                    for (int i = 0; i < SwerveMovement.instance.leftParent.childCount / 2; i++)
                    {
                        Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);


                    }
                }
                else
                {
                    //losePanel
                }



            }
        }
        #endregion
        #region PozitiveGate
        #endregion
    }
}
