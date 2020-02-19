using UnityEngine;

public abstract class CompetenceTemplate : ScriptableObject, ICompetenceTemplate
{
    [SerializeField] Sprite _icon = null;
    [SerializeField] string _name = "";
    [SerializeField] float _coolDown = 0;
    [SerializeField] MeshRenderer _rangeMesh = null;
    [SerializeField] private float _range = 0.0f;

    public Sprite icon => _icon;
    public new string name => _name;
    public float coolDown => _coolDown;
    public MeshRenderer rangeMesh => _rangeMesh;
    public float range => _range;

    public abstract CompetenceId id { get; }

}
