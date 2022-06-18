using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

public class LevelCreateScript : MonoBehaviour
{

    public int[] MapSizeXY = { 50, 50 }; //Базовые размеры карты
    public GameObject Room, RoomClone; //Пресет комнаты и клон комнаты для того что бы создавалась новая
    public InputField PauseX, PauseY, PauseXS, PauseYS; //Поля ввода текста

    void Start()
    {
        //Перенос размеров в стартовое меню
        PauseXS.text = Convert.ToString(MapSizeXY[0]);
        PauseYS.text = Convert.ToString(MapSizeXY[1]);
        //Перенос размеров в меню паузы
        PauseX.text = Convert.ToString(MapSizeXY[0]);
        PauseY.text = Convert.ToString(MapSizeXY[1]);
        //Создаю пресет который воссоздаст лабиринт по размерам MapSizeXY
        RoomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
        
    }

    void Update()
    {
        
    }
    //Пересоздание уровня для стартового меню
    public void StartRecreateLevel()
    {
        try
        {
            //Попытка считать данные из полей ввода
            MapSizeXY[0] = Convert.ToInt32(PauseXS.text);
            MapSizeXY[1] = Convert.ToInt32(PauseYS.text);
            //Если неудачно, то бырутся предыдущие размеры
        }
        catch { }
        //Базовый код
        MainCreate();
        //Передаю размеры в меню паузы
        PauseX.text = Convert.ToString(MapSizeXY[0]);
        PauseY.text = Convert.ToString(MapSizeXY[1]);
    }
    //Пересоздание уровня для меню паузы
    public void RecreateLevel()
    {
        
        try
        {
            //Попытка считать данные из полей ввода
            MapSizeXY[0] = Convert.ToInt32(PauseX.text);
            MapSizeXY[1] = Convert.ToInt32(PauseY.text);
            //Если неудачно, то бырутся предыдущие размеры
        }
        catch {}
        //Базовый код
        MainCreate();
    }
    void MainCreate()
    {
        //Проверка на размерность от 5 до 100
        if (MapSizeXY[0] < 5 || MapSizeXY[0] > 100 || MapSizeXY[1] < 5 || MapSizeXY[1] > 100)
        {
            return;
        }
        //Уничтожаю предыдущий лабиринт
        Destroy(RoomClone);
        //Размещаю новый
        RoomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
    }
}
