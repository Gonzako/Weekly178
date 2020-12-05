using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>

[CreateAssetMenu(menuName ="Enviroment/LookupTable")]
public class EnviromentLookup : ScriptableObject
{

    #region PublicFields
    
    public HashSet<Tile> _Obstacles;
    public HashSet<Tile> _Unwalkables;
    public HashSet<Tile> _Traps;
    public HashSet<Tile> _Movables;
    #endregion

    #region PrivateFields

    [SerializeField]
    private List<Tile> PickableObstacles;

    [SerializeField]
    private List<Tile> Unwalkable;

    [SerializeField]
    private List<Tile> Traps;

    [SerializeField]
    private List<Tile> Movables;
    #endregion

    #region UnityCallBacks
    private void OnEnable()
    {
        _Unwalkables = new HashSet<Tile>(Unwalkable.ToArray());
        _Obstacles = new HashSet<Tile>(PickableObstacles);
        _Traps = new HashSet<Tile>(Traps);
        _Movables = new HashSet<Tile>(Movables);
    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    #endregion
}
