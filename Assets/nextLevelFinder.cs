using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevelFind()
    {
        
       GameSceneLoader.instance.LoadNextLevel();
    }
}
