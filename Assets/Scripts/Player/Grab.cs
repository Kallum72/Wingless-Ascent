using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    private bool hold;
    public KeyCode grabKey;
    public bool canGrab;
    public Animator animator;
    public bool RightHand;
    [SerializeField] PlayerControls playerInput;

    private void Awake()
    {
        playerInput = new PlayerControls();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }


    void Update()
    {

        bool isRightKeyHeld = playerInput.Player.RightGrab.ReadValue<float>() > 0.1f;
        bool isLeftKeyHeld = playerInput.Player.LeftGrab.ReadValue<float>() > 0.1f;
        //    Debug.Log(isRightKeyHeld);

        if (canGrab)
        {
            if (isLeftKeyHeld)
            {
                animator.SetBool("HandRightUp", true);
                Debug.Log("Left");
                hold = true;
            }
            else if (isRightKeyHeld)
            {
                animator.SetBool("HandLeftUp", true);
                Debug.Log("Right");
                hold = true;
            }
            else
            {
                if (RightHand)
                {
                    animator.SetBool("HandRightUp", false);
                    animator.SetBool("HandLeftUp", false);
                }
                else
                {
                    animator.SetBool("HandLeftUp", false);
                    animator.SetBool("HandRightUp", false);
                }

                hold = false;
                Destroy(GetComponent<FixedJoint>());
            }

        }

    }



    private void OnCollisionEnter(Collision col)
    {
        if (hold && col.transform.tag != "Player")
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
            }
            else
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            }
        }
    }
}