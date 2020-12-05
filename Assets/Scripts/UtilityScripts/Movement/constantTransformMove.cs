using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class constantTransformMove : MonoBehaviour
{

    #region PublicFields
    public Vector3 velocityValue;
    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    void Update()
    {
        transform.position += velocityValue * Time.deltaTime;
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
