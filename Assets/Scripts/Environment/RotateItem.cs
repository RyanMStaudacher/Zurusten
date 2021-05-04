using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobSpeed = 2f;
    public float bobHeight = 0.2f;

    private float originalY;

    // Start is called before the first frame update
    void Start()
    {
        originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        ItemBob();
        ItemRotate();
    }

    // Handles the rotation of the item
    private void ItemRotate()
    {
        this.gameObject.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }

    // Handles the bobbing up and down movement of the item
    private void ItemBob()
    {
        Vector3 pos = this.transform.position;
        //Vector3 pos = transform.position;
        //float newY = Mathf.Sin(Time.time * bobSpeed);
        //transform.position = new Vector3(pos.x, newY * bobHeight, pos.z);

        //this.transform.position = new Vector3(startPos.x, Mathf.Sin(Time.time * bobSpeed), startPos.z);

        this.transform.position = new Vector3(pos.x, originalY + ((float)Mathf.Sin(Time.time) * bobHeight), pos.z);
    }
}
