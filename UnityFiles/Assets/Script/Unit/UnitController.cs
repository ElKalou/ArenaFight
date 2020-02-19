using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnitController
{
    private IUnit _unit;
    private CompetenceFactory compFactory;

    public UnitController(IUnit unit)
    {
        _unit = unit;
        compFactory = new CompetenceFactory(unit);
    }

    public List<Competence> InitCompetences()
    {
        List<Competence> toReturn = new List<Competence>();

        for (int i = 0; i < _unit.template.competenceTemplates.Count; i++)
        {
            toReturn.Add(AddCompetence(_unit.template.competenceTemplates[i]));
        }

        return toReturn;
    }

    public Competence AddCompetence(ICompetenceTemplate competenceTemplate)
    {
        return(compFactory.GetCompetenceInstanceFromTemplate(competenceTemplate));
    }
}
