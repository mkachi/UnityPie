# Unity Pie

### Attributes
#### AssetsOnlyAttribute
``` cs
public class Sample
    : MonoBehaviour
{
    [AssetsOnly]
    public GameObject _assetsOnly;
}
```
**Description**  
AssetsOnlyAttribute allows you to reference only Asset files.  
   
#### FormatOnlyAttribute
``` cs
public class Sample
    : MonoBehaviour
{
    [FormatOnly("txt")]
    public UnityEngine.Object _formatOnly;
}
```
**Description**  
FormatOnlyAttribute can only refer to files of the specified type.  
  
#### SceneObjectOnlyAttribute
``` cs
public class Sample
    : MonoBehaviour
{
    [SceneObjectOnly]
    public GameObject _gameObjectOnly;
}
```
**Description**  
SceneObjectOnlyAttribute can only refer to objects in the Scene.  
  
##### [Back](index.html)