using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IEventSender<UnitEvent, UnitInfo>
{
    [SerializeField] private UnitInfo _unitInfoTemplate = null;
    [SerializeField] private UnitEvent _eventSetupUI = null;

    public int unitID { get; private set; }
    public UnitEvent eventToSend => _eventSetupUI;
    public UnitInfo UnitInfoTemplate => _unitInfoTemplate;
    public UnitInfo boundData { get; private set; }

    private EventController<UnitEvent, UnitInfo> _eventController;

    private void Awake()
    {
        _eventController = new EventController<UnitEvent, UnitInfo>(this);
    }

    public void Init()
    {
        if(_eventController == null)
            _eventController = new EventController<UnitEvent, UnitInfo>(this);

        boundData = Instantiate(_unitInfoTemplate);
        boundData.Init(this);
        _eventController.RaiseEvent(this);
    }

    internal void SetID(int ID)
    {
        unitID = ID;
    }
}
