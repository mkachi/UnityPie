using UnityEngine;
using UnityEditor;
using Pie.Attributes;

namespace Pie.Editor
{
    [CustomPropertyDrawer(typeof(AssetsOnlyAttribute))]
    public class AssetsOnlyAttributeDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType.Equals(SerializedPropertyType.ObjectReference))
            {
                var asset = property.objectReferenceValue;
                if (!ReferenceEquals(asset, null))
                {
                    if (!AssetDatabase.Contains(asset))
                    {
                        Debug.LogError(string.Format("{0} is not a asset!", asset.name));
                        property.objectReferenceValue = null;
                    }
                }
            }
            EditorGUI.LabelField(position, label);
            EditorGUI.ObjectField(position, property);
        }
    }
}