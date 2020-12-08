using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;
using System;

public class TimeDisplayer : MonoBehaviour
{
    [SerializeField] private FloatVariable _timer;
    [SerializeField] private TextMeshProUGUI _text;

    private void FixedUpdate()
    {
        TimeSpan t = TimeSpan.FromSeconds(_timer);

        string answer = t.ToString(@"\:mm\:ss");
        string rs = answer.Substring(1, answer.Length-1);
        _text.text = rs;
    }
}
