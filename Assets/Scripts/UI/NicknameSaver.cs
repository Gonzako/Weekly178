using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicknameSaver : MonoBehaviour
{
    [SerializeField] private string _nickname;
    [SerializeField] private GameData _data;

    public void Input(string value)
    {
        _nickname = value;
    }

    public void SubmitNickname()
    {
        _data.nickname = _nickname;
    }
}
