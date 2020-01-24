using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UnitUI : MonoBehaviour, IPointerDownHandler, IUnitUI
{
    [Header("Component in children")]
    [SerializeField] private Image _unitIcon = null;
    [SerializeField] private TextMeshProUGUI _unitName = null;
    [SerializeField] private Slider _lifeSlider = null;
    [Header("Competence Button Prefab")]
    [SerializeField] private CompetenceButton _buttonPrefab = null;
    [Header("Event to send")]
    [SerializeField] private UnitEvent _selectionRequest = null;

    public UnitInfo attachedUnit { get; private set; }
    public Transform parentTransform => transform;
    public CompetenceButton buttonPrefab => _buttonPrefab;

    private UnitUIController _controller;

    public void Init(UnitInfo receivedUnitInfo)
    {
        attachedUnit = receivedUnitInfo;

        _unitIcon.sprite = attachedUnit.icon;
        _unitName.text = attachedUnit.name;
        _lifeSlider.maxValue = attachedUnit.maxLife;
        _lifeSlider.minValue = 0;
        _lifeSlider.value = attachedUnit.currentLife;

        _controller = new UnitUIController(this);
        _controller.SpawnCompetenceButtons(attachedUnit.competences); //In separate class? 
    }

    public void OnPointerDown(PointerEventData eventData) //control by controller
    {
        _selectionRequest.dataToSend = attachedUnit;
        _selectionRequest.Raise();
    }
}
