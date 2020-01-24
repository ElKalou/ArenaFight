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

    private Competence attachedCompetence = null;

    internal void Init(Competence receivedCompetence)
    {
        attachedCompetence = receivedCompetence;
        icon.sprite = attachedCompetence.icon;
    }

    public void OnClick()
    {
        compReadyToCast.dataToSend = attachedCompetence;
        compReadyToCast.Raise();
    }
}
