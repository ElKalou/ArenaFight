using UnityEngine;

public abstract class CompetenceTemplate : ScriptableObject, ICompetenceTemplate
{
    [SerializeField] Sprite _icon = null;
    [SerializeField] string _name = "";
    [SerializeField] float _coolDown = 0;

    public Sprite icon => _icon;
    public new string name => _name;
    public float coolDown => _coolDown;

    public abstract CompetenceId id { get; }
}
