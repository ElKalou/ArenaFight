using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitEventListener : ListenerBase<UnitEvent>
{
    public attachedUnityEvent onReceiveEvent;

    public override void OnReceiveEvent(UnitEvent receivedEvent)
    {
        onReceiveEvent.Invoke(receivedEvent.dataToSend);
    }

    protected override void OnDisable()
    {
        eventToReact.DeRegister(this);
    }

    protected override void OnEnable()
    {
        if (eventToReact == null)
            return;

        eventToReact.Register(this);
    }

    public static void AddComponentAtRunTime(GameObject _entity, UnitEvent _eventToReact,
       UnityAction<UnitInfo> _onInvoke)
    {
        UnitEventListener newListener = _entity.AddComponent<UnitEventListener>();
        newListener.eventToReact = _eventToReact;
        _eventToReact.Register(newListener);
        newListener.onReceiveEvent = new attachedUnityEvent();
        newListener.onReceiveEvent.AddListener(_onInvoke);
    }

    public static UnitEvent AddComponentAtTestTime(GameObject _entity, UnityAction<UnitInfo> _onInvoke)
    {
        UnitEventListener newListener = _entity.AddComponent<UnitEventListener>();
        UnitEvent eventToReact = ScriptableObject.CreateInstance<UnitEvent>();
        newListener.eventToReact = eventToReact;
        eventToReact.Register(newListener);
        newListener.onReceiveEvent = new attachedUnityEvent();
        newListener.onReceiveEvent.AddListener(_onInvoke);

        return eventToReact;
    }

    [System.Serializable]
    public class attachedUnityEvent : UnityEvent<UnitInfo> { }

}
