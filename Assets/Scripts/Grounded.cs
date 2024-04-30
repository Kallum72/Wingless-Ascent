using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded=false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
