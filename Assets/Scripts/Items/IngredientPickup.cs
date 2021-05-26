using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(RotateItem))]
public class IngredientPickup : MonoBehaviour
{
    public ItemObject item;

    [Tooltip("How close the player has to be to pickup the ingredient.")]
    public float pickupDistance = 5.0f;

    [Tooltip("How fast the ingredient will float upwards before moving towards the player.")]
    public float floatUpSpeed = 1.0f;

    [Tooltip("How long the ingredient will wait before moving towards the player.")]
    public float floatDelayTime = 2f;

    [Tooltip("How fast the ingredient will move towards the player.")]
    public float moveToPlayerSpeed = 1.0f;

    private Vector3 target;
    private GameObject player;
    private RotateItem rotateItemScript;
    private float currentDistance;
    private bool shouldBePickedUp = false;
    private bool hasWaitedForDelay = false;
    private bool hasSetTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotateItemScript = GetComponent<RotateItem>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);

        if(currentDistance <= pickupDistance)
        {
            shouldBePickedUp = true;
        }

        if (shouldBePickedUp)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        //Set the target for the ingredient to float towards before moving to the player. Also turn off the item rotation script and start the float up delay.
        if(!hasSetTarget)
        {
            target = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            rotateItemScript.enabled = false;
            StartCoroutine(FloatUpDelay());
            hasSetTarget = true;
        }

        //Float upwards toward the target. If done waiting for the delay, then float towards the player instead.
        if(!hasWaitedForDelay)
        {
            this.transform.position = Vector3.Slerp(this.transform.position, target, floatUpSpeed * Time.deltaTime);
        }
        else if(hasWaitedForDelay)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, moveToPlayerSpeed * Time.deltaTime);
        }
    }

    private IEnumerator FloatUpDelay()
    {
        yield return new WaitForSeconds(floatDelayTime);
        hasWaitedForDelay = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
