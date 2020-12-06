using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplayer : MonoBehaviour
{
    private ScoreUI[] _scoreElements;
    [SerializeField]private Transform _scoreParent;

    // Start is called before the first frame update
    void Start()
    {
        _scoreElements = _scoreParent.GetComponentsInChildren<ScoreUI>();

        foreach (ScoreUI ui in _scoreElements)
        {
            ui.gameObject.SetActive(false);
        }
    }

    public void SetData(HighscoreVariable highscore)
    {
        for(int x = 0; x < highscore._scores.Count; x++)
        {
            _scoreElements[x].gameObject.SetActive(true);
            _scoreElements[x].SetScore(highscore._scores[x]);
        }
    }
}
