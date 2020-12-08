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
    public ScriptableObjectArchitecture.FloatVariable DashTime;
    public Ease movementEase;
    public EnviromentLookup Table { get { return table; } }

    public static Vector3Int currentCell;
    public static event Action<Tile> onCharacterMove;
    #endregion

    #region PrivateFields
    private float dashTime { get { return DashTime.Value; } }

    [SerializeField]
    Direction currentDir = Direction.Up;

    [SerializeField]
    float jumpPower = 2f;

    [SerializeField]
    Transform visuals = null;

    [SerializeField]
    EnviromentLookup table = null;

    [SerializeField]
    Tilemap obstaclesTilemap = null;
    [SerializeField]
    Tilemap backgroundTilemap = null;

    [SerializeField]
    Animator animator;

    public Tile currentGround { get { return backgroundTilemap.GetTile(
                                                        backgroundTilemap.WorldToCell(transform.position)) as Tile; } }
    public Tile nextGround { get { return backgroundTilemap.GetTile
                                                     (
                                                     backgroundTilemap.WorldToCell(Vector3.Scale(transform.position, Vector3.one - Vector3.up)) 
                                                     + currentDir.toVector3Int()
                                                     ) as Tile; } }
    
    public Tile nextObstacle { get { 
                
                return obstaclesTilemap.GetTile(
                                                 obstaclesTilemap.WorldToCell(
                                                    Vector3.Scale(transform.position, Vector3.one - Vector3.up)) + currentDir.toVector3Int()) as Tile;       
        } }


    public Vector3Int nextCell { get
        {
            return backgroundTilemap.WorldToCell(Vector3.Scale(transform.position, Vector3.one - Vector3.up))
            + currentDir.toVector3Int();
        } }

    private Coroutine moveRoutine;
    #endregion

    #region UnityCallBacks

    // Start is called before the first frame update
    void Start()
    {
        currentCell = backgroundTilemap.WorldToCell(transform.position);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        animator.SetFloat("RandomValue", UnityEngine.Random.value);
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

    public static bool isNearPlayer(Vector3Int desired)
    {
        return desired.x == heroAI.currentCell.x && desired.y == heroAI.currentCell.y;
    }

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
                if(obstacleTile == null  /*||  !table._Obstacles.Contains(obstacleTile)*/)
                {
                    onCharacterMove?.Invoke(nextGround);
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
        animator.SetBool("Walking", true);
        if(currentDir == Direction.Left)
        {
            visuals.DOScaleX(-Mathf.Abs(visuals.localScale.x), dashTime*0.8f).SetEase(movementEase);
        }
        else if(currentDir == Direction.Right)
        {
            visuals.DOScaleX(Mathf.Abs(visuals.localScale.x), dashTime * 0.7f).SetEase(movementEase);
        }



        transform.localPosition += currentDir.toVector3();

        currentCell = backgroundTilemap.WorldToCell(transform.position);

        currentCell.z = 0;
        Tween t = visuals.DOJump(transform.position, jumpPower,1,dashTime).SetEase(movementEase);
        t.SetAutoKill(false);
        t.Play();

        yield return new WaitUntil(()=>t.IsComplete());
        t.Kill();
        animator.SetBool("Walking", true);
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