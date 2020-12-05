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


public class StartUnityAction : MonoBehaviour
{

    #region PublicFields

    public UnityEvent onStart;

    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
