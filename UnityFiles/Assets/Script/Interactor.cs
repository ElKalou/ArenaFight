using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Event to Send")]
    [SerializeField] private UnitEvent selectionRequest = null;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void OnClick()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = mainCam.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            Selectable possibleHit = hitInfo.transform.GetComponent<Selectable>();
            if (possibleHit != null)
            {
                selectionRequest.dataToSend = possibleHit.GetUnitInfo();
                selectionRequest.Raise();
            }
        }
    }
}
