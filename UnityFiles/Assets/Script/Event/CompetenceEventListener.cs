using System;
using UnityEngine;
using UnityEngine.Events;

public class CompetenceEventListener : ListenerBase<Competence>
{
    [SerializeField] private CompetenceEvent _eventToReact = null;
    [SerializeField] private BindEvent _onReceiveEvent = null;

    public override EventBase<Competence> eventToReact => _eventToReact;
    public override UnityEvent<Competence> onReceiveEvent => _onReceiveEvent;

    [Serializable]
    public class BindEvent : UnityEvent<Competence> { }
}
