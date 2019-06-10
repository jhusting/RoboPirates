using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCamScript : MonoBehaviour
{
    public Camera playerCam;
    public GameObject target;
    Vector3 offset;

    private void Start()
    {
        playerCam.enabled = true;
        playerCam.GetComponent<AudioListener>().enabled = true;
        offset = target.transform.position - transform.position;
    }
    private void Update()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * 100);
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (rotation * offset);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        transform.LookAt(target.transform);
    }
}





