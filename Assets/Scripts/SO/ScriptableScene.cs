using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="Level", menuName = "Levels/New Level")]
public class ScriptableScene : ScriptableObject
{
    public Sprite preview;
    public Scene scene;
    public string scene_id = Guid.NewGuid().ToString();
}
