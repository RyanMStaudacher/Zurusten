using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class Player : MonoBehaviour
{
    public InputMaster input;
    public CharacterController charController;
    public Camera playerCamera;
    public Transform groundCheck;
    public LayerMask groundMask;
    public InventoryObject inventory;
    public float interactDistance = 5.0f;
    public float mouseSensitivityX = 32.0f;
    public float mouseSensitivityY = 32.0f;
    public float moveSpeed = 6.0f;
    public float strafeSpeed = 6.0f;
    public float sprintSpeed = 12.0f;
    public float sprintStrafeSpeed = 12.0f;
    public float jumpHeight = 10.0f;
    public float gravityMultiplier = 1f;

    private Vector3 velocity;
    private Vector2 lookInput;
    private Vector2 movementInput;
    private float jumpInput;
    private float sprintInput;
    private float interactInput;
    private float gravity = -9.81f;
    private float currentMoveSpeed;
    private float currentStrafeSpeed;
    private float xRotation = 0f;
    private float groundDistance = 0.4f;
    private bool isHittingInteractable = false;
    private bool sprinting = false;
    private bool hasPickedUp = false;
    private bool isGrounded;

    private void Awake()
    {
        input = new InputMaster();
        currentMoveSpeed = moveSpeed;
        currentStrafeSpeed = strafeSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        //Look();
        Move();
        Jump();
        Sprint();
        InteractRaycast();
    }

    private void FixedUpdate()
    {
        //Look();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void GetInput()
    {
        lookInput = input.Player.Look.ReadValue<Vector2>();
        movementInput = input.Player.Move.ReadValue<Vector2>();
        jumpInput = input.Player.Jump.ReadValue<float>();
        sprintInput = input.Player.Sprint.ReadValue<float>();
        interactInput = input.Player.Interact.ReadValue<float>();
    }

    private void Look()
    {
        float lookX = lookInput.x * mouseSensitivityX * Time.deltaTime;
        float lookY = lookInput.y * mouseSensitivityY * Time.deltaTime;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerCamera.transform.parent.transform.Rotate(Vector3.up * lookX);
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = movementInput.x * currentStrafeSpeed;
        float y = movementInput.y * currentMoveSpeed;

        Vector3 move = transform.right * x + transform.forward * y;

        charController.Move(move * Time.deltaTime);

        velocity.y += (gravity * gravityMultiplier) * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded && jumpInput == 1)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * (gravity * gravityMultiplier));
        }
    }

    private void Sprint()
    {
        if(sprintInput == 1 && !sprinting)
        {
            currentMoveSpeed = sprintSpeed;
            currentStrafeSpeed = sprintStrafeSpeed;
            sprinting = true;
        }

        if(sprintInput == 0)
        {
            currentMoveSpeed = moveSpeed;
            currentStrafeSpeed = strafeSpeed;
            sprinting = false;
        }
    }

    private void InteractRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, interactDistance) && hit.transform.gameObject.GetComponent<IInteractable>() != null)
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * interactDistance, Color.green);
            isHittingInteractable = true;

            if (interactInput == 1)
            {
                hit.transform.gameObject.GetComponent<IInteractable>().Interact(playerCamera.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * interactDistance, Color.red);
            isHittingInteractable = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // This is temporary
        var ingredient = other.GetComponent<IngredientPickup>();
        if (ingredient && !hasPickedUp)
        {
            inventory.AddItem(ingredient.item, 1);
            Destroy(other.gameObject);
            hasPickedUp = true;
            StartCoroutine(PickupDelayTimer());
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    //This is a temporary function that prevents the player from picking up more than 1 item at once.
    private IEnumerator PickupDelayTimer()
    {
        yield return new WaitForSeconds(0.5f);
        hasPickedUp = false;
    }
}
