using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] ScriptableScene _entryLevel;



    public void NewGame()
    {
        Debug.Log(_entryLevel.scenePath);
        SceneManager.LoadScene(_entryLevel.scenePath);
    }
}

