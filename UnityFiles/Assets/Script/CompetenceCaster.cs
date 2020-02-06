using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetenceCaster : MonoBehaviour
{
    [SerializeField]
    private CompetenceEvent endCast = null;

    private Competence activeCompetence;
    private Unit attachedUnit;

    private void Start()
    {
        attachedUnit = GetComponentInParent<Unit>();
    }

    public void ReceiveCompetence(Competence receivedCompetence)
    {
        if (receivedCompetence.bindUnit != this.attachedUnit)
            activeCompetence = null;
        else
            activeCompetence = receivedCompetence;
    }

    public void Cast()
    {
        if (activeCompetence == null)
            return;
        if (activeCompetence.CastCompetence())
        {
            ResetCompetenceToCast();
        }
       
    }

    public void AbortCast()
    {
        ResetCompetenceToCast();
    }


    private void ResetCompetenceToCast()
    {
        endCast.dataToSend = activeCompetence;
        endCast.Raise();
        activeCompetence = null;
    }

}
