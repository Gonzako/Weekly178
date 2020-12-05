using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class SlideView : MonoBehaviour
{
    [SerializeField] private SlideDetails _details;
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        if (_details._clip == null || _details._description == null) return;

        _player.clip = _details._clip;
        _text.text = _details._description;
    }
}

public struct SlideDetails
{
    public VideoClip _clip;
    public string _description;
}