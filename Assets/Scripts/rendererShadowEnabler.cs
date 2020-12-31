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


public class rendererShadowEnabler : MonoBehaviour
{

    #region PublicFields
    #endregion

    #region PrivateFields
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Awake()
    {
        var rend = GetComponent<Renderer>();
        rend.receiveShadows = true;
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
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

    #endregion


    #region PrivateMethods

    #endregion
}
