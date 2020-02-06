using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : ListenerBase<ScriptableObject>
{
    [SerializeField] private GameEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<ScriptableObject> eventToReact
    {
        get { return _eventToReact; }
        set { _eventToReact = (GameEvent)value; }
    }
    public override UnityEvent<ScriptableObject> onReceiveEvent
    {
        get { return _onReceiveEvent; }
        set { _onReceiveEvent = (BindEvent)value; }
    }

    [Serializable]
    public class BindEvent : UnityEvent<ScriptableObject> { }
}








