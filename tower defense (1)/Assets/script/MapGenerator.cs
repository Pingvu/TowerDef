using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{   //creating variables and List
    public GameObject MapTile;
   [SerializeField] private int mapWidth;
   [SerializeField] private int mapHeight;
   public static List<GameObject> MapTiles = new List<GameObject>();
   public static List<GameObject> PathTiles = new List<GameObject>();
   public static GameObject startTile;
   public static GameObject endTile;
   private  bool reachedX = false;
   private  bool reachedY = false;
   private GameObject currentTile;
   private int CurrentIndex;
   private int NextIntdex;
   public Color pathColor;
   public Color startColor;
   public Color  endColor;
   private void Start() //run the method GenerateMap
   {
       GenerateMap();
   }
   private List<GameObject> getTopEdgeTiles() //choose a random tile at the top to make spawn tile
   {
          List<GameObject> edgeTiles = new List<GameObject>();
          for (int i = mapWidth * (mapHeight-1); i< mapWidth * mapHeight;i++)
                {
                    edgeTiles.Add(MapTiles[i]);
                }
          return edgeTiles;
   }
   private List<GameObject> getbottomedgeTiles () //choose a random tile at the bottom to make finish line
   {
          List<GameObject> edgeTiles = new List<GameObject>();
          for (int i = 0; i < mapWidth;i++)
          {
              edgeTiles.Add(MapTiles[i]);
          }
         return edgeTiles;
   }
   private void moveDown() //move the path down
   {
        PathTiles.Add(currentTile);
        CurrentIndex= MapTiles.IndexOf(currentTile);
        NextIntdex = CurrentIndex-mapWidth;
        currentTile = MapTiles[NextIntdex];
   }
   private void moveLeft() //move the path left
   {
        PathTiles.Add(currentTile);
        CurrentIndex= MapTiles.IndexOf(currentTile);
        NextIntdex = CurrentIndex-1;
        currentTile = MapTiles[NextIntdex];
   }
   private void moveRight() //move the path right
   {
        PathTiles.Add(currentTile);
        CurrentIndex= MapTiles.IndexOf(currentTile);
        NextIntdex = CurrentIndex+1;
        currentTile = MapTiles[NextIntdex];
   }
    private void GenerateMap() //creating many variables to make a map,path,start and finish line, according to mapHeight and mapWidth
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth;x++)
            {
                GameObject newTile = Instantiate(MapTile);
                MapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x,y);
            }
        }
        List<GameObject> topEdgeTiles= getTopEdgeTiles();
        List<GameObject> bottomEdgeTiles= getbottomedgeTiles();
        int rand1 = Random.Range(0, mapWidth);
        int rand2 = Random.Range(0, mapWidth);
        startTile=  topEdgeTiles[rand1];
        endTile = bottomEdgeTiles[rand2];
        currentTile=startTile;
        moveDown();
        int loopCount=0;
        while (reachedX==false) 
        {   loopCount++;
        if (loopCount> 100)
        {
            Debug.Log("Loop ran too long");
            break;
        }
            if (currentTile.transform.position.x>endTile.transform.position.x)
            {
              moveLeft();
            }
            else if (currentTile.transform.position.x<endTile.transform.position.x)
          {
            moveRight();
          }
          else{
              reachedX=true;
          }
          
        }
        while (reachedY == false){
            if (currentTile.transform.position.y>endTile.transform.position.y)
            {
                moveDown();
            }
            else
            {
                reachedY = true;
            }
            
        }
        PathTiles.Add(endTile);
        foreach(GameObject obj in PathTiles) //adding color to path,start and end tile
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }
        startTile.GetComponent<SpriteRenderer>().color = startColor;
        endTile.GetComponent<SpriteRenderer>().color = endColor;

    }
}
