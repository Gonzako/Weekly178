using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class rotateTowardsMouse : MonoBehaviour
{

    #region PublicFields

    public float angleOffset = 0;

    #endregion

    #region PrivateFields

    private Camera cam;

    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var mouseDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg + angleOffset;
        var endRot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = endRot;
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
