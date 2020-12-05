using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class EnableUnityEvents : MonoBehaviour
{

    #region PublicFields

    public UnityEvent onEnable;
    public UnityEvent onDisable;

    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks
    
    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void OnDisable()
    {
        onDisable.Invoke();
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
