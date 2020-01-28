using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InputEventListener : ListenerBase<ScriptableObject>
{
    [SerializeField] private InputEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<ScriptableObject> eventToReact
    {
        get { return _eventToReact; }
        set { _eventToReact = (InputEvent)value; }
    }
    public override UnityEvent<ScriptableObject> onReceiveEvent
    {
        get { return _onReceiveEvent; }
        set { _onReceiveEvent = (BindEvent)value; }
    }

    [Serializable]
    public class BindEvent : UnityEvent<ScriptableObject> { }

    public static InputEventListener AddComponentAtRunTime(GameObject _entity, InputEvent _eventToReact,
      UnityAction<ScriptableObject> _onInvoke)
    {
        InputEventListener newListener = _entity.AddComponent<InputEventListener>();
        newListener._eventToReact = _eventToReact;
        _eventToReact.Register(newListener);
        newListener._onReceiveEvent = new BindEvent();
        newListener.onReceiveEvent.AddListener(_onInvoke);
        return newListener;
    }
}
