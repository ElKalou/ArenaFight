
using UnityEngine;

public interface IEventSender<EventType, DataType> where EventType : EventBase where DataType : ScriptableObject
{
    EventType eventToSend { get; }

    DataType boundData { get; }
}

