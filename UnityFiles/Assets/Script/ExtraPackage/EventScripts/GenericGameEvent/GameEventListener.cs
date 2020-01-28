using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : ListenerBase<ScriptableObject>
{
    [SerializeField] private GameEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<ScriptableObject> eventToReact => _eventToReact;
    public override UnityEvent<ScriptableObject> onReceiveEvent => _onReceiveEvent;

    [Serializable]
    public class BindEvent : UnityEvent<ScriptableObject> { }
}








