using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;

namespace DialogueName.Editor
{
    public class DialogueEditor : EditorWindow
    {

        Dialogue SelectedDialogue = null;
        GUIStyle nodeStyle = null;

        bool dragging = false;

        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), false, "Dialogue Editor");
        }

        [OnOpenAsset(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            Dialogue dialogue = EditorUtility.InstanceIDToObject(instanceID) as Dialogue;
            if(dialogue != null)
            {
                ShowEditorWindow();
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChanged;
            
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("node0") as Texture2D;
            nodeStyle.padding = new RectOffset(20, 20, 20, 20);
            nodeStyle.border = new RectOffset(12, 12, 12, 12);
            nodeStyle.normal.textColor = Color.white;
        }

        private void OnSelectionChanged()
        {
            Dialogue newDialogue = Selection.activeObject as Dialogue;
            if(newDialogue != null)
            {
                SelectedDialogue = newDialogue;
                Repaint();
            }
        }

        private void OnGUI()
        {
            if(SelectedDialogue == null)
            {
                EditorGUILayout.LabelField("No Dialogue Selected!");
            }
            else
            {
                ProcessEvents();
                foreach (DialogueNode node in SelectedDialogue.GetAllNodes())
                {
                    OnGUINode(node);
                }
            }
            
        }

        private void ProcessEvents()
        {
            if((Event.current.type == EventType.MouseDown) && (!dragging))
            {
                dragging = true;
            }
            else if(Event.current.type == EventType.MouseDrag && dragging)
            {
                Undo.RecordObject(SelectedDialogue, "Move Node");
                SelectedDialogue.GetRootNode().rect.position = Event.current.mousePosition;
                GUI.changed = true;

            }
            else if ((Event.current.type == EventType.MouseUp) && (dragging))
            {
                dragging = false;
            }
        }

        private void OnGUINode(DialogueNode node)
        {
            GUILayout.BeginArea(node.rect, nodeStyle);
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Node: ");

            string newText = EditorGUILayout.TextField(node.text);
            string newUniqueID = EditorGUILayout.TextField(node.uniqueID);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(SelectedDialogue, "Update Dialogue Text");

                node.text = newText;
                node.uniqueID = newUniqueID;
            }

            GUILayout.EndArea();
        }
    }
    
}
