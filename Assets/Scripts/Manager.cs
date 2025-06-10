using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Manager : MonoBehaviour
{

    public RadioModule radioModule;
    public GearControlModule gearControlModule;
    public AirconditionModule airconditionModule;


    public TMP_Text oscprintout;

    public OSC osc;
    // Start is called before the first frame update
    void Start()
    {
         osc.SetAllMessageHandler(reciveAllmessage);
    }


 // Assign this in the Inspector

void reciveAllmessage(OscMessage message)
{
    string address = message.address.TrimStart('/');

    if (message.values.Count == 0)
    {
        string warning = $"⚠️ OSC message at {address} has no values.";
        Debug.LogWarning(warning);
        oscprintout.text = warning;
        return;
    }

    object value = message.values[0];
    string logText = "";

    switch (address)
    {
        case "radio-onoff":
            int radioOnOff = Convert.ToInt32(value);
            logText = $"Radio On/Off: {radioOnOff}";


                radioModule.setOnof(radioOnOff);
            break;

        case "radio-tuner":
            float radioTuner = Convert.ToSingle(value);
            logText = $"Radio Tuner: {radioTuner}";
            //radioModule.changeChannel(radioTuner);
            break;

        case "radio-volume":
            float radioVolume = Convert.ToSingle(value);
            logText = $"Radio Volume: {radioVolume}";
           // radioModule.setOnof(radioVolume);

            break;

        case "ac-increase":
            int acIncrease = Convert.ToInt32(value);
            logText = $"AC Increase: {acIncrease}";
            airconditionModule.changeTemp(acIncrease);
            break;

        case "ac-decrease":
            int acDecrease = Convert.ToInt32(value);
            logText = $"AC Decrease: {acDecrease}";
             airconditionModule.changeTemp(acDecrease);
            break;

        case "ac-fan":
            float acFan = Convert.ToSingle(value);
            logText = $"AC Fan Speed: {acFan}";
              //  airconditionModule.changeWind(acFan);
            break;

        case "gear-start":
            int gearStart = Convert.ToInt32(value);
            logText = $"Gear Start: {gearStart}";
            break;

        case "gear-stick":
            float gearStick = Convert.ToSingle(value);
            logText = $"Gear Stick Position: {gearStick}";
                gearControlModule.GearSwitch(gearStick);
            break;

        default:
            logText = $"⚠️ Unknown OSC address: {address}";
            break;
    }

    Debug.Log(logText);
    oscprintout.text = logText;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
