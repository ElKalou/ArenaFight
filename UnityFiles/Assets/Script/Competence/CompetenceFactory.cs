using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CompetenceFactory
{
    private Dictionary<CompetenceId, Type> _availableComp;
    private IEnumerable<Type> _competenceTypes;

    public CompetenceFactory()
    {
        MakeDictionnary();
    }

    private void MakeDictionnary()
    {
        _availableComp = new Dictionary<CompetenceId, Type>();
        _competenceTypes = Assembly.GetAssembly(typeof(Competence)).GetTypes()
            .Where(myType => !myType.IsAbstract && myType.IsSubclassOf(typeof(Competence)));

        foreach (var type in _competenceTypes)
        {
            Competence tempInstance = Activator.CreateInstance(type) as Competence;
            _availableComp.Add(tempInstance.id, type);
        }
    }

    public Competence GetCompetenceInstanceFromTemplate(ICompetenceTemplate template)
    {
        if (!_availableComp.ContainsKey(template.id))
            return null;

        Type competenceType = _availableComp[template.id];
        Competence toReturn = Activator.CreateInstance(competenceType) as Competence;
        toReturn.InitDataFromTemplate(template);
        return toReturn;
    }
}

public enum CompetenceId
{
    Move,
    MeleeAttack,
    DistanceAttack
}