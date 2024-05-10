using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform root;

    public float mouseX, mouseY;

    public float stomachOffset;

    public PlayerInput playerInput;

    bool controllingArm;
    public GrabInput grabInput;
    public ConfigurableJoint hipJoint, stomachJoint;

    Vector2 CamInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if(!controllingArm)
        {
            CamControl();

        }

        CamInput = playerInput.actions["Look"].ReadValue<Vector2>();
        controllingArm = grabInput.amControllingArm;
    }

    void CamControl()
    {
             mouseX += CamInput.x * rotationSpeed;
            mouseY -= CamInput.y * rotationSpeed;



        mouseY = Mathf.Clamp(mouseY, -75, 60);

        Quaternion rootRotation = Quaternion.Euler(0, mouseX, -mouseY - 2);

        root.rotation = rootRotation;
        hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
       //    stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0, 0);
    }
}
