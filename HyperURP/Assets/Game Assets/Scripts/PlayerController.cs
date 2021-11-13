using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] public float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;

    private MainController Main_CTR;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    public bool isStarted = false;

    [Header("Ground Attributes")]
    public float JumpGroundOne;
    public float JumpGroundTwo;

    [Header("Speed")]
    public int minSpeed = 8;
    public int currentSpeed = 20;
    public bool isStop = false;
    public bool isJumping = false;

    public Bar bar;


    void Start()
    {
        //runSpeed = minSpeed;
        bar.SetMinSpeed(minSpeed);

        characterController = GetComponent<CharacterController>();
        Main_CTR = (MainController)FindObjectOfType(typeof(MainController));
    }

    void Update()
    {
        if (isStop == true)
        {
            runSpeed = 0;
        }
        if (isStarted == true)
        {
            horizontalInput = 1;


            //Face Forward
            transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

            //IsGrounded
            isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0;
            }
            else
            {
                //Add Gravity
                velocity.y += gravity * Time.deltaTime;
            }

            characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);

            Jump();


            //Vertical velocity
            characterController.Move(velocity * Time.deltaTime);

            //runSpeed += 1 * Time.deltaTime;
            bar.SetSpeed((int)runSpeed);
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetButton("Fire1"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            isJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Out")
        {
            Debug.Log("Out");
            Main_CTR.EndGame();
        }

        if (other.gameObject.tag == "Ground1")
        {
            jumpHeight = JumpGroundOne;
        }

        if (other.gameObject.tag == "Ground2")
        {
            jumpHeight = JumpGroundTwo;
        }

        if (other.gameObject.tag == "GroundFall")
        {
            other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            jumpHeight = JumpGroundTwo;
        }
    }
}
