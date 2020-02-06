using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class UnitUI : MonoBehaviour, IPointerDownHandler, IUnitEventEmitter, IUnitUI
{
    [Header("Component in children")]
    [SerializeField] private Image _unitIcon = null;
    [SerializeField] private TextMeshProUGUI _unitName = null;
    [SerializeField] private Slider _lifeSlider = null;
    [Header("Event to send")]
    [SerializeField] private UnitEvent _selectionRequest = null;

    private UnitEventEmitterController _eventController;
    private RectTransform _thisRectTransform;

    //IUnitEventEmitter
    public IUnit dataToSend => attachedUnit;
    public UnitEvent eventToSend => _selectionRequest;

    //IUnitUI
    public RectTransform rectTransform
    {
        get
        {
            if (_thisRectTransform == null)
                _thisRectTransform = GetComponent<RectTransform>();
            return _thisRectTransform;
        }
    }
    public IUnit attachedUnit { get; private set; }

    public void Init(IUnit dataReceived)
    {
        attachedUnit = dataReceived;

        if(_unitIcon != null)
            _unitIcon.sprite = dataReceived.template.icon;
        if(_unitName != null)
            _unitName.text = dataReceived.template.name;
        if(_lifeSlider != null)
        {
            _lifeSlider.maxValue = dataReceived.template.maxLife;
            _lifeSlider.minValue = 0;
            _lifeSlider.value = attachedUnit.currentLife;
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        _eventController.RaiseEvent();              
    }

    private void Awake()
    {
        _eventController = new UnitEventEmitterController(this);
    }
}
