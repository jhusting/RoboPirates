using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public int RangeStart = 0;
    public int RangeEnd = 0;
    public GameObject CannonBallPrefab;
    public AnimationCurve LongCurve;
    public float Sensitivity = 0.15f;
    public bool bPrint = false;

    public float CoolDown = 0.3f;

    private float currLifeTime = 0f;
    private bool bCanFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!bCanFire)
        {
            currLifeTime += Time.deltaTime;

            SquashAndSquish();

            if (currLifeTime > CoolDown)
            {
                bCanFire = true;
            }
        }

        /*float total = 0;

        for (int i = RangeStart; i <= RangeEnd; ++i)
        {
            total += AudioPeer.spectrumData[i];
        }

        total /= RangeEnd - RangeStart + 1;

        if (bPrint)
            Debug.Log(total);

        if (total > Sensitivity && bCanFire)
            FireCannon();*/

        if (bCanFire)
            FireCannon();

    }

    void SquashAndSquish()
    {
        Vector3 CurrScale = transform.localScale;

        CurrScale.x = 1f + LongCurve.Evaluate(currLifeTime / CoolDown);
        CurrScale.y = 1f - LongCurve.Evaluate(currLifeTime / CoolDown);
        CurrScale.z = 1f + LongCurve.Evaluate(currLifeTime / CoolDown);

        transform.localScale = CurrScale;
    }

    void FireCannon()
    {
        bCanFire = false;
        currLifeTime = 0f;

        Vector3 CurrPos = transform.position + (transform.forward * 1.1f * transform.localScale.x);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.y -= 90f;

        Instantiate(CannonBallPrefab, CurrPos, Quaternion.Euler(rot));
    }
}
