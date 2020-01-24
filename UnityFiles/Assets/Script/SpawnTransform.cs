using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTransform : MonoBehaviour
{
    public List<Transform> _transforms { get; private set; }

    private void Awake()
    {
        _transforms = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _transforms.Add(transform.GetChild(i));
        }
        
    }
}
