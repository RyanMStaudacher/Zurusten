using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    public void Interact(GameObject playerCamera)
    {
        playerCamera.transform.parent.gameObject.transform.position = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
