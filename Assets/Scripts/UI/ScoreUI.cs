using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text position;
    [SerializeField] Text nickname;
    [SerializeField] Text points;

  public void SetScore(HighScore score)
    {
        points.text = score.points.ToString();
        nickname.text = score.nickname;
    }
}
