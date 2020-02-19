using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CompetenceFactory
{
    private Dictionary<CompetenceId, Type> _availableComp;
    private IEnumerable<Type> _competenceTypes;
    private IUnit _caster;

    public CompetenceFactory(IUnit caster)
    {
        _caster = caster;
        MakeDictionnary();
    }

    private void MakeDictionnary()
    {
        _availableComp = new Dictionary<CompetenceId, Type>();
        _competenceTypes = Assembly.GetAssembly(typeof(Competence)).GetTypes()
            .Where(myType => !myType.IsAbstract && myType.IsSubclassOf(typeof(Competence)));

        object[] constructorParameter = new object[] { null, null };
        foreach (var type in _competenceTypes)
        {
            Competence tempInstance = Activator.CreateInstance(type, constructorParameter) as Competence;
            _availableComp.Add(tempInstance.id, type);
        }
    }

    public Competence GetCompetenceInstanceFromTemplate(ICompetenceTemplate template)
    {
        if (!_availableComp.ContainsKey(template.id))
            return null;

        Type competenceType = _availableComp[template.id];
        object[] constructorParameter = new object[] { template, _caster };
        Competence toReturn = Activator.CreateInstance(competenceType, constructorParameter) as Competence;
        return toReturn;
    }
}

public enum CompetenceId
{
    Move,
    MeleeAttack,
    DistanceAttack
}