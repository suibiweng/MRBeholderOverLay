using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.GrabAPI;
using Unity.VisualScripting;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class EyeTrackRay : MonoBehaviour
{
    public GameObject Tracker;

    float rayDistance = 1f;
    float rayWidth = 0.001f;


    public

    LayerMask layersInclude;


    public bool startDraw;

    public GameObject spwanSpot;

    
   public Color rayColorDefaultrState = Color.yellow;

    public Color rayColorHoverState = Color.red;


    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();


    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();


        SetupRay();





    }
    public void SetupRay()
    {
        lineRenderer.useWorldSpace = false;

        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultrState;
        lineRenderer.endColor = rayColorDefaultrState;
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayDistance));
        

        


    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayCastDirection = transform.TransformDirection(Vector3.forward) * rayDistance;
        Vector3 endWorldPosition = lineRenderer.transform.TransformPoint(lineRenderer.GetPosition(1));
        // if (Tracker != null)
        // { 

            
        //     Tracker.transform.position = endWorldPosition;
            
            
        // }

        if (startDraw)
        {

            Tracker.GetComponent<SendEyeInfo>().StartToDraw();


        }else
         Tracker.GetComponent<SendEyeInfo>().stoptoDraw();





        if (Physics.Raycast(transform.position, rayCastDirection, out hit, Mathf.Infinity, layersInclude))
        {

            Tracker.transform.position = hit.point;
            //UnSelect();
            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;
            var eyeInteractable = hit.transform.gameObject.GetComponent<EyeInteractable>();
            eyeInteractable.IsHovered = true;






            if (Tracker != null)
            {




                // Tracker.transform.position = endWorldPosition;


            }







        }
        else
        {
            Tracker.transform.position = endWorldPosition;

            lineRenderer.startColor = rayColorDefaultrState;
            lineRenderer.endColor = rayColorDefaultrState;
            // var eyeInteractable = hit.transform.GetConponent<EyeInteractable>();
            // eyeInteractable.IsHovered = true;

            //UnSelect(true);






        }

    }

    void UnSelect(bool clear = false)
    {

        foreach (var interactable in eyeInteractables)
        {
            interactable.IsHovered = false;



        }


        if (clear)
        {



            eyeInteractables.Clear();
        }
        




    }




    // Update is called once per frame
    void Update()
    {

    }
}
