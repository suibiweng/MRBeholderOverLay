using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GearControlModule : MonoBehaviour
{

    public AudioSource EngineSound;

    public AudioClip StartEngine, StopEngine;

    public TMP_Text Gear_Text;

    bool startEngine = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


public void startengine(int start)
{
    if (start == 1)
    {
            startEngine = true;
        // Play the start sound once
            AudioSource.PlayClipAtPoint(StartEngine, transform.position);

        // Optionally, start looping engine sound
        if (!EngineSound.isPlaying)
        {
            EngineSound.loop = true;
            EngineSound.Play();
        }
    }
    else if (start == 0)
    {
           startEngine = false;
        // Stop looping engine sound
            if (EngineSound.isPlaying)
            {
                EngineSound.Stop();
            }

        // Play the stop sound once
        AudioSource.PlayClipAtPoint(StopEngine, transform.position);
    }
}



    public void GearSwitch(float gear)
    {
        string gearState = "";

        if (gear < 0.1f)
            gearState = "P"; // Park
        else if (gear < 0.3f)
            gearState = "R"; // Reverse
        else if (gear < 0.5f)
            gearState = "N"; // Neutral
        else if (gear < 0.7f)
            gearState = "D"; // Drive
        else
            gearState = "L"; // Low / Sport



        if (startEngine)
            Gear_Text.text = gearState;
        else
         Gear_Text.text = "";
        
    }
}
