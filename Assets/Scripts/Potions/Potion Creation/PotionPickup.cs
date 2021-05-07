using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PotionAbility))]
public class PotionPickup : MonoBehaviour, IInteractable
{
    private PotionAbility potionAbility;
    private PotionAbility abilityToEnable;

    private GameObject pc;
    private GameObject holdPoint;
    private bool isHolding = false;
    private bool hasDrank = false;

    public void Interact(GameObject playerCamera)
    {
        // Finds the hold point on the player, sets position to hold point, makes hold point
        // the parent transform so the object will stay at the hold point.
        holdPoint = GameObject.FindGameObjectWithTag("Hold Point");
        this.gameObject.transform.position = holdPoint.transform.position;
        this.transform.parent = holdPoint.transform;
        isHolding = true;

        pc = playerCamera;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding && !hasDrank && Input.GetButtonDown("Main Ability"))
        {
            DrinkPotion();
            hasDrank = true;
        }

        if(hasDrank)
        {
            Destroy(this.gameObject);
        }
    }

    private void DrinkPotion()
    {
        // Gets the potion ability that is attached to this gameobject and adds it to the player gameobject
        potionAbility = this.gameObject.GetComponent<PotionAbility>();
        //pc.transform.parent.gameObject.AddComponent(potionAbility.GetType());
        //pc.transform.parent.gameObject.GetComponent<>;

        foreach (PotionAbility a in pc.transform.parent.gameObject.GetComponents<PotionAbility>())
        {
            if(a.GetType() == potionAbility.GetType())
            {
                a.enabled = true;
            }
            else if(a.GetType() != potionAbility.GetType())
            {
                a.enabled = false;
            }
        }
    }
}
