using UnityEngine;
using UnityEngine.Events;

public class EventListenerController<EventType, ListenerType, DataType>
    where EventType : EventBase<DataType>
    where ListenerType : ListenerBase<DataType>
{
    private GameObject _go;
    private EventType _event;
    private UnityAction<DataType> _onInvoke;
    private UnityEvent<DataType> _bindEvent;

    public EventListenerController(IEventListener<EventType, DataType> view, 
        GameObject owner, UnityEvent<DataType> bindEvent)
    {
        _event = view.eventToListen;
        _onInvoke = view.OnReceiveEvent;
        _go = owner;
        _bindEvent = bindEvent;
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