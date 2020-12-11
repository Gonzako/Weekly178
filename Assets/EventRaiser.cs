using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    [SerializeField]
    public ScriptableObjectArchitecture.GameEvent targetRaise;


    public void Raise() => targetRaise.Raise();

}
