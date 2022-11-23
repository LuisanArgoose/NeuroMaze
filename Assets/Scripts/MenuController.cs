using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject SessionPlatformCanvas;
    [SerializeField] private GameObject SingUpCanvas;
    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject SeansElement;
    [SerializeField] private int Padding;
    private List<GameObject> _seansElements;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _seansElements = new List<GameObject>();
        disableMenuView();
        ProfileClick();
    }
    
    private void view()
    {
        
        //Content.GetComponentsInChildren();

        foreach (GameObject seans in _seansElements)
        {
            Destroy(seans);
        }
        
        List<Seans> actualList = ContrillerScript.SG.LoadSeanses();
        for(int i = 0; i < actualList.Count; i++)
        {
             
            GameObject clone = Instantiate(SeansElement , Content.transform);
            SeansElement seansElement = clone.GetComponent<SeansElement>();
            seansElement.SetInfo(actualList[i]);
            Vector3 actual = clone.transform.localPosition;
            float heigth = clone.GetComponent<RectTransform>().sizeDelta.y;
            actual = new Vector3
            {
                x = actual.x,
                y = actual.y - (heigth * i) - 5,
                z = actual.z
            };
            clone.transform.localPosition = actual;
            _seansElements.Add(clone);
            //clone.transform.SetParent(Content.transform, true);
        }
         
    }
    public void StartGame() // ����� ��� ������� ������
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void ProfileClick()
    {
        menuSwitcher("Sing Up");
    }

    public void SessionPlatformClick()
    {
        menuSwitcher("Session Platform");
        view();
    }

    private void menuSwitcher(string button)
    {
        disableMenuView();
        switch (button)
        {
            case "Sing Up":
                SingUpCanvas.SetActive(true);
                break;
            case "Session Platform":
                SessionPlatformCanvas.SetActive(true);
                break;
            case "Settings":
                break;
        }
        
    }

    private void disableMenuView()
    {
        SingUpCanvas.SetActive(false);
        SessionPlatformCanvas.SetActive(false); 
        
    }
    void Update()
    {
        
    }
}
