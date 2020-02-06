using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(UnitManager))]
public class UnitFactory : MonoBehaviour, IUnitFactory
{
    [SerializeField] private List<Unit> _unitPrefabs = null;

    //IUnitFactory
    public IUnitManager instanceManager { get
        {
            if (_instanceManager == null)
                _instanceManager = GetComponent<IUnitManager>();
            return _instanceManager;
        }
    }
    public List<IUnit> prefabs
    {
        get
        {
            if(_iUnitPrefabs == null && _unitPrefabs != null)
            {
                _iUnitPrefabs = new List<IUnit>();
                foreach (Unit u in _unitPrefabs)
                    _iUnitPrefabs.Add(u);
            }
            return _iUnitPrefabs;
        }
    }
    public Transform parentTransform => transform;

    private List<IUnit> _iUnitPrefabs = null;
    private IUnitManager _instanceManager;

    private UnitFactoryController _factoryController;

    private void Awake()
    {
        _factoryController = new UnitFactoryController(this);
        _factoryController.MakeDictionnary();
    }

    public Unit SpawnUnit(UnitTemplate unitInfoTemplate, Transform spawnPosition)
    {
        int prefabIdx = _factoryController.GetIndex(unitInfoTemplate);

        Unit newUnit = Instantiate(
            _unitPrefabs[prefabIdx], 
            spawnPosition.position, 
            spawnPosition.rotation, 
            transform);
        _factoryController.PassUnitToManager(newUnit);
        return newUnit;
    }
    
}
