using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

public class LevelCreateScript : MonoBehaviour
{

    public int[] MapSizeXY = { 50, 50 }; //������� ������� �����
    public GameObject Room, RoomClone; //������ ������� � ���� ������� ��� ���� ��� �� ����������� �����
    public InputField PauseX, PauseY, PauseXS, PauseYS; //���� ����� ������

    void Start()
    {
        //������� �������� � ��������� ����
        PauseXS.text = Convert.ToString(MapSizeXY[0]);
        PauseYS.text = Convert.ToString(MapSizeXY[1]);
        //������� �������� � ���� �����
        PauseX.text = Convert.ToString(MapSizeXY[0]);
        PauseY.text = Convert.ToString(MapSizeXY[1]);
        //������ ������ ������� ���������� �������� �� �������� MapSizeXY
        RoomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
        
    }

    void Update()
    {
        
    }
    //������������ ������ ��� ���������� ����
    public void StartRecreateLevel()
    {
        try
        {
            //������� ������� ������ �� ����� �����
            MapSizeXY[0] = Convert.ToInt32(PauseXS.text);
            MapSizeXY[1] = Convert.ToInt32(PauseYS.text);
            //���� ��������, �� ������� ���������� �������
        }
        catch { }
        //������� ���
        MainCreate();
        //������� ������� � ���� �����
        PauseX.text = Convert.ToString(MapSizeXY[0]);
        PauseY.text = Convert.ToString(MapSizeXY[1]);
    }
    //������������ ������ ��� ���� �����
    public void RecreateLevel()
    {
        
        try
        {
            //������� ������� ������ �� ����� �����
            MapSizeXY[0] = Convert.ToInt32(PauseX.text);
            MapSizeXY[1] = Convert.ToInt32(PauseY.text);
            //���� ��������, �� ������� ���������� �������
        }
        catch {}
        //������� ���
        MainCreate();
    }
    void MainCreate()
    {
        //�������� �� ����������� �� 5 �� 100
        if (MapSizeXY[0] < 5 || MapSizeXY[0] > 100 || MapSizeXY[1] < 5 || MapSizeXY[1] > 100)
        {
            return;
        }
        //��������� ���������� ��������
        Destroy(RoomClone);
        //�������� �����
        RoomClone = Instantiate(Room, new Vector3(-7.7f, 4.16f, -0.9f), Quaternion.identity);
    }
}
