using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class dontDestroyOnLoad : MonoBehaviour
{

    #region PublicFields

    public bool playOnStart = false;

    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        if (playOnStart)
            dontDestroyOnLoad.DontDestroyOnLoad(this.gameObject);
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
