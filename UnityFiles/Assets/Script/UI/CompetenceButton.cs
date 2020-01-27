using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompetenceButton : MonoBehaviour
{
    [Header("Component in Children")]
    [SerializeField] private Image icon = null;

    [SerializeField] private CompetenceEvent compReadyToCast = null;

    public Competence boundCompetence { get; private set; }

    internal void Init(Competence receivedCompetence)
    {
        boundCompetence = receivedCompetence;
        icon.sprite = boundCompetence.icon;
    }

    public void OnClick()
    {
        compReadyToCast.dataToSend = boundCompetence;
        compReadyToCast.Raise();
    }
}
