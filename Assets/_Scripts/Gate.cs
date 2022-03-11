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
        {//listeden de sil

            //kontrolü unutma child ý var mý diye 
            if (SwerveMovement.instance.leftParent.childCount > 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                    SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);

                }
                // Debug.Log("ssssssss");
                //Transform child = gameObject.transform.GetChild(transform.childCount - 3);
                //Destroy(child.gameObject);

                //Debug.Log("sol" + SwerveMovement.instance.Coffes.Count);


            }
            else
            {
                if (SwerveMovement.instance.Coffes.Count < 0)
                {
                    //losePanel
                }
            }


            if (SwerveMovement.instance.rightParent.childCount > 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                    SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);

                }
            }
            else
            {
                if (SwerveMovement.instance.Coffes.Count < 0)
                {
                    //losePanel
                }

            }

        }

        else if (other.gameObject.CompareTag("-10"))
        {
           

            if (SwerveMovement.instance.rightParent.childCount > 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                    SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);

                }
            }
            else
            {
                if (SwerveMovement.instance.Coffes.Count < 0)
                {
                    //losePanel
                }
            }

        }
        else if (other.gameObject.CompareTag("bölü2"))
        {
            



            if (SwerveMovement.instance.rightParent.childCount > 1)
            {
                int child = SwerveMovement.instance.rightParent.childCount;
                for (int i = 0; i < child / 2; i++)
                {
                    Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                    SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);


                }
            }
            else
            {
                if (SwerveMovement.instance.Coffes.Count < 0)
                {
                    //losePanel
                }
            }




        }
        #endregion
        #region PozitiveGate
        else if (other.gameObject.CompareTag("+8"))
        {

            if (SwerveMovement.instance.leftParent.childCount > 0)
            {
                other.GetComponent<Collider>().enabled = false;
                for (int i = 0; i < 8; i++)
                {
                    Vector3 instantateChild = new Vector3(transform.position.x, SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                       leftParent.transform.childCount - 1).transform.position.y + .4f, transform.position.z);
                    Instantiate(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                       leftParent.transform.childCount - 1).gameObject, instantateChild, Quaternion.identity, transform);
                    SwerveMovement.instance.Coffes.Add(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                }

            }



        }
        else if (other.gameObject.CompareTag("+12"))
        {
            if (SwerveMovement.instance.leftParent.childCount > 0)
            {
                other.GetComponent<Collider>().enabled = false;
                for (int i = 0; i < 12; i++)
                {
                    Vector3 instantateChild = new Vector3(transform.position.x, SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                       leftParent.transform.childCount - 1).transform.position.y + .4f, transform.position.z);
                    Instantiate(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                       leftParent.transform.childCount - 1).gameObject, instantateChild, Quaternion.identity, transform);
                    SwerveMovement.instance.Coffes.Add(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                }


            }
        }
        else if (other.gameObject.CompareTag("x3"))
        {
            Debug.Log("x3 kkapýsýna çarptý");

            if (SwerveMovement.instance.rightParent.childCount > 0)
            {
                Debug.Log("x3 saðýnda");
                int child = SwerveMovement.instance.rightParent.childCount;
                other.GetComponent<Collider>().enabled = false;
                for (int i = 0; i < child * 3; i++)
                {
                    Vector3 instantateChild = new Vector3(transform.position.x, SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.
                       rightParent.transform.childCount - 1).transform.position.y + .4f, transform.position.z);
                    Instantiate(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.
                       rightParent.transform.childCount - 1).gameObject, instantateChild, Quaternion.identity, transform);
                    SwerveMovement.instance.Coffes.Add(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                }
            }
        }

            #endregion

    }
}



