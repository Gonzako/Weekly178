using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;


public class ScoreFetcher : MonoBehaviour
{
    [SerializeField] private HighscoreVariable _highscores;
    [SerializeField] private HighscoreEvent onDataUpdated;
    [SerializeField] private GameData _data;

    [SerializeField] private string _api = "https://us-central1-highscore-jammer.cloudfunctions.net/webApi/api/v1";

    public void GetHighScore()
    {
        Debug.Log("test");
        RestClient.GetArray<HighScore>(_api + "/scores/"+_data.currentLevel.scene_id).Then(res => {
            Debug.Log(res);
            _highscores._scores = new List<HighScore>();
            _highscores._scores.AddRange(res);
            onDataUpdated.Raise(_highscores);         
        });  
    }

    public void AddHighScore(int score)
    {
        Debug.Log("adding " + score);
        HighScore hscore = new HighScore(_data.nickname, score, _data.currentLevel.scene_id);
        RestClient.Post<HighScore>((_api + "/scores/new"), hscore);

        GetHighScore();
    }
}

[System.Serializable]
public struct HighScore
{
    public HighScore(string nickname, int points, string scene_id)
    {
        this.nickname = nickname;
        this.points = points;
        this.scene_id = scene_id;
    }
    public string nickname;
    public int points;
    public string scene_id;
}