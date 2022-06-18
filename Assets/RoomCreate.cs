using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeLib;

public class RoomCreate : MonoBehaviour
{
    public int[,] Map; //Карта
    public int[] MapSizeXY = { 50, 50 }; //Размеры карты
    public GameObject WallBlock, Infinity, Clone, LavaBlock, LevelCreator, Arrow; //Компоненты для постройки лабиринта
    Maze MapLib; //Библиотека генерации лабиринта
    IEnumerator coroutine;
   
    void Start()
    {
        LevelCreator = GameObject.Find("LevelCreator");
        Arrow = GameObject.Find("Arrow");
        MapSizeXY = LevelCreator.GetComponent<LevelCreateScript>().MapSizeXY; //Получаю размеры карты LevelCreator а
        MapLib = new Maze(MapSizeXY[0], MapSizeXY[1]);
        coroutine = CreateMapAsync();
        StartCoroutine(coroutine); //Пускаю корутину создания уровня

    }
    IEnumerator CreateMapAsync()
    {
        Map = MapLib.GetNewLevel(MapSizeXY[0], MapSizeXY[1]); //Генерация нового лабиринта по размерам
        float x = -7.7f; //Относительные координаты
        float y = 4.16f;
        // последовательная отрисовка. Сначала проходы, потом стены
        // Zero это флаг который переключится когда всё кроме стен будет отрисовано
        bool Zero = true; 
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] != 1 & Zero) // отрисовка всего кроме стен
                    {

                        if (Map[i, j] != 1)
                        {
                            Clone = Instantiate(LavaBlock, new Vector3(x + 1.19f * j, y - 1.19f * i, -1f + 0.0001f * (j - i)), Quaternion.identity);
                            Clone.transform.SetParent(this.transform, true);
                        }

                        if (Map[i, j] == 2)
                        {
                            Arrow.transform.position = new Vector3(x + 1.19f * j, y - 1.19f * i, -1f);
                            Camera.main.transform.position = new Vector3(x + 1.19f * j, y - 1.19f * i, -10.0f);
                        }
                        if (Map[i, j] == 3)
                        {
                            Clone = Instantiate(Infinity, new Vector3(x + 1.19f * j, y - 1.19f * i, -2f), Quaternion.identity);
                            Clone.transform.SetParent(this.transform, true);
                        }
                    }
                    if (!Zero) // Отрисовка стен
                    {
                        if (Map[i, j] == 1)
                        {
                            Clone = Instantiate(WallBlock, new Vector3(x + 1.19f * j, y - 1.19f * i, -1f - 0.0001f * (1 + j + i)), Quaternion.identity);
                            Clone.transform.SetParent(this.transform, true);
                        }
                    }



                }
            }
            Zero = false;
        }
        yield return 0;
        //timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
