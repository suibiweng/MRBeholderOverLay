using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Oculus.Interaction.Locomotion;
using Oculus.Interaction;


public class Manager : MonoBehaviour
{


    public bool mockupOn = true;
     public MeshRenderer mockupSkin;

    public Grabbable grabbable;

    public RadioModule radioModule;
    public GearControlModule gearControlModule;
    public AirconditionModule airconditionModule;

    public GameObject grabObj;

   


    public TMP_Text oscprintout;

    public OSC osc;
    // Start is called before the first frame update
    void Start()
    {
         osc.SetAllMessageHandler(reciveAllmessage);
    }






    public void turnMockup()
    {
        mockupOn = !mockupOn;


        mockupSkin.enabled = mockupOn;
        grabbable.enabled = mockupOn;
        grabObj.SetActive(mockupOn);




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
            logText = $"Radio On/Off: {radioOnOff}"; //toggle

            if(radioOnOff==1)
                radioModule.setOnof();
            break;

        case "radio-tuner":
            int radioTuner = Convert.ToInt32(value);
            logText = $"Radio Tuner: {radioTuner}";
            if( radioTuner!=0) 
            radioModule.changeChannel(radioTuner);
            break;

        case "radio-volume":
            int radioVolume = Convert.ToInt32(value);
            logText = $"Radio Volume: {radioVolume}";
             if(radioVolume!=0)
             radioModule.changeVol(radioVolume);

            break;

        case "ac-increase":
            int acIncrease = Convert.ToInt32(value); //trigger
            logText = $"AC Increase: {acIncrease}";
            if(acIncrease==1)
            airconditionModule.changeTemp(1);
            break;

        case "ac-decrease":
            int acDecrease = Convert.ToInt32(value); //trigger
            logText = $"AC Decrease: {acDecrease}";
            if(acDecrease==1)
             airconditionModule.changeTemp(-1);
            break;

        case "ac-fan":
            int acFan = Convert.ToInt32(value);
            logText = $"AC Fan Speed: {acFan}";
            if(acFan!=0) 
            airconditionModule.changeWind(acFan);
            break;

        case "gear-start":
            int gearStart = Convert.ToInt32(value);
            logText = $"Gear Start: {gearStart}";
            if(gearStart!=0)
                gearControlModule.startengine(gearStart);
                airconditionModule.SetOnoff(gearStart);
                if (gearStart == -1)
                    radioModule.onof = false;

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
