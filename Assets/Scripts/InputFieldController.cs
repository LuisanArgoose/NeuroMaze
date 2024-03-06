using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    Regex r = new Regex("^[a-zA-Z0-9]*$");

    private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = this.GetComponent<InputField>();
        inputField.onValueChanged.AddListener(delegate {InputFieldChanged(""); });
    }

    public void InputFieldChanged(string value)
    {
        inputField.text = String.Join("",inputField.text.Where(l => char.IsLetterOrDigit(l)));
    }
}
