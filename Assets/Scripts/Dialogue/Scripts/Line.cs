using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Line", menuName = "Dialogue/Line", order = 1)]
public class Line : ScriptableObject
{
    public string line;
    public string speaker;
    public bool lastLine;
}
