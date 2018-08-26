using UnityEngine;
using UnityEditor;
using System.IO;

namespace Pie.Editor
{
    public sealed class AssetsMenu
    {
        [MenuItem("Assets/Create/C# Script for UnityPie", priority = 80)]
        public static void Assets_Create_CSharpScriptForUnityPie()
        {
            string filePath = Path.Combine(Application.dataPath, "Pie/Editor/Templates/ScriptTemplate-CSharp.txt");

            Texture2D icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
            CreateScriptAsset endNameEditAction = ScriptableObject.CreateInstance<CreateScriptAsset>();
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, "NewPieCSharpScript.cs", icon, filePath);
        }

        [MenuItem("Assets/Create/ScriptableObject", priority = 80)]
        public static void Assets_Create_ScriptableObject()
        {
            string filePath = Path.Combine(Application.dataPath, "Pie/Editor/Templates/ScriptableObjectTemplate.txt");

            Texture2D icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
            CreateScriptAsset endNameEditAction = ScriptableObject.CreateInstance<CreateScriptAsset>();
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, "NewScriptableObject.cs", icon, filePath);
        }
    }
}