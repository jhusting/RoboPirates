using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<KeyValuePair<string, float>> lines = new List<KeyValuePair<string, float>>();
    //public Hv_RoboVoices2_AudioLib pd;
    public Hv_RoboVoices4_AudioLib pd;
    public GameObject EvilShipGroup;

    public bool RegularPlaying = false;
    public bool SawtoothPlaying = true;
    private bool bPause = false;

    public Text LineDisplayText;
    public CanvasGroup DialogueGroup;

    [SerializeField]
    private float BetweenLineDelay = 0.25f;

    private float CurrTime = 0f;
    private int CurrIndex = 0;
    private float PauseTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //pd.SetFloatParameter(Hv_RoboVoices2_AudioLib.Parameter.Volume, 0f);
        pd.SendEvent(Hv_RoboVoices4_AudioLib.Event.Toggleonoff);
        lines.Add(new KeyValuePair<string, float>("pause", 2.5f)); //0

        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: OH TO SAIL THE HIGH C’S", 2.5f)); //1
        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: TO FEEL THE SALT BRUSH AGAINST MY CIRCUITS", 3.5f)); //2
        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: I AM PROGRAMMED TO ENJOY THIS", 2.5f)); //3
        lines.Add(new KeyValuePair<string, float>("pause", 2.5f)); //4

        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: ENGAGE ENJOYMENT.PROTOCOL()", 3f)); //5
        lines.Add(new KeyValuePair<string, float>("<------------------------------------------------->", 2f)); //6
        lines.Add(new KeyValuePair<string, float>("<XX--------------------------------------------->", 2f)); //7
        lines.Add(new KeyValuePair<string, float>("<XXXX----------------------------------------->", 2f)); //8
        lines.Add(new KeyValuePair<string, float>("<XXXXXX------------------------------------->", 2f)); //9
        //lines.Add(new KeyValuePair<string, float>("pause", 2.5f)); //10

        // SWITCH
        lines.Add(new KeyValuePair<string, float>("Sawtooth Sigmoid: UNCLOAK.EXE", 1.75f)); //10
        lines.Add(new KeyValuePair<string, float>("Sawtooth Sigmoid: FIRE AT WILL", 2.5f)); //11

        // SWITCH
        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: THE SAWTOOTH GANG! THOSE BETA BOTS ARE NOTHING BUT BAD PROTOTYPES", 6f)); //12
        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: FIRE BACK", 1.75f)); //13
        lines.Add(new KeyValuePair<string, float>("pause", .5f)); //14

        // SWITCH
        lines.Add(new KeyValuePair<string, float>("Sawtooth Sigmoid: ALWAYS AN UPDATE BEHIND, EFFEM", 3.5f)); //15
        lines.Add(new KeyValuePair<string, float>("pause", .5f)); //16

        // SWITCH
        lines.Add(new KeyValuePair<string, float>("BitCaptain Effem: LOOP eRoorRRrrr", 2.5f)); //17
    }

    // Update is called once per frame
    void Update()
    {
        CurrTime += Time.deltaTime;

        if (bPause)
        {
            if (CurrTime >= PauseTime)
            {
                bPause = false;
                CurrTime = 0f;
                PlayLine();
            }

        }
        else if (RegularPlaying || SawtoothPlaying)
            CheckLine();
        else
            CheckDelay();
    }

    void CheckLine()
    {
        if (CurrIndex < lines.Count)
        {
            KeyValuePair<string, float> kvp = lines[CurrIndex];

            if (kvp.Key.Equals("pause"))
            {
                Pause(kvp.Value);
            }
            else
            {
                LineDisplayText.text = kvp.Key;

                if (CurrTime >= kvp.Value)
                {
                    CurrTime = 0f;
                    SawtoothPlaying = false;
                    RegularPlaying = false;
                    DialogueGroup.alpha = 0f;
                    LineDisplayText.text = "";
                    pd.SendEvent(Hv_RoboVoices4_AudioLib.Event.Toggleonoff);
                }
            }
        }
        else
        {
            DialogueGroup.alpha = 0f;
            LineDisplayText.text = "";
        }
    }

    void CheckDelay()
    {
        if(CurrIndex > 5 && CurrIndex < 11)
        {
            CurrTime = 0f;
            PlayLine();
        }
        if(CurrTime >= BetweenLineDelay)
        {
            CurrTime = 0f;
            PlayLine();
        }
    }

    void PlayLine()
    {
        CurrIndex++;
        if (CurrIndex % 2 == 0)
            SawtoothPlaying = true;
        else
            RegularPlaying = true;

        if (CurrIndex == 10)
            Uncloak();

        if (CurrIndex == 10 || CurrIndex == 12 || CurrIndex == 15 || CurrIndex == 17)
            pd.SendEvent(Hv_RoboVoices4_AudioLib.Event.Switchbot);

        KeyValuePair<string, float> kvp = lines[CurrIndex];

        if (!kvp.Key.Equals("pause"))
        {
            DialogueGroup.alpha = 1f;
            pd.SendEvent(Hv_RoboVoices4_AudioLib.Event.Toggleonoff);
        }
    }

    void Pause(float x)
    {
        bPause = true;
        PauseTime = x;
        CurrTime = 0;

        RegularPlaying = false;
        SawtoothPlaying = false;
        DialogueGroup.alpha = 0f;
        LineDisplayText.text = "";
    }

    void Uncloak()
    {
        EvilShipGroup.SetActive(true);
    }
}
