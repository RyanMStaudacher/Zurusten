using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputMaster controls;
    public InventoryObject inventory;
    public GameObject inventoryUIPanel;

    private bool isShowingInventory = false;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Move.performed += context => Move();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    inventory.Save();
        //}

        //if(Input.GetKeyDown(KeyCode.KeypadEnter))
        //{
        //    inventory.Load();
        //}

        //if(!isShowingInventory && Input.GetButtonDown("Inventory"))
        //{
        //    inventoryUIPanel.SetActive(true);
        //    isShowingInventory = true;
        //}
        //else if(isShowingInventory && Input.GetButtonDown("Inventory"))
        //{
        //    inventoryUIPanel.SetActive(false);
        //    isShowingInventory = false;
        //}
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

    void Move()
    {
        Debug.Log("Moving");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
