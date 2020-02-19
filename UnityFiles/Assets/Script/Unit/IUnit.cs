using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IUnit
{
    //Template
    IUnitTemplate template { get; }

    //Messy
    Transform unitTransform { get; }
    ISelectable selectable { get; }
    Navigator navigator { get; }
    AnimatorController animator { get; }

    //Variable
    List<Competence> competences { get; }
    float currentLife { get; }

    //Fonction
    float GetDisplacement();
}