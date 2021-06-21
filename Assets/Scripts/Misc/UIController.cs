using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class UIController : MonoBehaviour
{
    public InputMaster input;
    public InventoryObject playerInventory;
    public GameObject inventoryUIPanel;
    public GameObject pauseMenuUIPanel;

    private bool isShowingInventory = false;
    private bool isShowingPauseMenu = false;

    private void Awake()
    {
        input = new InputMaster();
        input.UI.TogglePauseMenu.performed += context => TogglePauseMenu(context.ReadValue<float>());
        input.UI.ToggleInventory.performed += context => ToggleInventory(context.ReadValue<float>());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleInventory(float contextValue)
    {
        if (!isShowingInventory && !isShowingPauseMenu)
        {
            inventoryUIPanel.SetActive(true);
            isShowingInventory = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (isShowingInventory)
        {
            inventoryUIPanel.SetActive(false);
            isShowingInventory = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void TogglePauseMenu(float contextValue)
    {
        if (!isShowingPauseMenu && !isShowingInventory)
        {
            pauseMenuUIPanel.SetActive(true);
            isShowingPauseMenu = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (isShowingPauseMenu)
        {
            pauseMenuUIPanel.SetActive(false);
            isShowingPauseMenu = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void SaveInventory()
    {
        playerInventory.Save();
    }

    public void LoadInventory()
    {
        playerInventory.Load();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnApplicationQuit()
    {
        playerInventory.container.Clear();
    }
}
