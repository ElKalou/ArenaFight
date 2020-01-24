using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompetenceEventListener : ListenerBase<CompetenceEvent>
{
    public attachedUnityEvent onReceiveEvent;

    public override void OnReceiveEvent(CompetenceEvent receivedEvent)
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

    public static void AddComponentAtRunTime(GameObject _entity, CompetenceEvent _eventToReact,
       UnityAction<Competence> _onInvoke)
    {
        CompetenceEventListener newListener = _entity.AddComponent<CompetenceEventListener>();
        newListener.eventToReact = _eventToReact;
        _eventToReact.Register(newListener);
        newListener.onReceiveEvent = new attachedUnityEvent();
        newListener.onReceiveEvent.AddListener(_onInvoke);
    }

    [System.Serializable]
    public class attachedUnityEvent : UnityEvent<Competence> { }
}
