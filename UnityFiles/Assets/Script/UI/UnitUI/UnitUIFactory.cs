using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(UnitUIManager))]
public class UnitUIFactory : MonoBehaviour, IUnitUIFactory, IUnitEventListener
{
    [SerializeField] private UnitUI _prefabUnitUI = null;
    [SerializeField] private UnitEvent _onSetUpUI = null;

    private UnitUIFactoryController _controller;
    private UnitEventListenerController _eventController;
    private IUnitUIManager _instanceManager;

    //IUnitUIFactory
    public IUnitUIManager instanceManager {
        get
        {
            if (_instanceManager == null)
                _instanceManager = GetComponent<IUnitUIManager>();
            return _instanceManager;
        } }
    public IElementUI prefab => _prefabUnitUI;
    public Transform parentTransform => transform;
    
    //IUnitEventListener
    public UnitEvent eventToListen => _onSetUpUI;

    private void Awake()
    {
        _controller = new UnitUIFactoryController(this);
        _eventController = new UnitEventListenerController(this, gameObject);
        _eventController.AddListenerComponent();
    }

    public void OnReceiveEvent(IUnit data)
    {
        SpawnUnit(data);       
    }

    private void SpawnUnit(IUnit data)
    {
        UnitUI newUnitUI = Instantiate(_prefabUnitUI, transform);
        _controller.SetUpUnitUI(newUnitUI, data);
    }
}



