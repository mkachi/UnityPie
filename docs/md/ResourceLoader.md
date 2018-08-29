# Unity Pie

### ResourceLoader
#### Get
``` cs
public static T Get<T>(string path) where T : UnityEngine.Object
```
**Description**  
Loads and caches resources.   
   
#### UnLoad
``` cs
public static void UnLoad(params string[] keys);
```
**Description**  
Remove the cached resource.  
  
#### UnLoadAll
``` cs
public static void UnLoadAll();
```
**Description**  
Remove the all cached resource.  
  
##### [Back](index.html)