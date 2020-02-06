using UnityEngine;

public interface IEventEmitter<EventType, DataType> 
    where EventType : EventBase<DataType>
{
    EventType eventToSend { get; }
    DataType dataToSend { get; }
}

public interface IInputEventEmitter : IEventEmitter<InputEvent, ScriptableObject> { }

public interface IUnitEventEmitter : IEventEmitter<UnitEvent, IUnit> { }

public interface ICompetenceEventEmitter : IEventEmitter<CompetenceEvent, Competence> { }

public interface IGameEventEmitter : IEventEmitter<GameEvent, ScriptableObject> { }


