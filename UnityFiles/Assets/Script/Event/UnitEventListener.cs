using System;
using UnityEngine;
using UnityEngine.Events;

public class UnitEventListener : ListenerBase<UnitInfo>
{
    [SerializeField] private UnitEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<UnitInfo> eventToReact  => _eventToReact; 
    public override UnityEvent<UnitInfo> onReceiveEvent => _onReceiveEvent; 

    [Serializable]
    public class BindEvent : UnityEventBase<UnitInfo> { }

    public static void AddComponentAtRunTime(GameObject _entity, UnitEvent _eventToReact,
       UnityAction<UnitInfo> _onInvoke)
    {
        UnitEventListener newListener = _entity.AddComponent<UnitEventListener>();
        newListener._eventToReact = _eventToReact;
        _eventToReact.Register(newListener);
        newListener._onReceiveEvent = new BindEvent();
        newListener.onReceiveEvent.AddListener(_onInvoke);
    }

    public static void AddComponentAtTestTime(UnitEventListener _listener,
        UnitEvent _eventToReact, UnityAction<UnitInfo> _onInvoke)
    {
        _listener._eventToReact = _eventToReact;
        _eventToReact.Register(_listener);
        _listener._onReceiveEvent = new BindEvent();
        _listener.onReceiveEvent.AddListener(_onInvoke);
    }
}
