using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Hv_finalsong_AudioLib pd;

    // Start is called before the first frame update
    void Start()
    {

        pd = GetComponent<Hv_finalsong_AudioLib>();

        pd.FillTableWithFloatBuffer("strings", new float[] { 1, 40, 45, 50, 55, 59, 64 });
        pd.FillTableWithFloatBuffer("notes", new float[] { 0, 8, 2, 4, 5, 7, 9, 11, 12});

        pd.FillTableWithFloatBuffer("bass", new float[] { 0, 300, 0, 300, 0, 201, 0 , 203, 0, 203, 0, 300, 0 });
        pd.FillTableWithFloatBuffer("percussion", new float[] { 0, 300, 0, 300, 0, 201, 0, 203, 0, 203, 0, 300, 0 });

        pd.FillTableWithFloatBuffer("melody", new float[] { 0, 402,501 ,503, 503, 503, 600, 601, 601, 603, 600, 603 });


        pd.SendEvent(Hv_finalsong_AudioLib.Event.Bang);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
