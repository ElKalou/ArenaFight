using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/UnitTemplate")]
public class UnitInfo : ScriptableObject, IUnitInfo
{
    [SerializeField] private string _name = "";
    [SerializeField] private Sprite _icon = null;
    [Header("Unit stats")]
    [SerializeField] private int _maxLife = 0;
    [SerializeField] private float _displacement = 0;
    [Header("Unit competences")]
    [SerializeField] private List<Competence> _competenceTemplates = new List<Competence>();


    public new string name => _name;
    public int maxLife => _maxLife;
    public Sprite icon => _icon;
    public float displacement => _displacement;

    public List<Competence> competences { get; private set; } = new List<Competence>();

    public int currentLife { get; private set; }

    private Unit attachedUnit;

    public void Init(Unit unit)
    {
        attachedUnit = unit;

        currentLife = _maxLife;

        for (int i = 0; i < _competenceTemplates.Count; i++)
        {
            Competence competenceInstance = Instantiate(_competenceTemplates[i]);
            competenceInstance.Init(unit);
            competences.Add(competenceInstance);
        }
    }

}
