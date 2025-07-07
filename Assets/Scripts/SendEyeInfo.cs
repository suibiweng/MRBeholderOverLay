using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEyeInfo : MonoBehaviour
{
    public OSC osc;
    public TrailRenderer line;

    public string hitObject="Null";
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
void Update()
{
    OscMessage message = new OscMessage();
    message.address = "/eyetrack";

    // Add position data
    message.values.Add(transform.position.x);
    message.values.Add(transform.position.y);
    message.values.Add(transform.position.z);

    // Add hit object name (ensure you assign hitObject elsewhere in your raycast)
    message.values.Add(hitObject);

    // Add timestamp (time in seconds since the scene started)
    message.values.Add(Time.time);

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
