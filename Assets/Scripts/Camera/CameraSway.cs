using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public float swayAmount = 0.01f; 
    public float swaySpeed = 1.0f;



    private void Start()
    {

    }
    private void Update ( )
    {
        float swayX = Mathf.PerlinNoise(Time.time * swaySpeed, 0) * 2 - 1; 
        float swayY = Mathf.PerlinNoise(0, Time.time * swaySpeed) * 2 - 1; 

        transform.position += new Vector3 (swayX, swayY, 0) * swayAmount;
        if (Input.GetKey("e"))
        {
            swaySpeed = 2f;
        }
        else
        {
            swaySpeed = 1f;
        }
    }
  
}
