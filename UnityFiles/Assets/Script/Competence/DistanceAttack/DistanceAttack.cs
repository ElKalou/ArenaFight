using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : Competence
{
    public override CompetenceId id => CompetenceId.DistanceAttack;

    public override bool CastCompetence()
    {
        Debug.Log(bindUnit.name + " cast distance attack");
        return true;
    }
}
