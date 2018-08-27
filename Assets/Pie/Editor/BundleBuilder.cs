using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.IO;

namespace Pie.Editor
{
    public class BundleBuilder
        : EditorWindow
    {
        private static BundleBuilder _instance = null;
        private string _path;
        private BuildTarget _target = BuildTarget.NoTarget;

        static public void ShowWindow()
        {
            if (_instance == null)
            {
                _instance = GetWindow<BundleBuilder>();
                _instance.titleContent = new GUIContent("AssetBundle Builder");
                _instance.minSize = new Vector2(320, 80);
                _instance.maxSize = _instance.minSize;
            }
            _instance.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label(new GUIContent("Build OS : "));
                _target = (BuildTarget)EditorGUILayout.EnumPopup(_target);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label(new GUIContent("Save Path"));
                if (GUILayout.Button(new GUIContent("...")))
                {
                    string path = EditorUtility.SaveFolderPanel("AssetBundle as Save", "", "");
                    if (path.Length > 0)
                    {
                        _path = path;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            _path = EditorGUILayout.TextField(_path);

            if (GUILayout.Button(new GUIContent("Build")))
            {
                if (_target.Equals(BuildTarget.NoTarget))
                {
                    MessageBox.Show("Unity Pie", "Select build target!", new Vector2(320, 70));
                    return;
                }
                StringBuilder sb = new StringBuilder();

                sb.Append(_path).Append("/AssetBundles/");
                DirectoryInfo info1 = new DirectoryInfo(sb.ToString());
                if (!info1.Exists)
                {
                    info1.Create();
                }

                sb.Append(_target);
                DirectoryInfo info2 = new DirectoryInfo(sb.ToString());
                if (!info2.Exists)
                {
                    info2.Create();
                }

                BuildPipeline.BuildAssetBundles(sb.ToString(), BuildAssetBundleOptions.None, _target);
            }
            EditorGUILayout.EndVertical();
        }
    }
}