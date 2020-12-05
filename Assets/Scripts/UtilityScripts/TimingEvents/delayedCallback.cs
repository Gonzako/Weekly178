using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class delayedCallback : MonoBehaviour
{

    #region PublicFields

    public string Intent;
    public UnityEngine.Events.UnityEvent onWaitFinished;

    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    private void OnEnable()
    {
        
    }

    #endregion

    #region PublicMethods

    public void delayedCall(float time)
    {
        StartCoroutine(waitedCall(time));
    }

    #endregion


    #region PrivateMethods

    IEnumerator waitedCall(float time)
    {
        yield return new WaitForSeconds(time);
        onWaitFinished.Invoke();
    }

    #endregion
}
