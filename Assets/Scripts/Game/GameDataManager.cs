using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private ScriptableScene _scene;
    [SerializeField] private GameData _data;

    private void Start()
    {
        _data.currentLevel = _scene;
    }

}
