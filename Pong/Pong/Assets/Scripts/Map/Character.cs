using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameObjectBase
{
    public string id;
    public string tag;
    public string prefabName;

    public Character()
    {
        
    }

    public Character (int id,  string prefabName, string tag, GameObject prefab, string UniqueObjectName, float posX, float posY):base(prefab, UniqueObjectName, posX, posY)
  {
      
  }
}
