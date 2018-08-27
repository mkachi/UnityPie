using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Pie;
using Pie.Security;
using Pie.Attributes;

public class Test
    : MonoBehaviour
{
    [FormatOnly("txt")]
    public TextAsset _formatOnly;
    [AssetsOnly]
    public Object _assetsOnly;
}