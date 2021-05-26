using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blah : MonoBehaviour, IInteractable
{
    public void Interact(GameObject playerCamera)
    {
        GameObject mover = new GameObject();
        playerCamera.transform.parent.transform.parent = mover.transform;
        mover.transform.position = Vector3.zero;
        //playerCamera.transform.parent.transform.parent = null;
        //Destroy(mover);
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
