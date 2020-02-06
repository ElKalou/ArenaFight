using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(ICompetenceButtonManager))]
[RequireComponent(typeof(Unit))]
public class CompetenceButtonFactory : MonoBehaviour, ICompetenceButtonFactory
{
    [SerializeField] private CompetenceButton _buttonPrefab = null;

    private RectTransform _rectTransform;
    private ICompetenceButtonManager _manager;
    private CompetenceButtonFactoryController _controller;

    //ICompetenceButtonFactory
    public ICompetenceEventEmitter prefab => _buttonPrefab;
    public ICompetenceButtonManager instanceManager {
        get
        {
            if (_manager == null)
                _manager = GetComponent<CompetenceButtonManager>();
            return (_manager);
        }
    }
    public Transform parentTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }

    private void Awake()
    {
        _controller = new CompetenceButtonFactoryController(this);
    }

    private void Start()
    {
        SpawnCompetenceButtons(GetComponent<UnitUI>().attachedUnit.competences);
    }

    public List<CompetenceButton> SpawnCompetenceButtons(List<Competence> competences)
    {
        if (competences == null)
            return null;

        List<CompetenceButton> toReturn = new List<CompetenceButton>();
        for (int i = 0; i < competences.Count; i++)
        {
            toReturn.Add(SpawnCompetenceButton(competences[i]));
        }
        return toReturn;
    }

    public CompetenceButton SpawnCompetenceButton(Competence competence)
    {
        CompetenceButton newButton = Instantiate(_buttonPrefab, parentTransform);
        _controller.InitNewButton(newButton, competence);

        return newButton;
    }

    
}
