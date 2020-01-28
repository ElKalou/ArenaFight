using UnityEngine;

public interface IEventEmitter<EventType, DataType> 
    where EventType : EventBase<DataType>
    where DataType : ScriptableObject
{
    EventType eventToSend { get; }
    DataType boundData { get; }
}

