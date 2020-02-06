using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Competence
{
    public override CompetenceId id => CompetenceId.MeleeAttack;

    public override bool CastCompetence()
    {
        Debug.Log(bindUnit.name + " cast melee attack");
        return true;
    }
}
