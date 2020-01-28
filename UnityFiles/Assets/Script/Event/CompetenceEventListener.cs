using System;
using UnityEngine;
using UnityEngine.Events;

public class CompetenceEventListener : ListenerBase<Competence>
{
    [SerializeField] private CompetenceEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<Competence> eventToReact
    {
        get { return _eventToReact; }
        set { _eventToReact = (CompetenceEvent)value; }
    }
    public override UnityEvent<Competence> onReceiveEvent
    {
        get { return _onReceiveEvent; }
        set { _onReceiveEvent = (BindEvent)value; }
    }

    [Serializable]
    public class BindEvent : UnityEvent<Competence> { }
}
