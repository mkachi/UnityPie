using UnityEngine;
using System.Text;

namespace Pie.Editor
{
    public sealed class HierarchyAdder
    {
        public static GameObject Add(string name, params Component[] components)
        {
            int failCount = 0;
            string objectName = name;

            StringBuilder sb = new StringBuilder();
            while (GameObject.Find(objectName) != null)
            {
                sb.Remove(0, sb.Length);
                ++failCount;
                sb.Append(name).Append("_").Append(failCount);
                objectName = sb.ToString();
            }
            GameObject result = new GameObject();
            result.name = objectName;

            for (int i = 0; i < components.Length; ++i)
            {
                if (ReferenceEquals(result.GetComponent(components[i].GetType()), null)) 
                {
                    result.AddComponent(components[i].GetType());
                }
            }
            return result;
        }
    }
}