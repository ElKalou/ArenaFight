using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/UnitTemplate")]
public class UnitTemplate : ScriptableObject, IUnitTemplate
{
    [SerializeField] private string _name = "";
    [SerializeField] private Sprite _icon = null;
    [Header("Unit stats")]
    [SerializeField] private int _maxLife = 0;
    [SerializeField] private float _displacement = 0;
    [Header("Unit competences")]
    [SerializeField] private List<CompetenceTemplate> _competenceTemplates = new List<CompetenceTemplate>();
    [Header("Unit Animation")]
    [SerializeField] private AnimationClip _idle = null;
    [SerializeField] private AnimationClip _run = null;
    [SerializeField] private AnimationClip _meleeAttack = null;
    [SerializeField] private AnimationClip _rangeAttack = null;
    [SerializeField] private AnimationClip _magicAttack = null;

    public new string name => _name;
    public int maxLife => _maxLife;
    public Sprite icon => _icon;
    public float displacement => _displacement;
    public List<ICompetenceTemplate> competenceTemplates {
        get
        {
            if(_iCompetenceTemplates == null)
            {
                _iCompetenceTemplates = new List<ICompetenceTemplate>();
                for (int i = 0; i < _competenceTemplates.Count; i++)
                {
                    _iCompetenceTemplates.Add(_competenceTemplates[i]);
                }
            }
            return _iCompetenceTemplates;
        }
    }

    public AnimationClip idle => _idle;
    public AnimationClip run => _run;
    public AnimationClip meleeAttack => _meleeAttack;
    public AnimationClip rangeAttack => _rangeAttack;
    public AnimationClip magicAttack => _magicAttack;

    private List<ICompetenceTemplate> _iCompetenceTemplates = null;
}
