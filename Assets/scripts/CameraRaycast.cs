using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CameraRaycast : MonoBehaviour
{



    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private PickupLogic pickupLogic;

    private Transform highlight;
    private Transform selection;


    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        


    }

    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null) return;
        }
        // Highlight
        if (highlight != null)
        {
            
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }



        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.gameObject.CompareTag("Grabable"))
            {
                pickupLogic = hit.transform.gameObject.GetComponent<PickupLogic>();
                
                // Only highlight if the object is not being held
                if (pickupLogic != null && !pickupLogic.IsHolding())
                {
                    highlight = hit.transform;
                    ToHighlight(highlight);
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Boolean holding = pickupLogic.OnRayito();
                        if (holding)
                        {
                            highlight.gameObject.GetComponent<Outline>().enabled = false;
                            highlight = null;
                        }
                        Debug.Log(highlight.gameObject.GetComponent<Outline>().enabled);
                    }
                }
               
            }


            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.cyan, 1f);
        }
         //Debug.Log(highlight.gameObject.GetComponent<Outline>().enabled);
    }

    public void ToHighlight(Transform highlight)
    {
       
        if (highlight.gameObject.GetComponent<Outline>() != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            Debug.Log("hola");
            Outline outline = highlight.gameObject.AddComponent<Outline>();
            outline.enabled = true;
            highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
            highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
        }
    }
}
