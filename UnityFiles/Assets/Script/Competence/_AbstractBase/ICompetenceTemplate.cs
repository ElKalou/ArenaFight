﻿using UnityEngine;

public interface ICompetenceTemplate
{
    float coolDown { get; }
    Sprite icon { get; }
    string name { get; }
    CompetenceId id { get; }
    float range { get; }
    MeshRenderer rangeMesh { get; }
}