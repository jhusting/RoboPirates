using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    private Hv_waves_AudioLib pd;

    public float maxWaveFrequency = 1000;
    public float maxWaveGain = 0.5f;

    public float minWaveFrequency = 200;
    public float minWaveGain = 0.2f;

    void Start()
    {
        pd = GetComponent<Hv_waves_AudioLib>();
    }

    void Update()
    {

        float freq = minWaveFrequency + Mathf.Abs(Mathf.Sin(Time.time / 5.3f)) * (maxWaveFrequency - minWaveFrequency) ;
        float gain = minWaveGain + Mathf.Abs(Mathf.Cos(Time.time / 3.4f)) * (maxWaveGain - minWaveGain);
        

        pd.SetFloatParameter(Hv_waves_AudioLib.Parameter.Frequency, freq);
        pd.SetFloatParameter(Hv_waves_AudioLib.Parameter.Gain, gain);
    }
}
