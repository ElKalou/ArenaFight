using UnityEngine;

[CreateAssetMenu(menuName = "Competence/MoveCompetenceTemplate")]
public class MoveCompetenceTemplate : CompetenceTemplate, IMoveCompetenceTemplate
{
    [SerializeField] private ParticleSystem _unitTrail = null;
    [SerializeField] private float _speed = 0.0f;

    public float speed => _speed;
    public ParticleSystem unitTrail => _unitTrail;
    public override CompetenceId id => CompetenceId.Move;
}
