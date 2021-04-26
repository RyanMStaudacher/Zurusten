using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public float doorOpenAngle = 90f;
    public float openSpeed = 2f;

    //private Animator animator;
    private bool shouldOpen = false;

    private float defaultRotationAngle;
    private float currentRotationAngle;
    private float openTime = 0f;

    public void Interact(GameObject playerCamera)
    {
        shouldOpen = !shouldOpen;
        currentRotationAngle = transform.localEulerAngles.y;
        openTime = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();

        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if(shouldOpen == false)
        //{
        //    animator.SetBool("shouldOpen", false);
        //}
        //else if(shouldOpen == true)
        //{
        //    animator.SetBool("shouldOpen", true);
        //}

        if(openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (shouldOpen ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);
    }
}
