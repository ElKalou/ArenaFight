using UnityEngine;

public class EventSenderController<EventType, DataType> 
    where EventType : EventBase 
    where DataType : ScriptableObject
{
    private EventType _eventToSend;
    private DataType _dataToBind;

    public EventSenderController(IEventSender<EventType, DataType> _eventSender)
    {
        _eventToSend = _eventSender.eventToSend;
        _dataToBind = _eventSender.boundData;
    }

    public void RaiseEvent()
    {
        _eventToSend.dataToSend = _dataToBind;
        _eventToSend.Raise();
    }
}