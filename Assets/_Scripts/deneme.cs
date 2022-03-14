using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sol"))
        {
            other.GetComponent<Collider>().enabled = false;
            if (SwerveMovement.instance.leftParent.childCount > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    Destroy(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                    SwerveMovement.instance.Coffes.Remove(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).gameObject);
                    Debug.Log(i);
                }
            }
        }
        else if (other.gameObject.CompareTag("sag"))
        {

        }
    }
}
