using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>



public class triggerEvents2D : MonoBehaviour
{

    #region PublicFields
    public onTriggerEvents2D onTriggerEnter;
    public onTriggerEvents2D onTriggerExit;

    [System.Serializable]
    public class onTriggerEvents2D : UnityEngine.Events.UnityEvent<Collider2D> { }
    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks


    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke(other);
    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
