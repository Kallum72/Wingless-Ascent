using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DialogueName
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [SerializeField]
        List<DialogueNode> nodes = new List<DialogueNode>();


#if UNITY_EDITOR
        private void Reset()
        {
            if (nodes.Count == 0)
            {
                nodes.Add(new DialogueNode());
            }
        }

#endif
        public IEnumerable<DialogueNode> GetAllNodes()
        {
            return nodes;
        }

        public DialogueNode GetRootNode()
        {
            return nodes[0];
        }
    }

}

