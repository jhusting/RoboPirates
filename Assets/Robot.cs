using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Vector3 startPos;
    public float speed;
    public Vector3 endOffset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var step =  Mathf.Lerp(0,  endOffset.magnitude, Mathf.Sin(Time.time + speed));
        transform.localPosition = startPos + endOffset.normalized * step;
        
    }
}
