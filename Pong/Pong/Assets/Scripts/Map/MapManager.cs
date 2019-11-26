using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class MapManager : MonoBehaviour
{
    public List<GameObject> Prefabs;
    
    public GameObject a;
    public GameObject b;
    public GameObject p;
    public GameObject q;
    public GameObject A;
    public GameObject G;
    public GameObject P;
    public GameObject O;
    public GameObject M;
    public GameObject U;
    public GameObject V;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject Player;
    public GameObject enemyPrefab;
    public GameObject character5;
    public GameObject character6;
    public GameObject character7;
    public GameObject character8;
    public GameObject character9;
    public GameObject character10;
    XmlDocument xmlDoc;
    private Dictionary<char, GameObject> tilePrefabs;
    private Dictionary<string, GameObject> CharactersPrefabs;
    private Dictionary<string, GameObject> ItemsPrefabs;

    private void Awake() {
     tilePrefabs = new Dictionary<char, GameObject> {
         ['a'] = a,
         ['b'] = b,
         ['p'] = p,
         ['q'] = q,
         ['A'] = A,
         ['G'] = G,
         ['P'] = P,
         ['O'] = O,
         ['M'] = M,
         ['U'] = U,
         ['V'] = V,
         ['1'] = one,
         ['2'] = two,
         ['3'] = three,
         ['4'] = four,       

     };

      CharactersPrefabs = new Dictionary<string, GameObject>{
         {"Player", character1},
         {"Morah", character2},
         {"Lionel", character3},
         {"Yuyu", Player},
         {"Enemy1", enemyPrefab},
     };

       ItemsPrefabs = new Dictionary<string, GameObject>{
         {"ChestBanana", character5},
         {"ChestCherry", character6},
         {"ChestGrape", character7},
         {"ChestLemon", character8},
         {"ChestOrange", character9},
         {"ChestSeaweed", character10},
     };


    }
    

    // Start is called before the first frame update
    void Start()
    {
        Game.CurrentLevel = new Level();

        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Resources.Load<TextAsset>("Level1").text); 
        Debug.Log(xmlDoc.ChildNodes.Count);

        LoadMap(0, 71, 0, 40);
        LoadCharacters();
        //LoadItems();
    }

    // Update is called once per frame
    public void LoadMap(int xFrom, int xTo, int yFrom, int yTo){
        string xpath = string.Format("//level/map/row[position() >= {0} and position() <= {1}]", yFrom, yTo);
        Tile newTile;
        int xFromcp = xFrom;
        
        foreach(XmlNode currentNode in xmlDoc.SelectNodes(xpath)){
            for(xFrom = xFromcp; xFrom <= xTo; xFrom++){
                newTile = new Tile(tilePrefabs[currentNode.InnerText[xFrom]],
                currentNode.InnerText[xFrom] + "," + xFrom.ToString() + "," 
                + yFrom, xFrom, yFrom);
                //Game.CurrentLevel.items.Add(newTile)
            }
            yFrom++;
        }
    }

    public void LoadCharacters(){
        Character newCharacter;
        Game.CurrentLevel.characters = new List<Character>();

        string xpath = string.Format("//level/characters/character");
        
        foreach(XmlNode currentNode in xmlDoc.SelectNodes(xpath)){
                Debug.Log(currentNode.Attributes["prefabName"].Value);
                newCharacter = new Character(
                System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                currentNode.Attributes["prefabName"].Value,
                currentNode.Attributes["tag"].Value,
                CharactersPrefabs[currentNode.Attributes["prefabName"].Value],//prefab
                currentNode.Attributes["uniqueObjectName"].Value,
                System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                System.Convert.ToSingle(currentNode.Attributes["posY"].Value));
                
                Game.CurrentLevel.characters.Add(newCharacter);
        }
    }
    public void LoadItems(){
        item newItem;
        Game.CurrentLevel.items = new List<item>();

        string xpath = string.Format("//level/items/item");
        
        foreach(XmlNode currentNode in xmlDoc.SelectNodes(xpath)){
            
                newItem = new item(
                System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                currentNode.Attributes["prefabName"].Value,
                currentNode.Attributes["tag"].Value,
                ItemsPrefabs[currentNode.Attributes["prefabName"].Value],//prefab,
                currentNode.Attributes["UniqueObjectName"].Value,
                System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                System.Convert.ToSingle(currentNode.Attributes["posY"].Value));
                
                Game.CurrentLevel.items.Add(newItem);
        }

    }

    void InitializeMap(){
        XmlNode mapNode = xmlDoc.SelectSingleNode("/level/map");
        Game.CurrentLevel.Map = new Map(
            System.Convert.ToInt32(mapNode.Attributes["width"].Value),
            System.Convert.ToInt32(mapNode.Attributes["height"].Value),
            System.Convert.ToInt32(mapNode.Attributes["TileWidth"].Value),
            System.Convert.ToInt32(mapNode.Attributes["TileHeight"].Value)
        );
    }
}
