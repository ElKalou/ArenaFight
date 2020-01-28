using UnityEngine;

public interface IEventListener<EventType, DataType>
    where EventType : EventBase<DataType>
{
    EventType eventToListen { get; }

    void OnReceiveEvent(DataType data);
}