using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Hv_finalfinalsong_AudioLib pd;

    bool isSpawned = false;

    public GameObject goodShip;
    public GameObject enemyShip;

    // Start is called before the first frame update
    void Start()
    {

        pd = GetComponent<Hv_finalfinalsong_AudioLib>();

        pd.FillTableWithFloatBuffer("strings", new float[] { 1, 40, 45, 50, 55, 59, 64 });
        pd.FillTableWithFloatBuffer("notes", new float[] { 0, 8, 2, 4, 5, 7, 9, 11, 12});

        pd.FillTableWithFloatBuffer("bass", new float[] { 0, 300, 0, 300, 0, 201, 0 , 203, 0, 203, 0, 300, 0 });
        pd.FillTableWithFloatBuffer("percussion", new float[] { 0, 300, 0, 300, 0, 201, 0, 203, 0, 203, 0, 300, 0 });

        pd.FillTableWithFloatBuffer("melody", new float[] { 0, 402,501 ,503, 503, 503, 600, 601, 601, 603, 600, 603 });


        pd.SendEvent(Hv_finalfinalsong_AudioLib.Event.Bang);

        pd.SetFloatParameter(Hv_finalfinalsong_AudioLib.Parameter.Freq, 418);

        var comps = goodShip.GetComponentsInChildren<CannonScript>();
        foreach (var cmp in comps)
        {
            cmp.enabled = false;
            Debug.Log("SET FALSE");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned)
        {

            var distance = (goodShip.transform.position - enemyShip.transform.position).magnitude;
            Debug.Log(distance);

            float freq = 209 - (5 - Mathf.Abs((distance - 25))) * 3;
            pd.SetFloatParameter(Hv_finalfinalsong_AudioLib.Parameter.Freq, freq);
        }
    }

    public void EnemySpawned()
    {
        var comps = GetComponentsInChildren<CannonScript>();
        foreach (var cmp in comps)
        {
            cmp.enabled = true;
        }

        pd.SetFloatParameter(Hv_finalfinalsong_AudioLib.Parameter.Freq, 209);
        isSpawned = true;

    }
}
