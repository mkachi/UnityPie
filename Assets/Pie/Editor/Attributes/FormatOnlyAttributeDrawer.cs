using UnityEditor;
using Pie.Attributes;
using UnityEngine;

namespace Pie.Editor
{
    [CustomPropertyDrawer(typeof(FormatOnlyAttribute))]
    public class FormatOnlyAttributeDrawer
        : PropertyDrawer
    {
        private FormatOnlyAttribute _attribute
        {
            get
            {
                return (FormatOnlyAttribute)attribute;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType.Equals(SerializedPropertyType.ObjectReference))
            {
                var asset = property.objectReferenceValue;
                if (!ReferenceEquals(asset, null))
                {
                    string path = AssetDatabase.GetAssetPath(asset);
                    string format = path.Substring(path.LastIndexOf('.') + 1);
                    if (_attribute.Format != format)
                    {
                        Debug.LogError(string.Format("This property is use format only attribute, You must add .{0} format!", _attribute.Format));
                        property.objectReferenceValue = null;
                    }
                }
            }
            EditorGUI.LabelField(position, label);
            EditorGUI.ObjectField(position, property);
            //base.OnGUI(position, property, label);
        }
    }
}
