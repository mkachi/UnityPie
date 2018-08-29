# Unity Pie

### ObjectPool
#### Constructors
``` cs
public ObjectPool(GameObject prefab, int size);
```
**Description**  
Constructor of ObjectPool  
  
**Values**  
| Value | Description |
|---------|--------------------------------------------|
| prefab | The GameObject to be created in the Pool |
| size | Number to be generated |
  
``` cs
public ObjectPool(GameObject prefab, int size, Transform parent);
```
**Description**  
Constructor of ObjectPool  
  
**Values**  
| Value | Description |
|---------|--------------------------------------------|
| prefab | The GameObject to be created in the Pool |
| size | Number to be generated |
| parent | Parent of the pool object |
  
#### Add
``` cs
public void Add(GameObject item);
```
**Description**  
Add an object to the pool.  
  
**Values**  
| Value | Description |
|---------|--------------------------------------------|
| item | Objects to add |
  
#### Peek
``` cs
public GameObject Peek(bool active = true);
```
**Description**  
Get the useable objects.  
  
**Values**  
| Value | Description |
|---------|--------------------------------------------|
| active | Whether the imported object is active |
  
##### [Back](index.html)