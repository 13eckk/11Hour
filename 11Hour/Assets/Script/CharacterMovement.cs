using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("MOVEMENT SETTING")]
    [SerializeField] private float movement_speed = 10f;
    [SerializeField] private float gravity = 30f;
    
    public bool canMove = true;
    public bool canLook = true;
    [Header("MOVEMENT ANIMATION")]
    public Animator playerAnimator;
    public bool walkforward;

    [Header("LOOK PARAMETERS")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;


    [Header("Crouch Parameter")]
    [SerializeField] private KeyCode crounchs = KeyCode.LeftControl;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0, 1f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    public bool isCrouch;
    private bool duringCrouchAnim;

    [Header("INTERACTION")]


    public Camera playCamera;
    public GameObject players;
    public CharacterController controller;

    private Vector3 moveDirection;
    private Vector2 currentInput;
    private float rotationX = 0;
    void Awake()
    {

        controller = GetComponent<CharacterController>();
        players = GameObject.Find("PlayerObj");

        
        playerAnimator = GetComponentInChildren<Animator>();
        playCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movementController();
            FinalizeMovement();

        }
        if (canLook)
        {
            LookController();
        }

        animate();

    }
    void animate()
    {
        if (Input.GetAxis("Vertical") == 1)
        {
            playerAnimator.SetBool("Walk", true);
            walkforward = true;
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
            walkforward = false;
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            playerAnimator.SetBool("WalkBackWard", true);
        }
        else
        {
            playerAnimator.SetBool("WalkBackWard", false);
        }
        

    }
    void movementController()
    {

        currentInput = new Vector2(movement_speed * Input.GetAxis("Vertical"), movement_speed * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }
    void FinalizeMovement()
    {

        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
       
        if (Input.GetKeyDown(crounchs) && !isCrouch)
        {
            Crounch();

            playerAnimator.SetBool("Crounch", true);

        }
        if (Input.GetKeyDown(crounchs) && isCrouch)
        {
            Crounch();

            playerAnimator.SetBool("Crounch", false);

        }

    }
    void LookController()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }
    void Crounch()
    {
        StartCoroutine(Crouching());
        
    }
    IEnumerator Crouching()
    {
        duringCrouchAnim = true;

        float timeElaped = 0;
        float targetHeight = isCrouch ? standingHeight : crouchHeight;
        float currentHeight = controller.height;
        Vector3 targetCenter = isCrouch ? standingCenter : crouchingCenter;
        Vector3 currentCenter = controller.center;

        while (timeElaped < timeToCrouch)
        {
            controller.height = Mathf.Lerp(currentHeight, targetHeight, timeElaped / timeToCrouch);
            controller.center = Vector3.Lerp(currentCenter, targetCenter, timeElaped / timeToCrouch);
            timeElaped += Time.deltaTime;
            
            yield return null;
        }
        controller.height = targetHeight;
        controller.center = targetCenter;

        isCrouch = !isCrouch;

        duringCrouchAnim = false;

    }
}
