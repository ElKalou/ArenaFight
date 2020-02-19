using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CompetenceButton : MonoBehaviour, ICompetenceEventEmitter, IElementUI, IPointerDownHandler
{
    [Header("Component in Children")]
    [SerializeField] private Image icon = null;

    [SerializeField] private CompetenceEvent onClick = null;

    //ICompetenceEventEmitter
    public Competence dataToSend => _attachedComp;
    public CompetenceEvent eventToSend => onClick;

    //IElementUI
    public RectTransform rectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }
    private RectTransform _rectTransform;

    private Competence _attachedComp;

    private CompetenceEventEmitterController eventController;

    private void Awake()
    {
        eventController = new CompetenceEventEmitterController(this);
    }

    internal void Init(Competence receivedCompetence)
    {
        _attachedComp = receivedCompetence;
        InitTransparentBackground();
        InitCompetenceSprite();
    }

    private void InitTransparentBackground()
    {
        Image transparentBackground = new GameObject().AddComponent<Image>();
        transparentBackground.transform.SetParent(transform, false);
        transparentBackground.gameObject.name = "TransparentBackground";
        transparentBackground.sprite = _attachedComp.template.icon;
        transparentBackground.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        transparentBackground.GetComponent<RectTransform>().sizeDelta = rectTransform.sizeDelta;
    }

    private void InitCompetenceSprite()
    {
        if (icon == null)
            return;

        icon.GetComponent<RectTransform>().sizeDelta = rectTransform.sizeDelta;
        icon.sprite = _attachedComp.template.icon;
        icon.fillClockwise = true;
        icon.fillAmount = 1;
        icon.fillOrigin = 2;
        icon.fillClockwise = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        eventController.RaiseEvent();
    }

    public void Update()
    {
        icon.fillAmount = _attachedComp.coolDownTimer / _attachedComp.GetCoolDown();
    }
}
