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


public class heroAI : MonoBehaviour
{

    #region PublicFields
    public ScriptableObjectArchitecture.FloatVariable waitTime;
    public Ease movementEase;

    public static event Action onCharacterMove;
    #endregion

    #region PrivateFields
    private const float dashTime = 0.5f;

    [SerializeField]
    Direction currentDir = Direction.Up;

    [SerializeField]
    Transform visuals = null;

    [SerializeField]
    EnviromentLookup table = null;
    [SerializeField]
    Grid gridHolder = null;
    [SerializeField]
    Tilemap obstaclesTilemap = null;
    [SerializeField]
    Tilemap backgroundTilemap = null;

    private Tile currentGround { get { return backgroundTilemap.GetTile(
                                                        backgroundTilemap.WorldToCell(transform.position)) as Tile; } }
    private Tile nextGround { get { return backgroundTilemap.GetTile
                                                     (
                                                     backgroundTilemap.WorldToCell(Vector3.Scale(transform.position, Vector3.one-Vector3.up)) 
                                                     + currentDir.toVector3Int()
                                                     ) as Tile; } }
    
    private Tile nextObstacle { get { return obstaclesTilemap.GetTile(
                                                 obstaclesTilemap.WorldToCell(
                                                    Vector3.Scale(transform.position, Vector3.one - Vector3.up)) + currentDir.toVector3Int()) as Tile; } }

    private Coroutine moveRoutine;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = backgroundTilemap.CellToWorld(Vector3Int.zero)+Vector3.one*0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        moveRoutine = StartCoroutine(moveCicle());
    }


    private void OnDisable()
    {
        StopCoroutine(moveRoutine);
    }
    #endregion

    #region PublicMethods



    #endregion


    #region PrivateMethods

    private IEnumerator moveCicle()
    {
        yield return new WaitForSeconds(waitTime.Value);
        //Collision check


        var groundTile = nextGround;
        var obstacleTile = nextObstacle;
        var wayBack = currentDir.getNext().getNext();
        for (int j = 0; j < 4; j++)
        {
            if(groundTile != null && !table._Unwalkables.Contains(groundTile))
            {
                if(obstacleTile == null /* || !table._Obstacles.Contains(obstacleTile)*/)
                {

                    yield return StartCoroutine(moveCharacter());
                    break;
                }
            }
            Debug.Log("cant walk " + currentDir.ToString() + " with tiles " + groundTile + obstacleTile);
            currentDir = currentDir.getNext() == wayBack ? wayBack.getNext() : currentDir.getNext();


            if (j == 2)
            {
                currentDir = wayBack;
                Debug.Log("AI trapped, dont move");
            }

            groundTile = nextGround;
            obstacleTile = nextObstacle;
        }

        //Decide movement
                    

        moveRoutine = StartCoroutine(moveCicle());
    }

    private IEnumerator moveCharacter()
    {
        if(currentDir == Direction.Left)
        {
            visuals.DOScaleX(-0.5f, dashTime*0.8f).SetEase(movementEase);
        }
        else if(currentDir == Direction.Right)
        {
            visuals.DOScaleX(0.5f, dashTime * 0.7f).SetEase(movementEase);
        }
        transform.localPosition += currentDir.toVector3();
        Tween t = visuals.DOMove(transform.position, dashTime).SetEase(movementEase);
        t.SetAutoKill(false);
        t.Play();
        yield return new WaitUntil(()=>t.IsComplete());
        t.Kill();
        visuals.position = transform.position;
    }

    #endregion
}


public enum Direction
{
    Down, Left, Up, Right
}

public static class DirectionExtentions
{

    public static Vector3Int toVector3Int(this Direction n)
    {
        
        switch (n)
        {
            case Direction.Up:
                return new Vector3Int(0,1,0);
            case Direction.Down:
                return new Vector3Int(0,-1,0);
            case Direction.Left:
                return new Vector3Int(-1, 0, 0);
            case Direction.Right:
                return new Vector3Int(1, 0, 0);

        }
        Debug.LogError("Enum Switch Not Working");
        return Vector3Int.one;
    }
    
    public static Vector3Int toVector3(this Direction n)
    {
        
        switch (n)
        {
            case Direction.Up:
                return new Vector3Int(0, 0, 1);
            case Direction.Down:
                return new Vector3Int(0, 0, -1);
            case Direction.Left:
                return new Vector3Int(-1, 0, 0);
            case Direction.Right:
                return new Vector3Int(1, 0, 0);

        }
        Debug.LogError("Enum Switch Not Working");
        return Vector3Int.one;
    }

    public static Direction getNext(this Direction n)
    {
        switch (n)
        {
            case Direction.Down:
                return Direction.Right;
            case Direction.Left:
                return Direction.Down;
            case Direction.Up:
                return Direction.Left;
            case Direction.Right:
                return Direction.Up;
        }
        return Direction.Up;
    }
}