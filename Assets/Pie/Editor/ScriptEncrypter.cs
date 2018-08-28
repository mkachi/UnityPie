using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System;
using System.Xml.Serialization;
using System.IO;

namespace Pie.Editor
{
    public class ScriptEncrypter
        : EditorWindow
    {
        private static ScriptEncrypter _instance = null;
        private string _gmcsPath = "";
        private string _scriptPath = "";
        private string _savePath = "";

        private string _dllAdder = "";
        private List<string> _dllPaths = new List<string>();
        private Vector2 _scrollPosition = Vector2.zero;

        private string _scriptName = "";
        private string _exportDLLPath = "";
        private string _sslKey = "";

        public static void ShowWindow()
        {
            if (_instance == null)
            {
                _instance = GetWindow<ScriptEncrypter>();
                _instance.titleContent = new GUIContent("Script Encrypter");
                _instance.minSize = new Vector2(600, 300);
                _instance._gmcsPath = EditorPrefs.GetString("Pie_ScriptEncrypter_GMCSPath");

                XmlSerializer deserializer = new XmlSerializer(_instance._dllPaths.GetType());
                TextReader reader = new StringReader(EditorPrefs.GetString("Pie_ScriptEncrypter_DLLPATHS"));
                _instance._dllPaths = deserializer.Deserialize(reader) as List<string>;
            }
            _instance.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            GUILayout.Label(new GUIContent("gmcs or mcs path"));
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.TextField(_gmcsPath);
                if (GUILayout.Button(new GUIContent("..."), GUILayout.MaxWidth(50)))
                {
                    string path = EditorUtility.OpenFilePanel("gmcs or mcs", "", "*.*");
                    if (path.Length > 0)
                    {
                        _gmcsPath = path;
                        EditorPrefs.SetString("Pie_ScriptEncrypter_GMCSPath", _gmcsPath);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            GUILayout.Label(new GUIContent("Dependent library paths"));
            for (int i = 0; i < _dllPaths.Count; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.TextField(_dllPaths[i]);
                if (GUILayout.Button(new GUIContent("X"), GUILayout.MaxWidth(50)))
                {
                    _dllPaths.Remove(_dllPaths[i]);
                    SaveLibraryList();
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.TextField(_dllAdder);

                if (GUILayout.Button(new GUIContent("..."), GUILayout.MaxWidth(50)))
                {
                    string path = EditorUtility.OpenFilePanel("Dependent Library", "", "dll");
                    if (path.Length > 0)
                    {
                        _dllAdder = path;
                    }
                }

                if (GUILayout.Button(new GUIContent("Add"), GUILayout.MaxWidth(50)))
                {
                    if (!_dllAdder.Equals(string.Empty))
                    {
                        _dllPaths.Add(_dllAdder);
                        _dllAdder = "";
                        SaveLibraryList();
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Label(new GUIContent("Script path"));
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.TextField(_scriptPath);
                if (GUILayout.Button(new GUIContent("..."), GUILayout.MaxWidth(50)))
                {
                    string path = EditorUtility.OpenFilePanel("Script Path", Application.dataPath, "cs");
                    if (path.Length > 0)
                    {
                        _scriptPath = path;
                        _scriptName = path.Substring(path.LastIndexOf('/') + 1);
                        _scriptName = _scriptName.Substring(0, _scriptName.LastIndexOf('.'));
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Label(new GUIContent("Save path"));
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.TextField(_savePath);
                if (GUILayout.Button(new GUIContent("..."), GUILayout.MaxWidth(50)))
                {
                    string path = EditorUtility.SaveFolderPanel("Save Path", Application.dataPath, "");
                    if (path.Length > 0)
                    {
                        _savePath = path;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Key & IV");
            GUILayout.TextArea(_sslKey);
            if (GUILayout.Button("Copy"))
            {
                EditorGUIUtility.systemCopyBuffer = _sslKey;
            }

            GUILayout.Label("You must install OpenSSL (https://www.openssl.org/)");

            if (GUILayout.Button(new GUIContent("Encrypt")))
            {
                _sslKey = "";
                CreateDLL();
                Rc2Encrypt();
                Base64Encrypt();
                AssetDatabase.Refresh();
                MessageBox.Show("UnityPie", "Finish Script Encrypt!\nMust take note of the key and IV\nThen delete the original script", new Vector2(320, 100));
            }

            EditorGUILayout.EndVertical();
        }

        void SaveLibraryList()
        {
            XmlSerializer serializer = new XmlSerializer(_dllPaths.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            serializer.Serialize(sw, _dllPaths);
            EditorPrefs.SetString("Pie_ScriptEncrypter_DLLPATHS", sw.GetStringBuilder().ToString());
        }

        void CreateDLL()
        {
            StringBuilder sb = new StringBuilder(256);
            sb.Append(_savePath).Append("/").Append(_scriptName).Append(".dll");
            _exportDLLPath = sb.ToString();
            sb.Remove(0, sb.Length);

            sb.Append(_gmcsPath).Append(" -target:library -out:")
                .Append(_exportDLLPath);

            for (int i = 0; i < _dllPaths.Count; ++i)
            {
                sb.Append(" -r:").Append(_dllPaths[i]);
            }
            sb.Append(" ").Append(_scriptPath);

            ExecuteCommand(sb.ToString());
        }
        void Rc2Encrypt()
        {
            StringBuilder sb = new StringBuilder(64);
            sb.Append("openssl rc2 -nosalt -p -in ").Append(_exportDLLPath)
                .Append(" -out ").Append(_exportDLLPath.Replace(".dll", ".bin"));
            ExecuteCommand(sb.ToString(), true);
        }
        void Base64Encrypt()
        {
            StringBuilder sb = new StringBuilder(64);
            sb.Append("openssl base64 -nosalt -p -in ").Append(_exportDLLPath.Replace(".dll", ".bin"))
                .Append(" -out ").Append(_exportDLLPath.Replace(".dll", ".txt"));
            ExecuteCommand(sb.ToString());
            File.Delete(_exportDLLPath.Replace(".dll", ".bin"));
        }

        void ExecuteCommand(string command, bool rc2 = false)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"cmd";
            info.CreateNoWindow = !rc2;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.StandardErrorEncoding = Encoding.UTF8;
            info.Arguments = "/C " + command;

            Process terminal = Process.Start(info);
            if (!rc2)
            {
                string message = terminal.StandardError.ReadToEnd();
                if (message.ToLower().Contains("warning"))
                {
                    UnityEngine.Debug.LogWarning(message);
                }
                else if (message.ToLower().Contains("error"))
                {
                    UnityEngine.Debug.LogError(message);
                }
                else
                {
                    UnityEngine.Debug.Log(message);
                }
            }
            else
            {
                _sslKey = terminal.StandardOutput.ReadToEnd();
            }
        }
    }
}
