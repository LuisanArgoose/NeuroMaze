
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ContrillerScript : MonoBehaviour
{
    public static ContrillerScript SG { get; private set; }
    private string _seed;
    private float _time;
    
    public Getstates Bar{ get; private set; }
    public bool IsArmMode { get; set; }
    public bool IsMedit { get; set; }
    private List<SeansPoint> _seansWriter = new List<SeansPoint>();
    private IEnumerator GetstatesCorutine;
    
    private List<Seans> _seansList = new List<Seans>();
    public List<int> MapSizeXY = new List<int>() { 50, 50 };
    private int UserID = 1;
    private string UserName = "Luisan";
    static ContrillerScript()
    {
        //singleton = new ContrillerScript();
    }
    
    void Awake()
    {
        
        if (!SG)
        {
            SG = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        Bar = new Getstates();
        IsArmMode = false;
        IsMedit = false;
        GetstatesCorutine = WaitHttp();
    }

    IEnumerator WaitHttp()
    {
        
        while (true)
        {
            string con="";
            string med="";
            // —оздаем запрос
            UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:2336/concentration");
            // ∆дем результата
            yield return www.SendWebRequest();
            
            if (www.result != UnityWebRequest.Result.Success)
            {
                //Debug.Log(www.error);

            }
            else
            {
                
                med = www.downloadHandler.text;
            }


            UnityWebRequest www1 = UnityWebRequest.Get("http://127.0.0.1:2336/meditation");
            yield return www1.SendWebRequest();

            if (www1.result != UnityWebRequest.Result.Success)
            {
                //Debug.Log(www1.error);
            }
            else
            {
                con =www1.downloadHandler.text;
            }
            Bar.GetState(con,med);
            /*
            _seansWriter.Add(new SeansPoint()
            {
                Parameter = Bar.ActualParameter,
                Time = _time
            });*/
                
        }
    }
    public void StartGetSignal()
    {
        StartCoroutine(GetstatesCorutine);
    }
    public void StopGetSignal()
    {
        StopCoroutine(GetstatesCorutine);
    }
    
    public List<int> GetMapSize()
    {
        return MapSizeXY;
    }
    public void SetMapSize(List<int> mapSize)
    {
        MapSizeXY = mapSize;
    }
    
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                                      + "/MySaveData.dat"); 
        //Debug.Log(Application.persistentDataPath);
        SaveData data = new SaveData();
        data.SeansList = _seansList;
        bf.Serialize(file, data);
        file.Close();
        //Debug.Log("Game data saved!");
    }
    public void SaveGame()
    {
        Seans seans = new Seans()
        {
            Date = DateTime.Now,
            Name = DateTime.Now.ToString(),
            Size = MapSizeXY[0],
            PlayTime = this._time,
            UserID = this.UserID,
            UserName = this.UserName,
            Seed = this._seed,
            SeansWriter  = this._seansWriter
        };
        _seansList.Add(seans);
        SaveData();
    }
    public List<Seans> LoadSeanses()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            _seansList = data.SeansList;
            file.Close();
            //Debug.Log("Game data loaded!");
        }
        //else
            //Debug.LogError("There is no save data!");
        return _seansList;
    }

    public List<Seans> GetSeansList()
    {
        return _seansList;
    }
    public void SetSeed(string seed)
    {
        _seed = seed;
    }
    public void SetTime(float time)
    {
        _time = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
