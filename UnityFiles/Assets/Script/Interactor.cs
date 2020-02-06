using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour, IUnitEventEmitter, IInputEventListener
{
    [Header("Event to Send")]
    [SerializeField] private UnitEvent _selectionRequest = null;
    [Header("Event to Receive")]
    [SerializeField] private InputEvent _leftClick = null;

    private InteractorController _interactorController;
    private UnitEventEmitterController _senderController;
    private InputEventListenerController _listenerController;

    //IEventListener
    public InputEvent eventToListen => _leftClick;
    //IEventSender
    public UnitEvent eventToSend => _selectionRequest;
    public IUnit dataToSend { get; private set; }

    private void Start()
    {
        _interactorController = new InteractorController(Camera.main);
        _senderController = new UnitEventEmitterController(this);
        _listenerController = new InputEventListenerController(this, gameObject);

        _listenerController.AddListenerComponent();
    }

    //IEventListener
    public void OnReceiveEvent(ScriptableObject unused)
    {
        if (_interactorController.ClickOnSelectable(Input.mousePosition))
            _senderController.RaiseEvent(); 
    }
}
