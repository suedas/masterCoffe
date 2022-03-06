using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    private void Update()
    {

        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
