using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float offset = 0f;
    public float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotateAmount = new Vector3(0, 0, Mathf.Sin(Time.time + offset) * 0.08f);
        rotateAmount -= 1.5f * rotateAmount;
        transform.Rotate(rotateAmount);
        transform.position += transform.right * -1 * speed;
    }

    
}
