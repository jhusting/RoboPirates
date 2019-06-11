using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int posSpeed = 1;
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
            posSpeed = 10;
        }
        else
        {
            posSpeed = 5;
        }
        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl)) //Fall
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
        else
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
    }
}




