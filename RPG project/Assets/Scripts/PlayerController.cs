using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask mask;

    Camera cam;

    PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100,mask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
              Interactable interactable = hit.collider.GetComponent<Interactable>();
              
              if(interactable != null)
                {
                    SetFoucs(interactable);
                }
            }
        }
    }

    private void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    private void SetFoucs(Interactable newInteractable)
    {
        if(newInteractable != focus)
        {
            if(focus !=null)
                focus.OnDefocused();

            focus = newInteractable;
            motor.FollowTarget(newInteractable);

        }
        newInteractable.OnFoucused(transform);
    }
}
