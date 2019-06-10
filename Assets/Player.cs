using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Hv_151Finalfinalfinal_AudioLib pd;
    public AudioClip _clip;
    Rigidbody rb;

    float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        pd = GetComponent<Hv_151Finalfinalfinal_AudioLib>();
        pd.FillTableWithMonoAudioClip("PDTable", _clip);

        pd.SetFloatParameter(Hv_151Finalfinalfinal_AudioLib.Parameter.Frequency, 1);
        pd.SendEvent(Hv_151Finalfinalfinal_AudioLib.Event.Bang);

        pd.RegisterSendHook();
        pd.FloatReceivedCallback += OnFloatMessage;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFloatMessage(Hv_151Finalfinalfinal_AudioLib.FloatMessage message)
    {
        Debug.Log(message.receiverName + ": " + message.value);
      
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            pd.SendEvent(Hv_151Finalfinalfinal_AudioLib.Event.Bang);
        }else if (Input.GetKeyDown("a"))
        {
            Debug.Log("a key");
            pd.SendEvent(Hv_151Finalfinalfinal_AudioLib.Event.Sinenvelope);
        }

        pd.SetFloatParameter(Hv_151Finalfinalfinal_AudioLib.Parameter.Frequency, moveVertical * (float)0.5);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }
}
