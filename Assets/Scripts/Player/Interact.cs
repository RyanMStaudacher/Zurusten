using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDistance = 5.0f;

    [HideInInspector] public bool isHittingInteractable = false;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        InteractRaycast();
    }

    private void InteractRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactDistance) && hit.transform.gameObject.GetComponent<IInteractable>() != null)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactDistance, Color.green);
            isHittingInteractable = true;

            if(Input.GetButtonDown("Interact/Use"))
            {
                hit.transform.gameObject.GetComponent<IInteractable>().Interact(this.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactDistance, Color.red);
            isHittingInteractable = false;
        }
    }
}
