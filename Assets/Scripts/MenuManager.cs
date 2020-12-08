using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] ScriptableScene _entryLevel;

    public void NewGame()
    {
        SceneManager.LoadScene(_entryLevel.scene.name);
    }
}
