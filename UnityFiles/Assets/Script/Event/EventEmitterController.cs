using UnityEngine;

public abstract class EventEmitterController<EventType, DataType> 
    where EventType : EventBase<DataType>
{
    private IEventEmitter<EventType, DataType>_view;

    public EventEmitterController(IEventEmitter<EventType, DataType> view)
    {
        _view = view;
    }

    public void RaiseEvent()
    {
        _view.eventToSend.dataToSend = _view.dataToSend;
        _view.eventToSend.Raise();
    }
}

public class InputEventEmitterController : EventEmitterController<InputEvent, ScriptableObject>
{
    public InputEventEmitterController(IInputEventEmitter view) : base(view)
    {
    }
}

public class UnitEventEmitterController : EventEmitterController<UnitEvent, IUnit>
{
    public UnitEventEmitterController(IUnitEventEmitter view) : base(view)
    {
    }
}

public class CompetenceEventEmitterController : EventEmitterController<CompetenceEvent, Competence>
{
    public CompetenceEventEmitterController(ICompetenceEventEmitter view) : base(view)
    {
    }
}

