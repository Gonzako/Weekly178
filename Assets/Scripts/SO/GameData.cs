﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    public ScriptableScene currentLevel;
    public string nickname;
    public List<ScriptableScene> _gameLevels;
}
