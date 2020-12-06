using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>

[ExecuteInEditMode]
public class customSpriteRenderer : MonoBehaviour
{

    #region PublicFields
    public Sprite targetSprite;
    #endregion

    #region PrivateFields
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
 
    }

    private void OnValidate()
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.sharedMaterial.SetTexture("_MainTex", targetSprite.texture);
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
