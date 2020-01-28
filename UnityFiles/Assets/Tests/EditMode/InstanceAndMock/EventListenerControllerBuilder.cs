using UnityEngine;
using UnityEngine.Events;

public class EventListenerControllerBuilder<EventType, ListenerType, DataType>
    where EventType : EventBase<DataType>
    where ListenerType : ListenerBase<DataType>
{
    private IEventListener<EventType, DataType> _mockListener;
    private GameObject _go;
    private UnityEvent<DataType> _bindEvent;

    public EventListenerControllerBuilder(IEventListener<EventType, DataType> mockListener)
    {
        _mockListener = mockListener;
    }

    public EventListenerControllerBuilder<EventType, ListenerType, DataType> With(GameObject go)
    {
        _go = go;
        return this;
    }

    public EventListenerControllerBuilder<EventType, ListenerType, DataType> With(UnityEvent<DataType> bindEvent)
    {
        _bindEvent = bindEvent;
        return this;
    }

    public EventListenerController<EventType, ListenerType, DataType> Build()
    {
        return new EventListenerController<EventType, ListenerType, DataType>(_mockListener, _go, _bindEvent);
    }

    public static implicit operator EventListenerController<EventType, ListenerType, DataType>
        (EventListenerControllerBuilder<EventType, ListenerType, DataType> builder) => builder.Build();
}