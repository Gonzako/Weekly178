using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class GameSceneLoader : MonoBehaviour
{
    [SerializeField] private ScriptableSceneEvent onLoadLevel;
    [SerializeField] private GameData _gamedata;

    public static GameSceneLoader instance;

    private void Start()
    {
        DontDestroyOnLoad(this);  
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Load(ScriptableScene level)
    {
        _gamedata.currentLevel = level;
        SceneManager.LoadScene(level.scene.name);
    }
}
