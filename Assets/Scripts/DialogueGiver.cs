using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogueToGive;
    public GameObject InteractText;
    bool CanInteract;
    public bool CanSpeak = true;

    private void Update()
    {
        if (CanInteract && CanSpeak)
        {
            if (Input.GetKeyDown(dialogueManager.progress))
            {

                CanSpeak = false;
                Debug.Log("E");
                
                if (dialogueManager.inDialogue == false)
                { 
                
                    InteractText.SetActive(false);
                    CanInteract = true;

                    dialogueManager.DialogueStart(dialogueToGive);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InteractText.SetActive(true);

            CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CanInteract = true;

            InteractText.SetActive(false);
        }
    }

    
}
