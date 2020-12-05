using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class RestartCurrentScene : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields



    #endregion

    #region UnityCallBacks
    private void OnEnable()
    {

    }

    #endregion

    #region PublicMethods

    public void restartCurrentScene(float delay) 
    {

        StartCoroutine(restartScene(delay));

    }

    #endregion


    #region PrivateMethods

    private IEnumerator restartScene(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex,
            UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    #endregion
}
