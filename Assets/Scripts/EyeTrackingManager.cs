using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackingManager : MonoBehaviour
{

    public EyeTrackRay LeftEye, RightEye;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 








    }

    bool drawing;


    public void ClearallMaker()
    {

        foreach (var m in GameObject.FindGameObjectsWithTag("EyeTrackTrace"))
            Destroy(m);
        



    }


    public void StartToDrawtheTrace()
    {


        drawing = !drawing;


        LeftEye.startDraw = drawing;

        RightEye.startDraw = drawing;






    }

    

}
