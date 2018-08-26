using UnityEngine;
using UnityEditor;
using System.IO;

namespace Pie.Editor
{
    public sealed class AssetsMenu
    {
        [MenuItem("Assets/Create/C# Script for UnityPie", priority = 80)]
        public static void Pie_Assets_Create_CSharpScriptForUnityPie()
        {
            string filePath = Path.Combine(Application.dataPath, "Pie/Editor/Templates/ScriptTemplate-CSharp.txt");

            Texture2D icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
            CreateScriptAsset endNameEditAction = ScriptableObject.CreateInstance<CreateScriptAsset>();
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, "NewPieScript.cs", icon, filePath);
        }
    }
}