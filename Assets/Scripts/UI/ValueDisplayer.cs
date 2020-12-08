using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using TMPro;

public class ValueDisplayer : MonoBehaviour
{
    [SerializeField] private string _displayFormat = "The current price is {0} per ounce.";
    [SerializeField] private Text _text;
    [SerializeField] private TextMeshProUGUI _meshText;
    [SerializeField] private BaseVariable[] _variables;

    private void FixedUpdate()
    {
        SetValueToText();
    }

    public void SetValueToText()
    {
        string rs = string.Format(_displayFormat, _variables);
        rs = rs.Replace("\n", "<br>");
        if (_text != null)
            _text.text = rs;
        if (_meshText != null)
            _meshText.text = rs;
    }   
}
