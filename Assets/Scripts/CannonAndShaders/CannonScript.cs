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

    Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        StartCoroutine(CannonRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
            FireCannon();

        if (bCanFire)
            StartCoroutine(CannonRoutine());
        */
    }

    IEnumerator CannonRoutine()
    {
        while (true)
        {
            if (Random.Range(0, 10) < 4f)
            {
                FireCannon();
                var rout = StartCoroutine(SquashAndSquishRoutine());
                yield return new WaitForSeconds(1f);
                StopCoroutine(rout);
                
            }
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    }

    IEnumerator SquashAndSquishRoutine()
    {
        while (true)
        {
            SquashAndSquish();
            yield return null;
        }
    }
    void SquashAndSquish()
    {
        currLifeTime += Time.deltaTime;
        Vector3 CurrScale = transform.localScale;

        CurrScale.x = defaultScale.x + LongCurve.Evaluate(currLifeTime / CoolDown);
        CurrScale.y = defaultScale.y - LongCurve.Evaluate(currLifeTime / CoolDown);
        CurrScale.z = defaultScale.z + LongCurve.Evaluate(currLifeTime / CoolDown);

        transform.localScale = CurrScale;
    }

    void FireCannon()
    {
        bCanFire = false;
        currLifeTime = 0f;

        Vector3 CurrPos = transform.position + (transform.forward * 1.1f * transform.localScale.x);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.y -= 90f;

        GameObject part = Instantiate(CannonBallPrefab, CurrPos, Quaternion.Euler(rot)) as GameObject;
        //GameObject part = Instantiate(CannonBallPrefab, transform);
        //part.transform.parent = transform;
        //part.transform.localScale = new Vector3(25f, 25f, 25f);
    }
}
