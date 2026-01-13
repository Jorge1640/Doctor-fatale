using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PickupLogic : MonoBehaviour
{
    private Camera mainCamera;

    bool isHolding = false;

    [SerializeField]
    float throwForce = 6000f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParentLogic tempParentLogic;
    Rigidbody rb;

    Vector3 objectPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        tempParentLogic = TempParentLogic.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
            Hold();
    }


    // private void OnMouseDown()
    // {
    //     if (tempParentLogic != null)
    //     {

    //         distance = Vector3.Distance(this.transform.position, tempParentLogic.transform.position);
    //         if (distance <= maxDistance)
    //         {
    //             isHolding = true;
    //             rb.useGravity = false;
    //             rb.detectCollisions = true;
    //         }


    //         this.transform.SetParent(tempParentLogic.transform);
    //     }
    //     else
    //     {
    //         Debug.Log("Temp Parent item not found in scene");
    //     }
    // }



    public Boolean OnRayito()
    {
        if (tempParentLogic != null)
        {
            if (!isHolding)
            {
                distance = Vector3.Distance(this.transform.position, tempParentLogic.transform.position);
                if (distance <= maxDistance)
                {
                    isHolding = true;
                    rb.useGravity = false;
                    rb.detectCollisions = true;
                    this.transform.SetParent(tempParentLogic.transform);
                     return true;
                }
               
            }
            else if (isHolding)
            {
                Drop();
            }
        }
        else
        {
            Debug.Log("Temp Parent item not found in scene");
        }
        return false;
    }









    private void OnMouseUp()
    {
        Drop();
    }

    private void OnMouseExit()
    {
        Drop();
    }

    private void Hold()
    {

        distance = Vector3.Distance(this.transform.position, tempParentLogic.transform.position);
        if (distance >= maxDistance)
        {
            Drop();
        }
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Matando cerdos");
            rb.AddForce(tempParentLogic.transform.forward * throwForce);
            Drop();
        }
    }

private void Drop()
    {
        if (isHolding)
        {
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }

    public bool IsHolding()
    {
        return isHolding;
    }

}
