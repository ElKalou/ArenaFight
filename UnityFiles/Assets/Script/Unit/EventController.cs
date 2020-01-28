using UnityEngine;

public class EventController<EventType, DataType> 
    where EventType : EventBase<DataType>
    where DataType : ScriptableObject
{
    private EventType _eventToSend;
    private DataType _dataToBind;

    public EventController(IEventSender<EventType, DataType> view)
    {
        _eventToSend = view.eventToSend;
        _dataToBind = view.boundData;
    }

    public void RaiseEvent(IEventSender<EventType, DataType> view)
    {
        _eventToSend.dataToSend = view.boundData;
        _eventToSend.Raise();
    }
}