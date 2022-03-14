using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RightGate : MonoBehaviour
{
    public TMP_Text RightCount;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        #region NegativeGate
        if (other.gameObject.CompareTag("-2"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(4));
        }

        else if (other.gameObject.CompareTag("-10"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(10));

        }
        else if (other.gameObject.CompareTag("bölü2"))
        {
            int child = SwerveMovement.instance.rightParent.childCount / 2;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(child));
        }
        #endregion
        #region PozitiveGate
        else if (other.gameObject.CompareTag("+8"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(8));

        }
        else if (other.gameObject.CompareTag("+12"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(12));
        }
        else if (other.gameObject.CompareTag("x3"))
        {
            int child = SwerveMovement.instance.rightParent.childCount * 3;
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(InstantiateMe(child));
        }
        #endregion
    }

    IEnumerator DestroyMe(int adet)
    {
        for (int i = 0; i < adet; i++)
        {
            int count = SwerveMovement.instance.rightParent.childCount;
            if (count > 0)
            {
                Destroy(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
                count = SwerveMovement.instance.rightParent.childCount;
                RightCount.text = count.ToString(); //yanlis deger
            }
            yield return new WaitForSeconds(.05f);
        }
    }
    IEnumerator InstantiateMe(int sayac)
    {
        int number = SwerveMovement.instance.rightParent.childCount;
        if (number > 0)
        {
            Vector3 instantateChild = new Vector3(transform.position.x, SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.
                      rightParent.transform.childCount - 1).transform.position.y + .4f, transform.position.z);
            Instantiate(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.
               rightParent.transform.childCount - 1).gameObject, instantateChild, Quaternion.identity, transform);
            SwerveMovement.instance.Coffes.Add(SwerveMovement.instance.rightParent.transform.GetChild(SwerveMovement.instance.rightParent.transform.childCount - 1).gameObject);
            RightCount.text = number.ToString(); //yanlis deger

        }
        yield return new WaitForSeconds(.05f);
    }
}
