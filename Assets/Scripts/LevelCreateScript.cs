
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

public class LevelCreateScript : MonoBehaviour
{

    private List<int> _mapSizeXY = new List<int>(){ 50, 50 }; //������� ������� �����
    private GameObject _roomClone;
    public GameObject Room,EscapeMenu; //������ ������� � ���� ������� ��� ���� ��� �� ����������� �����
    public Text SizeSliderValue;
    public Slider SizeSlider;
    private bool _isPauseActive = false;

    void Start()
    {
        
        //������ ������ ������� ���������� �������� �� �������� MapSizeXY
        //EscapeMenu.SetActive(_isPauseActive);
        _roomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
        //SizeSliderValue.text = String.Join("X", ContrillerScript.getMapSize());
        SizeSlider.value = ContrillerScript.getMapSize()[0];


    }

    public void SizeSliderValueChanged()
    {
        
        List<int> mapSizeLochal = new List<int>() {5,5};
        mapSizeLochal[0] = Convert.ToInt32(SizeSlider.value);
        mapSizeLochal[1] = Convert.ToInt32(SizeSlider.value);
        SizeSliderValue.text = String.Join("X", mapSizeLochal);
        ContrillerScript.setMapSize(mapSizeLochal);
    }

    public void ChangePause()
    {
        _isPauseActive = !_isPauseActive;
        EscapeMenu.SetActive(_isPauseActive);
    }
    public void MainCreate()
    {
        //��������� ���������� ��������
        Destroy(_roomClone);
        //�������� �����
        _roomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
    }
}
