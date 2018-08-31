# Unity Pie
### Security
#### CryptoScriptLoader
![CryptoScriptLoader](img/CryptoScriptLoader.png)
**Description**  
Invoke a script encrypted with openSSL.  
Enter Key and IV and put your encrypted script.  
The encrypted dll must be in the Assets Folder.  
  
Encryption is possible with the `ScriptEncrypter` included in the library.  
#### SecurityPrefs
``` cs
SecurityPrefs.SetInt("Sample", 999);
SecurityPrefs.GetInt("Sample");
```
**Description**  
Existing PlayerPrefs and usage are the same.  
The hacker encrypts the contents of PlayerPrefs so that they are not easily accessible.  
  
##### [Back](index.html)