using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<UnitTemplate> _unitTemplates = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GetComponent<UnitFactory>().SpawnUnit(_unitTemplates[0], transform);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GetComponent<UnitFactory>().SpawnUnit(_unitTemplates[1], transform);
    }
}
