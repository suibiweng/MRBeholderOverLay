using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public TMP_Text oscprintout;

    public OSC osc;
    // Start is called before the first frame update
    void Start()
    {
         osc.SetAllMessageHandler(reciveAllmessage);
    }


void reciveAllmessage(OscMessage message)
{
    string output = "";

    foreach (var val in message.values)
    {
        output += val.ToString() + " ";
    }

    oscprintout.text = output.Trim(); // Trim to remove trailing space
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
