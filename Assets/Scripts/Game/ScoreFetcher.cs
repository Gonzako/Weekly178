using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreFetcher : MonoBehaviour
{
    [SerializeField] private HighscoreVariable _highscores;
    [SerializeField] private HighscoreEvent onDataUpdated;

    private void Start()
    {
        GetHighScore();
    }
    private void GetHighScore()
    {
        var api = "http://localhost:5001/highscore-jammer/us-central1/webApi/api/v1";
        RestClient.GetArray<HighScore>(api + "/scores").Then(res => {
            Debug.Log(res);
            _highscores._scores.AddRange(res);
            onDataUpdated.Raise(_highscores);         
        });  
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