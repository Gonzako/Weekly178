using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

[System.Serializable]
public class ScriptableSceneEventListener : BaseGameEventListener<ScriptableScene, ScriptableSceneEvent, ScriptableSceneUnityEvent>
{
   
}

[System.Serializable]
public class ScriptableSceneUnityEvent : UnityEvent<ScriptableScene> { }