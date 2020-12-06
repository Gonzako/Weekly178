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


public class ObstacleDragger : MonoBehaviour
{

    #region PublicFields
    public static event Action<Tile> onPickupTile;
    public static event Action<Tile, Vector3> onDropTile;

    #endregion

    #region PrivateFields

    [SerializeField]
    Tilemap tileMapObstacle;
    Camera currentCam;
    Plane obstaclePlane;
    Tile removedTile;
    bool dragging = false;
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
            removedTile = cell;

            if (cell != null)
                onPickupTile?.Invoke(cell);

            tileMapObstacle.SetTile(cellPos, null);

            dragging = true;
            
        }
        if(Input.GetMouseButtonUp(0) && dragging)
        {
            var camRay = currentCam.ScreenPointToRay(Input.mousePosition);

            obstaclePlane.Raycast(camRay, out float rayDist);

            var point = camRay.origin + camRay.direction * rayDist;

            var cellPos = tileMapObstacle.WorldToCell(point);

            tileMapObstacle.SetTile(cellPos, removedTile);

            onDropTile?.Invoke(removedTile, point);

            dragging = false;

            removedTile = null;

        }
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
