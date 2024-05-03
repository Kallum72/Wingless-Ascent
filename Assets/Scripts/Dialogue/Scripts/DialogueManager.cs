using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool inDialogue;
    public TMP_Text speaker;
    public TMP_Text bodyText;
    public Image dialogueBG;
    int currentLine;

    public KeyCode progress;

    Dialogue currentDialogue;
    void Start()
    {
        dialogueBG.gameObject.SetActive(false);
        speaker.gameObject.SetActive(false);
        bodyText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(progress))
        {
            if (inDialogue)
            {
                if (currentDialogue.lines.Length - 1 <= currentLine)
                {
                    inDialogue = false;
                    speaker.gameObject.SetActive(false);
                    dialogueBG.gameObject.SetActive(false);

                    bodyText.gameObject.SetActive(false);
                    currentLine = 0;
                }
                else
                {

                    currentLine++;
                    bodyText.text = currentDialogue.lines[currentLine].line;
                    speaker.text = currentDialogue.lines[currentLine].speaker;
                }

            }
        }
    }


    public void DialogueStart(Dialogue dialogueToStart)
    {
        inDialogue = true;
        currentDialogue = dialogueToStart;  
        Debug.Log("DialogueStart");
        dialogueBG.gameObject.SetActive(true);
        speaker.gameObject.SetActive(true);
        bodyText.gameObject.SetActive(true);
        dialogueBG.sprite = dialogueToStart.dialogueBox;
        bodyText.text = dialogueToStart.lines[currentLine].line;
        speaker.text = dialogueToStart.lines[currentLine].speaker;
    }
}
