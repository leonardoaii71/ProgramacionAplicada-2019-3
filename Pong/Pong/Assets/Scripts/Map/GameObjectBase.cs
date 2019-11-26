using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectBase
{
    public string UniqueObjectName;
    public float PosX;
    public float PosY;
    private GameObject gameObjectRef;
    // Start is called before the first frame update

    public GameObjectBase()
    {
        
    }

    public GameObjectBase(GameObject prefab, string UniqueObjectName, float posX, float posY)
    {
        gameObjectRef = UnityEngine.Object.Instantiate(prefab, new Vector3(posX, -posY), Quaternion.identity);
        gameObjectRef.name = UniqueObjectName;
    }

    ~GameObjectBase(){
        UnityEngine.Object.Destroy(gameObjectRef);
    }
    
    public void Activate(){
        gameObjectRef.SetActive(true);
    }

    public void Inactive(){
        gameObjectRef.SetActive(false);
    }

    public GameObject GetObject(){
        return this.gameObjectRef;
    }
}

