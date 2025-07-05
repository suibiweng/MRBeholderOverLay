using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEyeInfo : MonoBehaviour
{
    public OSC osc;
    public TrailRenderer line;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


        OscMessage message = new OscMessage();

        message = new OscMessage();
        message.address = "/eyetrack";
        message.values.Add(transform.position.x);
        message.values.Add(transform.position.y);
        message.values.Add(transform.position.z);
        osc.Send(message);

        

    }


    public void StartToDraw()
    {
        line.time = Mathf.Infinity;
    }


    public void stoptoDraw()
    { 

         line.time = 0;
        


    }
}
