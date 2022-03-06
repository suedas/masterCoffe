using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("-2") )
        {//listeden de silencek mi
       
            if (GameObject.FindWithTag("sol"))
            {
                Debug.Log("ssssssss");
                int child=gameObject.transform.childCount-2;
                Debug.Log(child + "   child");

            }
            else if (GameObject.FindWithTag("sag"))
            {

            }
        }

       
    }
}
