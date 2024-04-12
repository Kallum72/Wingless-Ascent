using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public PlayerController self;

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)))
        {
            if (self.isGrounded)
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
