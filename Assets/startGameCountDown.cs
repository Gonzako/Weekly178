using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class startGameCountDown : MonoBehaviour
{
    TextMeshProUGUI textComp;
    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMeshProUGUI>();
        textComp.text = 1.ToString();

        var seq = DOTween.Sequence();

        var sizeTween =
            transform.DOScale(transform.localScale * 1.3f, 0.9f)
                    .SetLoops(3, LoopType.Restart).SetDelay(0.1f);
        sizeTween.onStepComplete += fillNumber;
        

        seq.Append(sizeTween);
        seq.onComplete +=  () => textComp.text = "Go!";

        seq.SetEase(Ease.OutQuart);
        seq.Play();
    }

    private void fillNumber()
    {
        var value = (int.Parse(textComp.text) + 1);
        if (value > 3)
            textComp.text = "Go!";
        else
            textComp.text = value.ToString();
    }
}
