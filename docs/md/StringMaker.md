# Unity Pie

### StringMaker
#### Small
``` cs
public static StringMaker Small;
```
**Description**  
Used to create small strings.  
  
#### Medium
``` cs
public static StringMaker Medium;
```
**Description**  
Use this when creating medium-length strings.   
  
#### Large
``` cs
public static StringMaker Large;
```
**Description**  
Used to create large-sized strings.  
  
#### ToString
``` cs
public override string ToString();
```
**Description**  
Gets the string created by StringMaker.  
  
#### Clear
``` cs
public StringMaker Clear();
```
**Description**  
Clear the string buffer.  
  
### Sample
``` cs
public class Sample
    : MonoBehaviour
{
    void Awake()
    {
        string str = StringMaker.small + "Hello" + "World, " + 10 + ", " + 1.0f;
    }
}
```

##### [Back](index.html)