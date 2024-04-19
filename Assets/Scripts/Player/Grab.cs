using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    public bool hold;
    public KeyCode grabKey;
    public bool canGrab;
    public Animator animator;
    public bool RightHand;
    public bool isRightKeyHeld;
    public bool isLeftKeyHeld;
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

        isRightKeyHeld = playerInput.Player.RightGrab.ReadValue<float>() > 0.1f;
        isLeftKeyHeld = playerInput.Player.LeftGrab.ReadValue<float>() > 0.1f;
        //    Debug.Log(isRightKeyHeld);

        

    }



    
}