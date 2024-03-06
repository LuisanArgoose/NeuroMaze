
using System.Collections.Generic;
using UnityEngine;

using System;
using MazeLib;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCreateScript : MonoBehaviour
{

    
    private GameObject _roomClone;
    public GameObject Room,EscapeMenu; //Пресет комнаты и клон комнаты для того что бы создавалась новая
    public Text SizeSliderValue, Timer;
    public Slider SizeSlider;
    private bool _isPauseActive = false;
    
    
    void Start()
    {
        
        //Создаю пресет который воссоздаст лабиринт по размерам MapSizeXY
        MainCreate();
        //SizeSliderValue.text = String.Join("X", ContrillerScript.getMapSize());
        
        SizeSlider.value = ContrillerScript.SG.GetMapSize()[0];
        SizeSliderValueChanged();
        ContrillerScript.SG.StartGetSignal();

    }

    public void ControlModeClick()
    {
        ContrillerScript.SG.IsArmMode = !ContrillerScript.SG.IsArmMode;
    }

    public void SizeSliderValueChanged()
    {
        
        List<int> mapSizeLochal = new List<int>() {5,5};
        mapSizeLochal[0] = Convert.ToInt32(SizeSlider.value);
        mapSizeLochal[1] = Convert.ToInt32(SizeSlider.value);
        SizeSliderValue.text = String.Join("X", mapSizeLochal);
        ContrillerScript.SG.SetMapSize(mapSizeLochal);
    }

    public void ChangePause()
    {
        _isPauseActive = !_isPauseActive;
        EscapeMenu.SetActive(_isPauseActive);
    }

    public void EndGame()
    {
        ContrillerScript.SG.SetTime(_time);
        ContrillerScript.SG.SaveGame();
        MainCreate();
    }

    public void StartMainMenu() // Медод при нажатии кнопки
    {
        ContrillerScript.SG.StopGetSignal();
        SceneManager.LoadScene("Scenes/MainScene");
    }

    private float _time = 0f;
    private void Update()
    {

        _time += Time.deltaTime;
        UpdateTimeText();

    }
    

    private void UpdateTimeText()
    {
        float minutes = Mathf.FloorToInt(_time / 60);
        float seconds = Mathf.FloorToInt(_time % 60);
        Timer.text = $"{minutes:00} : {seconds:00}";
         
    }

    public void MainCreate()
    {
        //Уничтожаю предыдущий лабиринт
        if (_roomClone)
        {
            Destroy(_roomClone);
        }
            
        //Размещаю новый
        _roomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
        _time = 0f;
    }
}
