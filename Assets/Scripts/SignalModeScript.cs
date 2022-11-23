using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalModeScript : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        updateText();
    }

    public void SignalModeClick()
    {
        ContrillerScript.SG.IsMedit = !ContrillerScript.SG.IsMedit;
        updateText();
    }

    private void updateText()
    {
        _text.text = ContrillerScript.SG.IsMedit ? "Медитация" : "Концентрация";
    }
    
}
