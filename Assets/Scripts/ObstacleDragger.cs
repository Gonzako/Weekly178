﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using ScriptableObjectArchitecture;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class ObstacleDragger : MonoBehaviour
{

    #region PublicFields
    public static event Action<Tile> onPickupTile;
    public static event Action<Tile, Vector3> onDropTile;
    [SerializeField] private GameEvent onPickup;
    [SerializeField] private GameEvent onDrop;


    #endregion

    #region PrivateFields
    [SerializeField]
    EnviromentLookup table;

    [SerializeField]
    Tilemap tileMapObstacle;
    [SerializeField]
    Tilemap ground;
    Camera currentCam;
    Plane obstaclePlane;
    Tile removedTile;
    bool dragging = false;
    Vector3Int previousCellPos;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        obstaclePlane = new Plane(Vector3.up, tileMapObstacle.transform.position);
        currentCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dragging)
        {
            //Check tilemap for tile, destroy if yes then throw event with sprite for UI later on
            //if yes check dragging to true
            var camRay = currentCam.ScreenPointToRay(Input.mousePosition);
            obstaclePlane.Raycast(camRay, out float rayDist);

            var point = camRay.origin + camRay.direction*rayDist;

            var cellPos = tileMapObstacle.WorldToCell(point);

            var cell = tileMapObstacle.GetTile(cellPos) as Tile;
            previousCellPos = cellPos;
            removedTile = cell;

            if (cell != null && table._Movables.Contains(cell))
            {

                onPickupTile?.Invoke(cell);
                onPickup.Raise();

                tileMapObstacle.SetTile(cellPos, null);

                dragging = true;
            }
            
        }
        if(Input.GetMouseButtonUp(0) && dragging)
        {
            var camRay = currentCam.ScreenPointToRay(Input.mousePosition);

            obstaclePlane.Raycast(camRay, out float rayDist);

            var point = camRay.origin + camRay.direction * rayDist;

            var cellPos = tileMapObstacle.WorldToCell(point);

            if (isLegalTile(cellPos))
            {

                tileMapObstacle.SetTile(cellPos, removedTile);

                onDropTile?.Invoke(removedTile, point);
                onDrop.Raise();
            }
            else
            {
                tileMapObstacle.SetTile(previousCellPos, removedTile);

                onDropTile?.Invoke(removedTile, tileMapObstacle.CellToWorld(previousCellPos));
                onDrop.Raise();

            }



            removedTile = null;
            dragging = false;

        }
    }

    public bool isLegalTile(Vector3Int cellPos)
    {

        var obstcl = tileMapObstacle.GetTile(cellPos) as Tile;
        var groundTile = ground.GetTile(cellPos) as Tile;

        return !isNearPlayer(cellPos) && obstcl == null
                                      && ground.GetTile(cellPos) != null
                                      && !table._Unwalkables.Contains(groundTile)
                                      && !table._Traps.Contains(groundTile);
    }

    void OnEnable()
    {
 
    }

    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods
    private bool isNearPlayer(Vector3Int desired)
    {
        return desired.x == heroAI.currentCell.x && desired.y == heroAI.currentCell.y;
    }
    #endregion
}
