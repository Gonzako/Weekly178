using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class ValueDisplayer : MonoBehaviour
{
    [SerializeField] private string _displayFormat = "The current price is {0} per ounce.";
    [SerializeField] private Text _text;
    [SerializeField] private BaseVariable[] _variables;


    public void SetValueToText()
    {
        string rs = string.Format(_displayFormat, _variables);
        rs = rs.Replace("<br>", "\n");
        _text.text = rs;
    }   
}
