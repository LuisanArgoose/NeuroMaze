using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
using UnityEngine.UI;
using MazeLib;
using UnityEngine.Networking;



public class NewBehaviourScript : MonoBehaviour
{
    public GameObject WallBlock, Infinity, Room, Clone, LavaBlock, BarObject, WarningObject, EscapeMenu, AcceptMenu, AcceptExitButton, PauseX, PauseY, TimerText, Maincanvas, Mstart, ConBut, ConButS;
    public Getstates Bar;
    public float RotationSpeed = 1.0f;
    private Vector2 velocity;
    private int LevelNumber = 0;
    public int[] MapSizeXY = {50,50};
    private bool ArmCondition = false;
    private bool NeuroCondition = true;
    private bool Escape = false;
    private bool StartMenu = true;
    private bool MedCon = false;
    private int Select = 0;
    


    
    Maze Map;
    Rigidbody2D m_Rigidbody;
    EdgeCollider2D m_Collider2D;
    Vector2 VectorMath;
    Image BarImage, WarningImage;
    Text BarText, WarningText, ConButText, ConButSText;

    private void CreateMap(int[,] Map){
        
        
        float x =-7.7f;
        float y =4.16f;
        bool Zero = true;
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {   
                    if(Map[i, j] !=1 & Zero)
                    {

                        if (Map[i, j] != 1)
                        {
                            Clone = Instantiate(LavaBlock, new Vector3(x + 1.19f * j, y - 1.19f * i, -1f + 0.0001f * (j - i)), Quaternion.identity);
                            Clone.transform.SetParent(Room.transform, true);
                        }
                        
                        if (Map[i, j] == 2)
                        {
                            transform.position = new Vector3(x + 1.19f * j, y - 1.19f * i, -1f);
                            Camera.main.transform.position = new Vector3(x + 1.19f * j, y - 1.19f * i,-10.0f);
                        }
                        if (Map[i, j] == 3)
                        {
                            Clone = Instantiate(Infinity, new Vector3(x + 1.19f * j, y - 1.19f * i, -2f), Quaternion.identity);
                            Clone.transform.SetParent(Room.transform, true);
                        }
                    }
                    if(!Zero)
                    {
                        if (Map[i, j] == 1)
                        {
                            Clone = Instantiate(WallBlock, new Vector3(x + 1.19f * j, y - 1.19f * i, -1f - 0.0001f * (1+j + i)), Quaternion.identity);
                            Clone.transform.SetParent(Room.transform, true);
                        }
                    }
                }
            }
            Zero = false;
        }
        timer = 0;
        
        
        
    }
    public void Exit()
    {
        AcceptMenu.SetActive(true);
    }
    public void AcceptExit()
    {
        Application.Quit();
    }
    public void BadAccept()
    {
        AcceptMenu.SetActive(false);
    }
    public void MedButtonClick()
    {
        MedCon = !MedCon;
        if (MedCon)
        {
            Select = 1;
            ConButText.text = "Медитация";
            ConButSText.text = "Медитация";
        }
        else
        {
            Select = 0;
            ConButText.text = "Концентрация";
            ConButSText.text = "Концентрация";
        }
    }
    public void ArmButtonClick()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            ArmCondition = !ArmCondition;
            NeuroCondition = !NeuroCondition;
        }


    }
    private int timer = 0;
    private IEnumerator coroutine;
    float ite1;
    float ite2;
    IEnumerator WaitAndPrint()
    {
        while (true)
        {
            TimerText.GetComponent<Text>().text =  Convert.ToString(timer++);
            yield return new WaitForSeconds(1);
        }
    }

    // Наша новая корутина 
    // Здесь можно разделить на две корутины(отдельно на медитацию отдельно на концетрацию)
    IEnumerator WaitHttp()
    {
        while (true)
        {
            string con="";
            string med="";
            // Создаем запрос
            UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:2336/concentration");
            // Ждем результата
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
                
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Bar = new Getstates();
        coroutine = WaitAndPrint();
        
        Maincanvas.SetActive(false);
        AcceptMenu.SetActive(false);
        EscapeMenu.SetActive(false);
        Map = new Maze(MapSizeXY[0], MapSizeXY[1]);
        Room = Instantiate(Room,new Vector3(-7.7f,4.16f,-0.9f),Quaternion.identity);
        BarImage = BarObject.GetComponent<Image>();
        BarText = BarObject.GetComponentInChildren<Text>();
        ConButText = ConBut.GetComponentInChildren<Text>();
        ConButSText = ConButS.GetComponentInChildren<Text>();

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<EdgeCollider2D>();
        WarningImage = WarningObject.GetComponent<Image>();
        WarningText = WarningObject.GetComponentInChildren<Text>();

        velocity = new Vector2(0.0f, 0.1f);
        CreateMap(Map.GetNewLevel());
        ite1 = m_Rigidbody.position.x;
        ite2 = m_Rigidbody.position.y;
        PauseX.GetComponent<Text>().text = Convert.ToString(MapSizeXY[0]);
        PauseY.GetComponent<Text>().text = Convert.ToString(MapSizeXY[1]);


    }
    public void StartMenuBut()
    {
        Mstart.SetActive(false);
        Maincanvas.SetActive(true);
        EscapeMenu.SetActive(false);
        StartMenu = false;
        StartCoroutine(coroutine);
        // Здесь запускаем нашу корутину на получение данных с нейроплея
        StartCoroutine(WaitHttp());
    }
    public void Pause()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            Escape = !Escape;
            if (Escape)
            {
                StopCoroutine(coroutine);
            }
            else
            {
                StartCoroutine(coroutine);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float Pot = 0;
        if (Input.GetKeyDown(KeyCode.Escape) & !AcceptMenu.activeSelf)
        {
            Pause();
        }
        if(!StartMenu) { 
        //Bar.GetState();
        }

        if (!Bar.Connect || !NeuroCondition)
        {
            
            BarText.text = "Подключение...";
            if (ArmCondition)
            {
                BarText.text = "Ручной режим";
                ArmCondition = true;
            }
            


            if (!Bar.Connect) {
                WarningObject.SetActive(true);
            }
            

                
        }
        else 
        {
            ArmCondition = false;
            string Textc = "0%";
            WarningObject.SetActive(false);
            
            Pot = (float)(Bar.States[Select]) / 100;
            
                           
            Textc = Convert.ToString(Bar.States[Select]) + "%" + Bar.debug;
            if (!Escape) {
                BarImage.fillAmount = Pot;
                BarText.text = Textc;
            }
        }
        if (Escape)
        {
            EscapeMenu.SetActive(true);    
        }
        else
        {            
            EscapeMenu.SetActive(false);
        }
        m_Rigidbody.velocity *=.0f;
        m_Rigidbody.angularVelocity *= .0f;
        velocity = new Vector2(Mathf.Cos(m_Rigidbody.rotation*Mathf.PI/180)*0.05f , Mathf.Sin(m_Rigidbody.rotation * Mathf.PI / 180) * 0.05f);
        if (!Escape)
        {
            if (Input.GetKey(KeyCode.Space) & ArmCondition || Pot > 0.5 & NeuroCondition)
            {

                m_Rigidbody.MovePosition(m_Rigidbody.position + velocity);

                if (m_Rigidbody.position[0] - Camera.main.transform.position[0] > 7.0f)
                {

                    Camera.main.transform.position = new Vector3(Camera.main.transform.position[0] + 0.05f, Camera.main.transform.position[1], Camera.main.transform.position[2]);
                }
                else if (m_Rigidbody.position[0] - Camera.main.transform.position[0] < -7.0f)
                {

                    Camera.main.transform.position = new Vector3(Camera.main.transform.position[0] - 0.05f, Camera.main.transform.position[1], Camera.main.transform.position[2]);
                }
                if (m_Rigidbody.position[1] - Camera.main.transform.position[1] > 3.0f)
                {

                    Camera.main.transform.position = new Vector3(Camera.main.transform.position[0], Camera.main.transform.position[1] + 0.05f, Camera.main.transform.position[2]);
                }
                else if (m_Rigidbody.position[1] - Camera.main.transform.position[1] < -3.0f)
                {

                    Camera.main.transform.position = new Vector3(Camera.main.transform.position[0], Camera.main.transform.position[1] - 0.05f, Camera.main.transform.position[2]);
                }
            }
            else
            {
                transform.Rotate(0.0f, 0.0f, RotationSpeed);
            }
        }              
        if (Input.GetKey(KeyCode.C)&&Input.GetKey(KeyCode.H)&&Input.GetKey(KeyCode.E)&&Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.T)){
            m_Collider2D.isTrigger = true;
        } 
        if (Input.GetKey(KeyCode.O)&&Input.GetKey(KeyCode.U)&&Input.GetKey(KeyCode.T)){
            m_Collider2D.isTrigger =false;
        }      
    }
    public void Recreate()
    {
        
        try
        {
            MapSizeXY[0] = Convert.ToInt32(PauseX.GetComponent<Text>().text);
            MapSizeXY[1] = Convert.ToInt32(PauseY.GetComponent<Text>().text);
            if (MapSizeXY[0] < 5 || MapSizeXY[0] > 100 || MapSizeXY[1] < 5 || MapSizeXY[1] > 100) {
                return;
            }

        
            foreach (Transform child in Room.transform)
            {
                print(child.gameObject.name);
                Destroy(child.gameObject);
            }
            LevelNumber++;
            StopCoroutine(coroutine);

            CreateMap(Map.GetNewLevel(MapSizeXY[0], MapSizeXY[1]));
            Debug.Log(Map.MaxWay);
        }
        catch { }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Finish"){
            foreach(Transform child in Room.transform)
            {
                print(child.gameObject.name);
                Destroy(child.gameObject);
            }
            LevelNumber++;
            StopCoroutine(coroutine);
            CreateMap(Map.GetNewLevel(MapSizeXY[0], MapSizeXY[1]));
            StartCoroutine(coroutine);
        }

    }
    

    public class Getstates
    {
        //System.Random rnd = new System.Random();
        public string debug = "";
        public int[] States = {0,0};
        public bool Connect = false;

        private static readonly HttpClient client = new HttpClient();
        public void GetState(string conData, string medData)
        {
            try                     
            {
                if (conData !="" && medData!="")
                {
                    // ВНИМАНИЕ КОСТЫЛЬ //
                    string medVal = conData.Split(',')[1].Split(':')[1];
                    // КОНЕЦ КОСТЫЛЯ //

                    // ВНИМАНИЕ КОСТЫЛЬ //
                    string conVal = medData.Split(',')[1].Split(':')[1];
                    // КОНЕЦ КОСТЫЛЯ //

                    Debug.Log(medVal);
                    States[0] = Convert.ToInt32(conVal);
                    //States[0] = rnd.Next(0, 100);
                    States[1] = Convert.ToInt32(medVal);
                    Connect = true;
                }
                else
                {
                    Connect = false;
                }      
            }
            catch
            {
                Connect = false;
            } 
        }
    }


}
