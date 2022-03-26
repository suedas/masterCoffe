using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton
    public static PlayerMovement instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion
    public float speed = 1f;
    private CinemachineVirtualCamera vcam;
    private void Update()
    {
        //Transform ss = SwerveMovement.instance.Coffes[SwerveMovement.instance.Coffes.Count / 2].gameObject.transform;
            transform.Translate(0, 0, speed * Time.deltaTime);
           // vcam.LookAt = ss;

             
    }

}
