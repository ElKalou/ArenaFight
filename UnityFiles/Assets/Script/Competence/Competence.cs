using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Competence : ScriptableObject
{
    [SerializeField] Sprite _icon = null;
    [SerializeField] string _name = "";
    [SerializeField] float _coolDown = 0;

    public Sprite icon => _icon;
    public new string name => _name;
    public float coolDown => _coolDown;

    public float coolDownTimer { get; private set; }

    public Unit attachedUnit { get; private set; }

    public abstract bool CastCompetence();

    internal void Init(Unit unitToAttach)
    {
        attachedUnit = unitToAttach;
    }
}
