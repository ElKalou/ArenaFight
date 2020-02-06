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


    private List<ICompetenceTemplate> _iCompetenceTemplates = null;
}
