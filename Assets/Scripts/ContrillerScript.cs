
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContrillerScript : MonoBehaviour
{
    public static ContrillerScript singleton { get; private set; }
    public List<int> MapSizeXY = new List<int>() { 50, 50 };

    static ContrillerScript()
    {
        //singleton = new ContrillerScript();
    }
    void Awake()
    {
        if (!singleton)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame() // Медод при нажатии кнопки
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    static public List<int> getMapSize()
    {
        return singleton.MapSizeXY;
    }
    static public void setMapSize(List<int> mapSize)
    {
        singleton.MapSizeXY = mapSize;
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
