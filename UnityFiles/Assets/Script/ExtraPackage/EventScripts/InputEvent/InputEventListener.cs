using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InputEventListener : ListenerBase<ScriptableObject>
{
    [SerializeField] private InputEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<ScriptableObject> eventToReact => _eventToReact;
    public override UnityEvent<ScriptableObject> onReceiveEvent => _onReceiveEvent;

    [Serializable]
    public class BindEvent : UnityEvent<ScriptableObject> { }
}
