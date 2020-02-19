using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetenceCaster : MonoBehaviour, ICompetenceEventListener
{
    [SerializeField] private CompetenceEvent _onPreCast = null;

    public CompetenceEvent eventToListen => _onPreCast;

    private CompetenceEventListenerController _listenerController;
    private Competence _currentComp;
    private bool _hasSelect;

    public void OnReceiveEvent(Competence receivedComp)
    {
        if (receivedComp == _currentComp)
            return;

        StopCoroutine(Tick());
        ResetCaster();

        _currentComp = receivedComp;
        _currentComp.PreCast();
        _hasSelect = true;
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        yield return null;
        while (_hasSelect)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_currentComp.TryCast())
                {
                    _currentComp.Cast(_currentComp.target);
                    ResetCaster();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
                ResetCaster();
            yield return null;
        }
    }

    private void ResetCaster()
    {
        if (_currentComp != null)
            _currentComp.EndCast();
        _currentComp = null;
        _hasSelect = false;
    }

    private void Awake()
    {
        _listenerController = new CompetenceEventListenerController(this, gameObject);
        _listenerController.AddListenerComponent();
    }
}
