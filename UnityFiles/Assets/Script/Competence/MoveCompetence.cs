using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Unit/MoveCompetenceTemplate")]
public class MoveCompetence : Competence
{
    private Camera mainCam;

    public override bool CastCompetence()
    {
        if (mainCam == null)
            mainCam = Camera.main;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;
            if (Vector3.Distance(attachedUnit.transform.position, hit.point) < attachedUnit.boundData.displacement)
            {
                attachedUnit.GetComponent<NavMeshAgent>().SetDestination(target);
                return true;
            }
        }
        return false;
    }
}
