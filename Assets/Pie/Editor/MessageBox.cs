using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Pie.Editor
{
    public class MessageBox
        : EditorWindow
    {
        public string text;

        static public void Show(string title, string text)
        {
            MessageBox messageBox = GetWindow<MessageBox>();
            messageBox.titleContent = new GUIContent(title);
            messageBox.text = text;
        }

        static public void Show(string title, string text, Vector2 size)
        {
            MessageBox messageBox = GetWindow<MessageBox>();
            messageBox.titleContent = new GUIContent(title);
            messageBox.text = text;
            messageBox.minSize = size;
            messageBox.maxSize = size;
        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Label(text);
            if (GUILayout.Button("OK"))
            {
                Close();
            }
            EditorGUILayout.EndVertical();
        }
    }
}