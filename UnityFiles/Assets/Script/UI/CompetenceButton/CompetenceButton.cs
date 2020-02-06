using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CompetenceButton : MonoBehaviour, ICompetenceEventEmitter, IElementUI
{
    [Header("Component in Children")]
    [SerializeField] private Image icon = null;

    [SerializeField] private CompetenceEvent compReadyToCast = null;

    //ICompetenceEventEmitter
    public Competence dataToSend { get; private set; }
    public CompetenceEvent eventToSend => compReadyToCast;

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

    private CompetenceEventEmitterController eventController;

    private void Awake()
    {
        eventController = new CompetenceEventEmitterController(this);
    }

    internal void Init(Competence receivedCompetence)
    {
        dataToSend = receivedCompetence;
        if(icon != null)
            icon.sprite = dataToSend.template.icon;
    }

    public void OnClick()
    {
        eventController.RaiseEvent();
    }
}
