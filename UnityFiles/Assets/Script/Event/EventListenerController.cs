using UnityEngine;
using UnityEngine.Events;

public abstract class EventListenerController<EventType, ListenerType, DataType>
    where EventType : EventBase<DataType>
    where ListenerType : ListenerBase<DataType>
{
    public GameObject _go { get; protected set; }
    public EventType _event { get; protected set; }
    public UnityAction<DataType> _onInvoke { get; protected set; }
    public UnityEvent<DataType> _bindEvent { get; protected set; }

    public EventListenerController(IEventListener<EventType, DataType> view, GameObject owner)
    {
        _event = view.eventToListen;
        _onInvoke = view.OnReceiveEvent;
        _go = owner;
    }

    public ListenerType AddListenerComponent()
    {
        ListenerType newListener = _go.AddComponent<ListenerType>();
        newListener.eventToReact = _event;
        _event.Register(newListener);
        newListener.onReceiveEvent = _bindEvent;
        newListener.onReceiveEvent.AddListener(_onInvoke);
        return newListener;
    }
}

public class InputEventListenerController : EventListenerController<InputEvent, InputEventListener, ScriptableObject>
{
    public InputEventListenerController(IInputEventListener view, GameObject owner) : base(view, owner)
    {
        _bindEvent = new InputEventListener.BindEvent();
    }
}

public class UnitEventListenerController : EventListenerController<UnitEvent, UnitEventListener, IUnit>
{
    public UnitEventListenerController(IUnitEventListener view, GameObject owner) : base(view, owner)
    {
        _bindEvent = new UnitEventListener.BindEvent();
    }
}

public class CompetenceEventListenerController : EventListenerController<CompetenceEvent, CompetenceEventListener, Competence>
{
    public CompetenceEventListenerController(ICompetenceEventListener view, GameObject owner) : base(view, owner)
    {
        _bindEvent = new CompetenceEventListener.BindEvent();
    }
}