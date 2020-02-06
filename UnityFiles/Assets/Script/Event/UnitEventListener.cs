using System;
using UnityEngine;
using UnityEngine.Events;

public class UnitEventListener : ListenerBase<IUnit>
{
    [SerializeField] private UnitEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<IUnit> eventToReact {
        get { return _eventToReact; }
        set { _eventToReact = (UnitEvent)value; }
    }
    public override UnityEvent<IUnit> onReceiveEvent
    {
        get { return _onReceiveEvent; }
        set { _onReceiveEvent = (BindEvent)value; }
    }

    [Serializable]
    public class BindEvent : UnityEvent<IUnit> { }
}
