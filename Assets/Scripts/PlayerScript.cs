using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int posSpeed = 20;
    public Camera playerCam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * posSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * posSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * posSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * posSpeed * Time.deltaTime);
        }
        //Rotation
        if (true)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            //transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
        //Sprint Modifier
        if (Input.GetKey(KeyCode.LeftShift))
        {
            posSpeed = 40;
        }
        else
        {
            posSpeed = 20;
        }
        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 30 * Time.deltaTime);
        }
        //Fall
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * 30 * Time.deltaTime);
        }
    }
}




