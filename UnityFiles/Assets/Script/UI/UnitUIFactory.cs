using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(UnitUIManager))]
public class UnitUIFactory : MonoBehaviour, IUnitUIFactory
{
    [SerializeField] private UnitUI _prefabUnitUI = null;

    private UnitUIFactoryController _controller;
    private UnitUIManager _instanceManager;

    public UnitUIManager instanceManager
    {
        get
        {
            if (_instanceManager == null)
                _instanceManager = GetComponent<UnitUIManager>();
            return _instanceManager;
        }
    }

    public UnitUI prefabUnitUI => _prefabUnitUI;

    public Transform parentTransform => transform;


    private void Awake()
    {
        _controller = new UnitUIFactoryController(this);
    }

    public void OnSetupUI(UnitInfo unitInfo)
    {
        _controller.SpawnUnitUI(unitInfo);     
    }
}



