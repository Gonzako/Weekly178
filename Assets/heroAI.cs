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

    public static event Action onCharacterMove;
    #endregion

    #region PrivateFields
    private const float dashTime = 0.2f;

    [SerializeField]
    Direction currentDir = Direction.Forward;

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

    private Tile currentGround { get { return backgroundTilemap.GetTile(backgroundTilemap.WorldToCell(transform.position)) as Tile; } }
    private Tile nextGround { get { return backgroundTilemap.GetTile(backgroundTilemap.WorldToCell(transform.position + Vector3.Project(gridHolder.cellSize, currentDir.toVector3()))) as Tile; } }
    
    private Tile nextObstacle { get { return backgroundTilemap.GetTile(obstaclesTilemap.WorldToCell(transform.position + Vector3.Project(gridHolder.cellSize, currentDir.toVector3()))) as Tile; } }

    private Coroutine moveRoutine;
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
        Debug.Log("started a move cicle");
        yield return new WaitForSeconds(waitTime.Value);
        //Collision check


        var tile = nextGround;
        var obstacle = nextObstacle;
        int i = 0;
        while (i < 4 && 
            ((tile == null && table._Unwalkables.Contains(tile)) ||
             (obstacle == null || !table._Obstacles.Contains(obstacle))))
        {
            currentDir = (Direction)(((int)currentDir+1) % 4);
            tile = nextGround;
            obstacle = nextObstacle;
            i++;
        }


        if(i > 4)
        {
            Debug.Log("AI trapped, dont move");
        }
        else
        {
            onCharacterMove?.Invoke();
            yield return StartCoroutine(moveCharacter());
            Debug.Log("this passed");
        }
        //Decide movement
                    

        moveRoutine = StartCoroutine(moveCicle());
        Debug.Log("tried to start a new move cycle");
    }

    private IEnumerator moveCharacter()
    {
        transform.position += currentDir.toVector3();
        Tween t = visuals.DOMove(transform.position, dashTime).SetEase(Ease.InOutQuint);
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
    Forward, Right, Backwards, Left
}

public static class DirectionExtentions
{

    public static Vector3 toVector3(this Direction n)
    {
        
        switch (n)
        {
            case Direction.Forward:
                return Vector3.forward;
            case Direction.Backwards:
                return Vector3.back;
            case Direction.Left:
                return Vector3.left;
            case Direction.Right:
                return Vector3.right;

        }
        Debug.LogError("Enum Switch Not Working");
        return Vector3.forward;
    }
}