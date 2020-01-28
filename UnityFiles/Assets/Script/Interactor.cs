using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour, IEventEmitter<UnitEvent, UnitInfo>, 
    IEventListener<InputEvent, ScriptableObject>
{
    [Header("Event to Send")]
    [SerializeField] private UnitEvent _selectionRequest = null;
    [Header("Event to Receive")]
    [SerializeField] private InputEvent _leftClick = null;

    private InteractorController _interactorController;
    private EventEmitterController<UnitEvent, UnitInfo> _senderController;
    private EventListenerController<InputEvent, InputEventListener, ScriptableObject> _listenerController;

    //IEventListener
    public InputEvent eventToListen => _leftClick;
    //IEventSender
    public UnitEvent eventToSend => _selectionRequest;
    public UnitInfo boundData { get; private set; }

    private void Start()
    {
        _interactorController = new InteractorController(Camera.main);
        _senderController = new EventEmitterController<UnitEvent, UnitInfo>(this);
        _listenerController = new EventListenerController<InputEvent, InputEventListener, ScriptableObject>
            (this, gameObject, new InputEventListener.BindEvent());

        _listenerController.AddListenerComponent();
    }

    //IEventListener
    public void OnReceiveEvent(ScriptableObject unused)
    {
        if (_interactorController.ClickOnSelectable(Input.mousePosition))
            _senderController.RaiseEvent(this); 
    }
}
