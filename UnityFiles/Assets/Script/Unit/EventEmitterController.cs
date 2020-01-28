using UnityEngine;

public class EventEmitterController<EventType, DataType> 
    where EventType : EventBase<DataType>
    where DataType : ScriptableObject
{
    private EventType _eventToSend;
    private DataType _dataToBind;

    public EventEmitterController(IEventEmitter<EventType, DataType> view)
    {
        _eventToSend = view.eventToSend;
        _dataToBind = view.boundData;
    }

    public void RaiseEvent(IEventEmitter<EventType, DataType> view)
    {
        _eventToSend.dataToSend = view.boundData;
        _eventToSend.Raise();
    }
}