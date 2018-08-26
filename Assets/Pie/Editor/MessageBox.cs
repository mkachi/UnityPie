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
            EditorGUI.LabelField(new Rect(10, 10, 300, 17), text);
            if (GUI.Button(new Rect(10, 35, 300, 17), "OK"))
            {
                Close();
            }
        }
    }
}