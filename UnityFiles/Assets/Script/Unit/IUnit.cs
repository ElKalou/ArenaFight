using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    //Template
    IUnitTemplate template { get; }

    //Messy
    Transform unitTransform { get; }
    ISelectable selectable { get; }

    //Variable
    List<Competence> competences { get; }
    int currentLife { get; }
}