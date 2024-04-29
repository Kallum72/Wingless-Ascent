using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    public Grounded ground;

    public PlayerInput playerInput;
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInput.enabled = true;
    }
    private void OnDisable()
    {
        playerInput.enabled = false;
    }
    private void FixedUpdate()
    {
        isGrounded = ground.isGrounded;
        Vector2 V2Input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        moveDirection = (forward * V2Input.y) + (right * V2Input.x);
        moveDirection.y = 0;
        hips.AddForce(moveDirection.normalized * speed * Time.deltaTime, ForceMode.Impulse);

  
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("Jump!!!");
            hips.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }



}
