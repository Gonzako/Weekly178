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



public class triggerEvents3D : MonoBehaviour
{

    #region PublicFields
    public TriggerEvent onTriggerEnter = new TriggerEvent();
    public TriggerEvent onTriggerExit = new TriggerEvent();

    [System.Serializable]
    public class TriggerEvent : UnityEvent<Collider> { }
    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks


    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
