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


public class DragPreview : MonoBehaviour
{

    #region PublicFields


    #endregion

    #region PrivateFields

    [SerializeField]
    Tilemap targetPreview;
    bool dragging = false;
    [SerializeField]
    SpriteRenderer previewer;
    Camera currentCam;
    Plane obstaclePlane;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        currentCam = GetComponent<Camera>();

        obstaclePlane = new Plane(Vector3.up, targetPreview.transform.position);
        previewer.sharedMaterial.SetFloat("_Preview", 1);
    }

    // Update is called once per frame
    void Update()
    {

        var camRay = currentCam.ScreenPointToRay(Input.mousePosition);
        obstaclePlane.Raycast(camRay, out float rayDist);
        
        var point = camRay.origin + camRay.direction * rayDist;
        
        var cellPos = targetPreview.WorldToCell(point);
        
        var tile = targetPreview.GetTile(cellPos) as Tile;
        
        previewer.transform.localPosition = (targetPreview.CellToLocal(cellPos) + targetPreview.tileAnchor) + targetPreview.orientationMatrix.MultiplyPoint(Vector3.zero)*1.1f;
        
        if (!dragging)
        {
            if (tile != null)
                previewer.sprite = tile.sprite;
            else
                previewer.sprite = null; 
        }
    }

    void OnEnable()
    {
        ObstacleDragger.onDropTile += ObstacleDragger_onDropTile;
        ObstacleDragger.onPickupTile += ObstacleDragger_onPickupTile;
    }



    private void OnDisable()
    {

        ObstacleDragger.onDropTile   -= ObstacleDragger_onDropTile;
        ObstacleDragger.onPickupTile -= ObstacleDragger_onPickupTile;
    }

    #endregion

     #region PublicMethods

    #endregion


    #region PrivateMethods

    private void ObstacleDragger_onPickupTile(Tile obj)
    {
        dragging = true;
        previewer.sprite = obj.sprite;
        previewer.sharedMaterial.SetInt("Preview", 0);
        previewer.receiveShadows = true;
        previewer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
    }

    private void ObstacleDragger_onDropTile(Tile arg1, Vector3 arg2)
    {
        dragging = false;

        previewer.receiveShadows = false;
        previewer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        previewer.sharedMaterial.SetFloat("Preview", 1);


    }
    #endregion
}
