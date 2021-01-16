using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class MaterialColorTweener : MonoBehaviour
{

    #region PublicFields
    public Color endColor;
    #endregion

    #region PrivateFields
    Material mat;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
 
    }

    #endregion

    #region PublicMethods

    public void tweenColour(float time)
    {
        DOTween.To(() => mat.GetColor("_Color"), x => mat.SetColor("_Color", x), endColor, time);
        mat.DOColor(endColor, time);
    }
    #endregion


    #region PrivateMethods

    #endregion
}
