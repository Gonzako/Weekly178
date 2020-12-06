using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[System.Serializable]
[CreateAssetMenu(fileName = "HighScoreVariable", menuName = "Variables/HighscoreVariable")]
public class HighscoreVariable : ScriptableObject
{
    public List<HighScore> _scores;
}

