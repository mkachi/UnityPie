using UnityEngine;
using UnityEditor;
using Pie.Attributes;

namespace Pie.Editor
{
    [CustomPropertyDrawer(typeof(SceneObjectOnlyAttribute))]
    public class SceneObjectOnlyAttributeDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType.Equals(SerializedPropertyType.ObjectReference))
            {
                var asset = property.objectReferenceValue;
                if (!ReferenceEquals(asset, null))
                {
                    if (!GameObject.Find(asset.name))
                    {
                        Debug.LogError(string.Format("{0} is not a scene object!", asset.name));
                        property.objectReferenceValue = null;
                    }
                }
            }
            EditorGUI.LabelField(position, label);
            EditorGUI.ObjectField(position, property);
        }
    }
}