using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GrabInput : MonoBehaviour
{
    public Grab grab;
    public KeyCode KeyCodeLeft;
    public KeyCode KeyCodeRight;
    public KeyCode KeyCodeLeftUp;
    public KeyCode KeyCodeRightUp;

    bool isRight;

    public PlayerInput playerInput;


    public bool holdLeft;
    public bool holdRight;

    public GameObject holdRightObj;
    public GameObject holdLeftObj;

    public bool amControllingArm;

    public Animator anim;


    private void OnEnable()
    {
        playerInput.enabled = true;
    }
    private void OnDisable()
    {
        playerInput.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 V2Input = playerInput.actions["Look"].ReadValue<Vector2>();

        

        //if (grab.canGrab)
        //{
        //    if (Input.GetKey(myKey))
        //    {
        //        grab.animator.SetBool("HandRightUp", true);
        //        grab.animator.SetBool("HandRightUp", true);
        //        Debug.Log("Left");
        //        grab.hold = true;
        //    }
        //    else if (grab.isRightKeyHeld)
        //    {
        //        grab.animator.SetBool("HandLeftUp", true);
        //        Debug.Log("Right");
        //        grab.hold = true;
        //    }
        //    else
        //    {
        //        if (grab.RightHand)
        //        {
        //            grab.animator.SetBool("HandRightUp", false);
        //            grab.animator.SetBool("HandLeftUp", false);
        //        }
        //        else
        //        {
        //            grab.animator.SetBool("HandLeftUp", false);
        //            grab.animator.SetBool("HandRightUp", false);
        //        }

        //        grab.hold = false;
        //        Destroy(GetComponent<FixedJoint>());
        //    }

        //}



        if (Input.GetKey(KeyCodeLeftUp))
        {
            anim.SetFloat("RightX", V2Input.x);
            anim.SetFloat("RightY", V2Input.y);
            anim.SetBool("HandRightUp", true);
            amControllingArm = true;
            holdLeft = true;
        }
        else
        {
            amControllingArm = false;
            anim.SetBool("HandRightUp", false);
            holdLeft = false;
        }

        if (Input.GetKey(KeyCodeRightUp))
        {
            //anim.SetBool("LeftUp", true);
            holdRight = true;
        }
        else
        {
          //  anim.SetBool("LeftUp", false);
            holdRight = false;
        }


        //if (Input.GetKey(KeyCodeLeft))
        //{
        //    anim.SetBool("HandRightUp", true);
        //    holdLeft = true;
        //}
        //else
        //{
        //    anim.SetBool("HandRightUp", false); 
        //    holdRight = false;
        //}
        
        //if(Input.GetKey(KeyCodeRight))
        //{
        //    anim.SetBool("HandLeftUp", true);
        //    holdRight = true;
        //}
        //else
        //{
        //    anim.SetBool("HandLeftUp", false);
        //    holdLeft = false;
        //}
    }


    //private void OnCollisionEnter(Collision col)
    //{
    //    if (holdLeft && col.transform.tag != "Player")
    //    {
    //        Debug.Log("Attempting To Hold Right");

    //        Rigidbody rb = col.transform.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            FixedJoint fj = holdLeftObj.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
    //            fj.connectedBody = rb;
    //        }
    //        else
    //        {
    //            FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
    //        }
    //    }

    //    if (holdRight && col.transform.tag != "Player")
    //    {

    //        Debug.Log("Attempting To Hold Right");
    //        Rigidbody rb = col.transform.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            FixedJoint fj = holdRightObj.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
    //            fj.connectedBody = rb;
    //        }
    //        else
    //        {
    //            FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
    //        }
    //    }
    //}
}
