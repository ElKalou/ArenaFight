using UnityEngine;

public interface IMoveCompetenceTemplate : ICompetenceTemplate
{
    ParticleSystem unitTrail { get; }
    float speed { get; }
}