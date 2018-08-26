using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System.IO;
using System.Text;

namespace Pie.Editor
{
    public class CreateScriptAsset
        : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            string text = File.ReadAllText(resourceFile);
            string className = Path.GetFileNameWithoutExtension(pathName);

            className = className.Replace(" ", "_");

            text = text.Replace("#SCRIPTNAME#", className);
            text += "\n";

            UTF8Encoding encoding = new UTF8Encoding(true, false);
            File.WriteAllText(pathName, text, encoding);

            AssetDatabase.ImportAsset(pathName);
            MonoScript asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);
        }
    }
}