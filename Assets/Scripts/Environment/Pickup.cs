using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    private GameObject playerCam;
    private Rigidbody rb;
    private bool isBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Functionality to drop held object when the player's raycast is not on the object
        if (isBeingHeld && Input.GetButtonDown("Interact/Use") && !playerCam.GetComponent<Interact>().isHittingInteractable)
        {
            isBeingHeld = false;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (isBeingHeld)
        {
            Hold();
        }
    }

    public void Interact(GameObject playerCamera)
    {
        if (!isBeingHeld)
        {
            playerCam = playerCamera;
            isBeingHeld = true;
            rb.useGravity = false;
        }
        else if (isBeingHeld && Input.GetButtonDown("Interact/Use"))
        {
            isBeingHeld = false;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
        }
    }

    private void Hold()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, playerCam.transform.position + playerCam.transform.TransformDirection(Vector3.forward) * 3.0f, 0.1f);
    }
}
