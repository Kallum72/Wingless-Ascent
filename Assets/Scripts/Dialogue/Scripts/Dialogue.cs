using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue", order = 2)]
public class Dialogue : ScriptableObject
{
    public Line[] lines;
    public Sprite dialogueBox;
    
}
