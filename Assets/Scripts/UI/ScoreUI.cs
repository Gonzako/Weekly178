using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI position;
    [SerializeField] TextMeshProUGUI nickname;
    [SerializeField] TextMeshProUGUI points;

  public void SetScore(HighScore score)
    {
        points.text = score.points.ToString();
        nickname.text = score.nickname;
    }
}
