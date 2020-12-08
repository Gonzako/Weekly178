using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class WinSpot : MonoBehaviour
{

    #region PublicFields
    #endregion

    #region PrivateFields
    [SerializeField]
    UnityEngine.Tilemaps.Tilemap ground;
    [SerializeField]
    ScriptableObjectArchitecture.GameEvent onPlayerWin;
    Vector3Int currentTile;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        currentTile = ground.WorldToCell(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        heroAI.onCharacterMove += HeroAI_onCharacterMove;
    }


    private void OnDisable()
    {
        heroAI.onCharacterMove -= HeroAI_onCharacterMove;
    }
    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods
    private void HeroAI_onCharacterMove(UnityEngine.Tilemaps.Tile obj)
    {
        if (heroAI.isNearPlayer(currentTile))
        {
            onPlayerWin?.Raise();
            Debug.Log("PLAYER WON");
        }
    }

    #endregion
}
