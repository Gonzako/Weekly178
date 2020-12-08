using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private IntVariable _Score = null;
    [SerializeField] private FloatVariable _timer = null;
    [SerializeField] private bool _shouldTrack = true;

    [SerializeField] private const int basescore = 999999;
    [SerializeField] private const int multiplier = 10;
    [SerializeField] private IntGameEvent onScoreCalculated;

    private void Start()
    {
        _timer.Value = 0F;
    }

    private void FixedUpdate()
    {
        if (_shouldTrack == false) return;
        _timer.Value += Time.deltaTime;
    }

    public void CalculateScore()
    {
        _shouldTrack = false;
        _Score.Value = (int)(basescore / _timer);
        onScoreCalculated.Raise(_Score.Value);
    }
}
