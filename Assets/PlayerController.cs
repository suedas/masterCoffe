using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion
    float time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            // score islemleri.. animasyon.. efect.. collectiblen destroy edilmesi.. 
            Debug.Log("collectible");

        }
        else if (other.CompareTag("obstacle"))
        {
            // score islemleri.. animasyon.. efect.. obstaclein destroy edilmesi.. 
            // oyun bitebilir bunun kontrolu de burada yapilabilir..
            Debug.Log("obstacle");
        }
        else if (other.CompareTag("finish"))
        {
            // oyun sonu olaylari... animasyon.. score.. panel acip kapatmak
            // oyunu kazandi mi kaybetti mi kontntrolu gerekirse yapilabilir.
            // player durdurulur

            PlayerMovement.instance.speed = 0;
            float x = -3f;
            float z = 121f;
            time += Time.deltaTime;
            float lerptime = time / 3f;
            Vector3 endLevel = new Vector3(x, 1.02f, z);
            for (int i = 0; i < 3; i++)
            {
                SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.leftParent.transform.childCount - 1).transform.position 
                    = Vector3.Lerp(SwerveMovement.instance.leftParent.transform.GetChild(SwerveMovement.instance.
                       leftParent.transform.childCount - 1).transform.position, endLevel, lerptime);
                z += 2;
            }

            GameManager.instance.isContinue = false;


        }
    }
}
