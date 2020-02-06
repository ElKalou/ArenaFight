using UnityEngine;

[CreateAssetMenu(menuName = "Competence/MoveCompetenceTemplate")]
public class MoveCompetenceTemplate : CompetenceTemplate, IMoveCompetenceTemplate
{
    [SerializeField] private float _speed = 0.0f;

    public float speed => _speed;

    public override CompetenceId id => CompetenceId.Move;
}
