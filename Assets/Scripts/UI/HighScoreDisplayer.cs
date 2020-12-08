using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplayer : MonoBehaviour
{
    [SerializeField] private ScoreUI[] _scoreElements;
    [SerializeField] private Transform _scoreParent;
    [SerializeField] private HighscoreVariable _score;


    // Start is called before the first frame update
    void Start()
    {
        _scoreElements = _scoreParent.GetComponentsInChildren<ScoreUI>();
        foreach (ScoreUI ui in _scoreElements)
            ui.gameObject.SetActive(false);
    }

    public void SetData()
    {
        Debug.Log("set");
        for(int x = 0; x < _score._scores.Count; x++)
        {
            if (x > _scoreElements.Length) return;

            _scoreElements[x].gameObject.SetActive(true);
            _scoreElements[x].SetScore(_score._scores[x]);
        }
    }
}
