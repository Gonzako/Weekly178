using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class constantTransformRotate : MonoBehaviour
{

    #region PublicFields
    public Vector3 rotationValue;
    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    void Update()
    {
        transform.rotation = getFrameRotation(rotationValue);
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods
    Quaternion getFrameRotation(Vector3 velocity)
    {
        var result = Quaternion.Euler(velocity * Time.deltaTime);
        result *= transform.rotation;
        return result;
    }
    #endregion
}
