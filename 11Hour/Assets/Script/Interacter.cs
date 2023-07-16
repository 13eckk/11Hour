using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interacter : MonoBehaviour
{
    [SerializeField] private LayerMask InteractAbleLayer;
    [SerializeField] private float pickupDistance;
    [SerializeField] private Camera Cam;
    [SerializeField] private InsanityCore _insanity;
    [SerializeField] private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
        Cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //PickUpRayCast
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit _PickupHit, pickupDistance, InteractAbleLayer))
        {
            txt.text ="Target :"+ _PickupHit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E) && _PickupHit.collider.name.Contains("Pill"))
            {

                _insanity.sanityPercent = 20f;

            }
            else if (Input.GetKeyDown(KeyCode.E) && _PickupHit.collider.name.Contains("Pill"))
            {
               
               

            }
        }
        if (Physics.Raycast(Cam.transform.position, Cam.transform.position, out RaycastHit _EventHit, 2f))
        {
            if (_EventHit.collider.name.Contains("FEAR"))
            {
               
            }
            if (_EventHit.collider.name.Contains("Normal"))
            {
                
            }


        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(Cam.transform.position, Cam.transform.forward*pickupDistance);

        
    }

}
