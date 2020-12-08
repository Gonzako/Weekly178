using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class enviromentKiller : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields
    [SerializeField]
    heroAI info;

    [SerializeField]
    ScriptableObjectArchitecture.GameEvent onLevelFail;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        heroAI.onCharacterMove += HeroAI_onCharacterMove;
    }
    void OnDisable()
    {
        heroAI.onCharacterMove -= HeroAI_onCharacterMove;
    }


    #endregion

    #region PublicMethods

    private void HeroAI_onCharacterMove(Tile input)
    {
        if (info.Table._Traps.Contains(input))
        {
            Debug.Log("PlayerDED");

            onLevelFail.Raise();
        }
    }
    #endregion


    #region PrivateMethods

    #endregion
}
