using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UnitUI : MonoBehaviour, IPointerDownHandler, IUnitUI, IEventEmitter<UnitEvent, UnitInfo>
{
    [Header("Component in children")]
    [SerializeField] private Image _unitIcon = null;
    [SerializeField] private TextMeshProUGUI _unitName = null;
    [SerializeField] private Slider _lifeSlider = null;
    [Header("Competence Button Prefab")]
    [SerializeField] private CompetenceButton _buttonPrefab = null;
    [Header("Event to send")]
    [SerializeField] private UnitEvent _selectionRequest = null;

    private CompetenceButtonFactory _compButtonFactory;
    private EventEmitterController<UnitEvent, UnitInfo> _eventController;
    private RectTransform _thisRectTransform;

    public UnitInfo boundData { get; private set; }
    public RectTransform parentTransform {
        get
        {
            if (_thisRectTransform == null)
                _thisRectTransform = GetComponent<RectTransform>();
            return _thisRectTransform;
        }
    }
    public CompetenceButton buttonPrefab => _buttonPrefab;
    public UnitEvent eventToSend => _selectionRequest;

    public void Init(UnitInfo receivedUnitInfo)
    {
        boundData = receivedUnitInfo;

        _unitIcon.sprite = boundData.icon;
        _unitName.text = boundData.name;
        _lifeSlider.maxValue = boundData.maxLife;
        _lifeSlider.minValue = 0;
        _lifeSlider.value = boundData.currentLife;

        _compButtonFactory = new CompetenceButtonFactory(this);
        _compButtonFactory.SpawnCompetenceButtons(boundData.competences);
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        _eventController.RaiseEvent(this);              
    }

    private void Awake()
    {
        _eventController = new EventEmitterController<UnitEvent, UnitInfo>(this);
    }
}
