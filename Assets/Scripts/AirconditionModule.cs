using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AirconditionModule : MonoBehaviour
{
   float Tempture = 50f;
   public float Winds = 1f;  
    public bool onof;

    public TMP_Text DisplayText;

    public TMP_Text WindsText;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOnoff(int value)
    {


        if (value == -1) { onof = false; }

        else if (value == 1) { onof = true; }   
    }

public void changeWind(int direction)
{
    float step = 0.05f; // smaller step for smoother wind change

    // Increase or decrease volume
    Winds += (direction > 0) ? step : -step;
    Winds = Mathf.Clamp01(Winds);

    // Display as 0–20 instead of 0–1
    
}
public void changeTemp(int drection)
    {
        
        if (drection > 0)
        {

            Tempture -= 1f;

             if (Tempture > 80) Tempture  = 80f;

           


        }
        else
        {

            Tempture += 1f;

             if (Tempture <= 65) Tempture  = 65.0f;

            






        }




    }


    // public float jumpCooldown = 2f; // Prevent rapid jumps

    // private float lastJumpTime = 0f;

    // public void JumpToRandomPoint()
    // {
    //     if (audioSource == null || audioSource.clip == null)
    //     {
    //         Debug.LogWarning("AudioSource or clip not assigned.");
    //         return;
    //     }

    //     if (!audioSource.isPlaying)
    //         audioSource.Play();

    //     if (Time.time - lastJumpTime < jumpCooldown)
    //         return;

    //     float clipLength = audioSource.clip.length;
    //     float randomTime = UnityEngine.Random.Range(0f, clipLength);
    //     audioSource.time = randomTime;

    //     Debug.Log($"Jumped to {randomTime:F2} sec");
    //     lastJumpTime = Time.time;
    // }


    // Update is called once per frame
    void Update()
    {

        if (onof)
        {


            DisplayText.text = "TEMP " + Tempture.ToString();
            // WindsText.text = "WIND " + Mathf.RoundToInt(Winds * 100);





            // Apply to AudioSource
            // audioSource.volume = Winds;
            WindsText.text = "Wind: " + Mathf.RoundToInt(Winds * 20);



        }
        else
        {

            DisplayText.text = "";
            // WindsText.text = "WIND " + Mathf.RoundToInt(Winds * 100);





            // Apply to AudioSource
            // audioSource.volume = Winds;
            WindsText.text = "";



        }




            // audioSource.Play();









    }
}
