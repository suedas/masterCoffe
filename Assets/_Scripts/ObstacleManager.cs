using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="coffe")
        {
            StartCoroutine(LeftGate.instance.Shake());

            other.GetComponent<Collider>().enabled = false;
            if (GameManager.instance.Coffes.Count> 0)
            {
                if (gameObject.transform.position.x>0)
                {
                    StartCoroutine(GameManager.instance.DestroyForRightGate(3));

                }
                else
                {
                    StartCoroutine(GameManager.instance.DestroyForLeftGate(3));
 
                }
            }
        }
    }
    
}
