using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftGate : MonoBehaviour
{
    public TMP_Text LeftCount;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        #region NegativeGate
        if (other.gameObject.CompareTag("-2"))
        {
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyMe(2));
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
            int count = SwerveMovement.instance.leftParent.childCount;
            int text = SwerveMovement.instance.leftParent.childCount + 1;

            if (count > 0)
            {
                Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                count = SwerveMovement.instance.leftParent.childCount;
                LeftCount.text = text.ToString(); 
            }
            yield return new WaitForSeconds(.05f);
        }
    }
    IEnumerator InstantiateMe(int sayac)
    {
        for (int i = 0; i < sayac; i++)
        {
            int number = SwerveMovement.instance.leftParent.childCount;
            int text = SwerveMovement.instance.leftParent.childCount + 1;

            if (number > 0)
            {
                Vector3 instantateChild = new Vector3(transform.position.x, SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                          leftParent.transform.childCount - 1).transform.position.y + .4f, transform.position.z);
                Instantiate(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                   leftParent.transform.childCount - 1).gameObject, instantateChild, Quaternion.identity, transform);
                SwerveMovement.instance.Coffes.Add(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                LeftCount.text = text.ToString();

            }
            yield return new WaitForSeconds(.05f);
        }
        
    }
}
