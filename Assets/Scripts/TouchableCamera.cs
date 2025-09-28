using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableCamera : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.zero;

        if (Input.touchCount > 0)
        {
            
            Vector2 touchPosition   = Input.GetTouch(0).position;
            position                = touchPosition;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
        }

        ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();

            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();

        //    if (interactableObject != null)
        //    {
        //        interactableObject.Interact();
        //    }
        //}
    }
}
