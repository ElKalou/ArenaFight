using System.Collections.Generic;
using UnityEngine;

public interface IUnitTemplate
{
    List<ICompetenceTemplate> competenceTemplates { get; } 
    float displacement { get; }
    Sprite icon { get; }
    int maxLife { get; }
    string name { get; }
}

