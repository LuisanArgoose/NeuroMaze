using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _text;
    private Image _image;
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var SG = ContrillerScript.SG;
        if (SG.IsArmMode)
        {
            _text.text = "Ручной режим";
        }
        else
        {
            if (SG.Bar.Connect)
            {
                _text.text = $"{SG.Bar.ActualParameter}%";
                _image.fillAmount = SG.Bar.ActualParameter / 100.0f;
            }
            else
            {
                _text.text = "Ошибка подключения";
            }
            
        }
    }
}
