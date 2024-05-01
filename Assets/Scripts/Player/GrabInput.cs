using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class GrabInput : MonoBehaviour
{
    public Grab grab;
    public KeyCode KeyCodeLeft;
    public KeyCode KeyCodeRight;
    public KeyCode KeyCodeLeftUp;
    public KeyCode KeyCodeRightUp;

    bool isRight;

    public bool holdLeft;
    public bool holdRight;

    public GameObject holdRightObj;
    public GameObject holdLeftObj;

    public Animator anim;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (grab.canGrab)
        //{
        //    if (Input.GetKey(myKey))
        //    {
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
            anim.SetBool("RightUp", true);
            holdLeft = true;
        }
        else
        {
            anim.SetBool("RightUp", false);
            holdLeft = false;
        }

        if (Input.GetKey(KeyCodeRightUp))
        {
            anim.SetBool("LeftUp", true);
            holdRight = true;
        }
        else
        {
            anim.SetBool("LeftUp", false);
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
