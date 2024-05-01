using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    public bool amLeft;
    bool amHolding;

    public GrabInput grab;

    public KeyCode myKey;
    public KeyCode myKeyUp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(myKey) || Input.GetKey(myKeyUp))
        {
            amHolding = true;
        }
        else
        {
            amHolding = false;
        }

        if(!amHolding)
        {
            Destroy(GetComponent<FixedJoint>());
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (amHolding && col.gameObject.tag != "Player")
        {
            Debug.Log("Holding?");

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
