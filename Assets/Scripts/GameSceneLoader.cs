using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class GameSceneLoader : MonoBehaviour
{
    [SerializeField] private ScriptableSceneEvent onLoadLevel;
    [SerializeField] private GameData _gamedata;

    [SerializeField] private ScriptableScene _menu;


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
        SceneManager.LoadScene(level.scenePath);
    }

    public void LoadNextLevel()
    {
        int currentIndex = _gamedata._gameLevels.IndexOf(_gamedata.currentLevel);
        if (currentIndex + 1 > _gamedata._gameLevels.Count - 1) return;
        SceneManager.LoadScene(_gamedata._gameLevels[currentIndex + 1].scenePath);
        _gamedata.currentLevel = _gamedata._gameLevels[currentIndex+1];
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
      
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(_menu.scenePath);
    }
}
