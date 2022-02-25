using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f; 
    public Transform player;


    float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //camera horizontal AXIS
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        // camera vertical AXIS
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        

        //camera vertical rotation
        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate,-90f,90f);
        transform.localEulerAngles = Vector3.right*xRotate;

        //camera horizontal rotation
        player.Rotate(Vector3.up*mouseX);
    }
}
