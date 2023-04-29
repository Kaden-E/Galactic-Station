using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLook : MonoBehaviour
{
    [FormerlySerializedAs("_cam")] public Camera cam;
    public float xRotation = 0f;

    public float xSens = 30f;
    public float ySens = 30f;

    public void ProcessLook(Vector2 input)
    {
        var mouseX = input.x;
        var mouseY = input.y; 

        xRotation -= (mouseY * Time.deltaTime) * ySens;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSens));
    }


}
