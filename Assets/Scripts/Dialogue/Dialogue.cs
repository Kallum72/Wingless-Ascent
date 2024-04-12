using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]  
public class Dialgoue : ScriptableObject
{
    [SerializeField] 
    DialogueNode[] nodes;
}
