using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MazeLib;

public class RoomCreate : MonoBehaviour
{
    public int[,] Map; //Карта
    public List<int> MapSizeXY = new List<int>(){ 50, 50 }; //Размеры карты

    public GameObject WallBlock, Infinity, LavaBlock, LevelCreator, Arrow, VirtualMainCamera; //Компоненты для постройки лабиринта
    Maze MapLib; //Библиотека генерации лабиринта
    IEnumerator coroutine;
    GameObject prefab, clone;
    public List<Sprite> WallSprite;


    
    void Start()
    {
        Arrow = GameObject.Find("Arrow");
        MapSizeXY = ContrillerScript.getMapSize();
        MapLib = new Maze();
        CreateMapAsync();
    }
    void CreateMapAsync()
    {
        Map = MapLib.GetNewLevel(MapSizeXY[0], MapSizeXY[1]); //Генерация нового лабиринта по размерам
        Debug.Log(MapLib.GetSeed());
        //Map = MapLib.GetNewLevel(6, 6,"dw3");
        List<Cell> mapCell = MapLib.GetListMap();
        float x = -7.7f; //Относительные координаты
        float y = 4.16f;
        float step = 1.27f;
        Cell toTransform = mapCell.Single(c => c.Addons == 2);
        x -= step * (toTransform .Xpos + 1);
        y += step * (toTransform .Ypos + 1);
        this.transform.position = new Vector3(x + step * (toTransform .Xpos+1), y - step * (toTransform .Ypos + 1), -10f);
        foreach(Cell cell in mapCell)
        {
            switch (cell.Group)
            {
                case 0: ;
                    clone = Instantiate(LavaBlock, new Vector3(x + step * (cell.Xpos + 1), y - step * (cell.Ypos + 1), -0.9f  ), Quaternion.identity);
                    break;
                case 1:
                    clone = Instantiate(WallBlock , new Vector3(x + step * (cell.Xpos + 1), y - step * (cell.Ypos + 1), -0.9f  ), Quaternion.identity);
                    clone.GetComponent<SpriteRenderer>().sprite = WallSprite.Single(sp => sp.name == cell.Type);
                    break;
            }
            clone.transform.SetParent(this.transform, true);
            switch (cell.Addons)
            {
                case 2:
                    Arrow.transform.position = 
                        new Vector3(x + step * (cell.Xpos + 1), y - step * (cell.Ypos + 1), -10f);
                    Arrow.transform.rotation = Quaternion.Euler(0,0,0);
                    clone.transform.SetParent(this.transform, true);
                    break;
                case 3:
                    clone = Instantiate(Infinity, new Vector3(x + step * (cell.Xpos + 1), y - step * (cell.Ypos + 1), -2f), Quaternion.identity);
                    clone.transform.SetParent(this.transform, true);
                    break;
            }
            
        }
        WallSprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
