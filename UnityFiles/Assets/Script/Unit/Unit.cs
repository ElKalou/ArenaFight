using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitInfo _unitInfoTemplate = null;
    [SerializeField] private UnitEvent _eventSetupUI = null;

    public int unitID { get; private set; }

    public UnitEvent eventSetupUI => _eventSetupUI;

    public UnitInfo UnitInfoTemplate => _unitInfoTemplate;

    public UnitInfo unitInfo { get; private set; }

    public void Init()
    {
        unitInfo = Instantiate(_unitInfoTemplate);
        unitInfo.Init(this);
        SendEvent(_eventSetupUI);
    }

    private void SendEvent(UnitEvent eventToSend)
    {
        eventToSend.dataToSend = unitInfo;
        eventToSend.Raise();
    }

    internal void SetID(int ID)
    {
        unitID = ID;
    }
}
