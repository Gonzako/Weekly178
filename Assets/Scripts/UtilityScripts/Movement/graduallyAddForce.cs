using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class graduallyAddForce : MonoBehaviour
{

    #region PublicFields

    public Vector2 forceToAdd;

    #endregion

    #region PrivateFields

    Rigidbody2D rb;

    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
    
    }

    private void FixedUpdate()
    {
        rb.AddForce(forceToAdd / Time.fixedDeltaTime);
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
