using System.Collections.Generic;
using UnityEngine;

public interface IUnitInfo
{
    List<Competence> competences { get; }
    int currentLife { get; }
    float displacement { get; }
    Sprite icon { get; }
    int maxLife { get; }
    string name { get; }
}