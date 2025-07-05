using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class RadioModule : MonoBehaviour
{
    float currentChannel = 99.7f;
   public float Volume = 1f;  
    public bool onof;

    public TMP_Text DisplayText;

    public TMP_Text VolumeText;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {


        //if(onof)audioSource.Play();
        
        
    }

    public void SetOnoff(int value)
    {


        if (value == 0)
        {
            onof = false;
            audioSource.Pause();

        }

        else if (value == 1)
        {
            onof = true;
             audioSource.Play();

        }   
    }

    public void changeVol(int direction)
    {
        float step = 0.1f;

        Volume += direction > 0 ? step : -step;
        Volume = Mathf.Clamp01(Volume);

        audioSource.volume = Volume;

        VolumeText.text = "Vol: " + Mathf.RoundToInt(Volume * 100);
    }


    public AudioClip[] radioClips;  


     private int currentClipIndex = 0;

public void changeChannel(int direction)
{
    if (!onof || radioClips.Length == 0) return;

    // Simulate tuning the dial
    currentChannel += direction > 0 ? 0.1f : -0.1f;

    if (currentChannel > 197.9f) currentChannel = 0f;
    if (currentChannel < 0f) currentChannel = 197.9f;

    // Choose a random clip
    int randomIndex = UnityEngine.Random.Range(0, radioClips.Length);

    // Play it
    PlayRadioClip(randomIndex);

    // Update display
    DisplayText.text = "FM " + currentChannel.ToString("F1");
}



    void PlayRadioClip(int index)
{
    if (radioClips == null || index < 0 || index >= radioClips.Length)
    {
        Debug.LogWarning("Invalid radio clip index.");
        return;
    }

    audioSource.Stop();
    audioSource.clip = radioClips[index];
    audioSource.Play();

    Debug.Log($"Switched to clip {index}, FM {currentChannel:F1}");
}




    









    //     public void changeChannel(int drection)
    //     {
    //          if (!onof) return;
    //         if (drection > 0)
    //         {

    //             currentChannel += 0.1f;

    //             if (currentChannel >= 197.9f) currentChannel = currentChannel = 0.0f;

    //             JumpToRandomPoint();


    //         }
    //         else
    //         {

    //             currentChannel -= 0.1f;

    //             if (currentChannel <= 0) currentChannel = currentChannel = 197.9f;

    //             JumpToRandomPoint();






    //         }




    //     }


    //     public float jumpCooldown = 2f; // Prevent rapid jumps

    //     private float lastJumpTime = 0f;

    //     public void JumpToRandomPoint()
    //     {
    //         if (audioSource == null || audioSource.clip == null)
    //         {
    //             Debug.LogWarning("AudioSource or clip not assigned.");
    //             return;
    //         }

    //         if (!audioSource.isPlaying)
    //             audioSource.Play();

    //         if (Time.time - lastJumpTime < jumpCooldown)
    //             return;

    //         float clipLength = audioSource.clip.length;
    //         float randomTime = UnityEngine.Random.Range(0f, clipLength);
    //         audioSource.time = randomTime;

    //         Debug.Log($"Jumped to {randomTime:F2} sec");
    //         lastJumpTime = Time.time;
    //     }


    public void setOnof()
    {

        onof = !onof;

        // if (on == 0) onof = false;

        // else if (on == 1) onof = true;




    }


    // Update is called once per frame
    void Update()
    {

        if (onof)
        {

            DisplayText.text = "FM " + currentChannel.ToString("F1");
            VolumeText.text = "Vol: " + Mathf.RoundToInt(Volume * 100);

            //audioSource.Play();
            if (!audioSource.isPlaying)
            audioSource.Play();




        }
        else
        {


            DisplayText.text = "";
            VolumeText.text = "";



        if (audioSource.isPlaying)
           

            audioSource.Pause();



        }



        
    }
}
