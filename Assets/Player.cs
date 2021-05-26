using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        // This is temporary
        var ingredient = other.GetComponent<IngredientPickup>();
        if(ingredient)
        {
            Debug.Log("yo");
            inventory.AddItem(ingredient.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
