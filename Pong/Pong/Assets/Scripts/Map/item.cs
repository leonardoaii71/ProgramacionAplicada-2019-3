using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : GameObjectBase
{
    public int Id;
    public string PrefabName;
    public string Tag;
     public item (int id,  string prefabName, string tag, GameObject prefab, string UniqueObjectName, float posX, float posY):base(prefab, UniqueObjectName, posX, posY)
  {
      Id = id;
      PrefabName = prefabName;
      Tag = tag;

  }
}
