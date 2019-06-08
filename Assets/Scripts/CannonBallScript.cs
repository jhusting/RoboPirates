using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    private float LifeTime = 0.6f;
    private float CurrLife = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrLife += Time.deltaTime;

        if (CurrLife > LifeTime)
            Destroy(this.gameObject);
    }
}
