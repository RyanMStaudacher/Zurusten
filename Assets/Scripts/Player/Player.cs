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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // This is temporary
        var ingredient = other.GetComponent<IngredientPickup>();
        if(ingredient)
        {
            inventory.AddItem(ingredient.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
