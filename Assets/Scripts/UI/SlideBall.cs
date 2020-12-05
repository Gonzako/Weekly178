using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideBall : MonoBehaviour
{
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _Active;

    [SerializeField] private Image _img;

    private bool isBallActive = false;

    public void SetActiveSlide(bool value)
    {
        isBallActive = value;
    }


    private void FixedUpdate()
    {
        if (isBallActive)
        {
            setImageSprite(_Active);
        }else if (!isBallActive)
        {
            setImageSprite(_default);
        }
    }

    private void setImageSprite(Sprite sprite)
    {
        if (_img.sprite == sprite) return;
        _img.sprite = sprite;
    }
}
