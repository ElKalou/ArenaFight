using UnityEngine;

public interface IEventListener<EventType, DataType>
    where EventType : EventBase<DataType>
{
    EventType eventToListen { get; }
    void OnReceiveEvent(DataType data);
}

public interface IInputEventListener : IEventListener<InputEvent, ScriptableObject> { }

public interface IUnitEventListener : IEventListener<UnitEvent, IUnit> { }

public interface ICompetenceEventListener : IEventListener<CompetenceEvent, Competence> { }

public interface IGameEventListener : IEventListener<GameEvent, ScriptableObject> { }