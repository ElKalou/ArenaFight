using System;
using UnityEngine;

public class InteractorController
{
    private Camera _mainCam;

    public InteractorController(Camera mainCam)
    {
        _mainCam = mainCam;
    }

    public bool ClickOnSelectable(Vector3 mousePos)
    {
        mousePos.z = 0;

        Ray ray = _mainCam.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Selectable possibleHit = hitInfo.transform.GetComponent<Selectable>();
            if (possibleHit != null)
                return true;
        }
        return false;
    }
}