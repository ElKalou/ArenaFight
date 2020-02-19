using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> where T:MonoBehaviour
{
    private T _prefab;
    private List<T> _instances;

    public Pool(T prefab, int numberOfInstances)
    {
        _prefab = prefab;
        _instances = new List<T>();
        AddInstances(numberOfInstances);       
    }

    private void AddInstances(int numberOfInstances)
    {      
        for (int i = 0; i < numberOfInstances; i++)
        {
            AddInstance();
        }
    }

    private void AddInstance()
    {
        T newInstance = UnityEngine.Object.Instantiate(_prefab);
        _instances.Add(newInstance);
        newInstance.gameObject.SetActive(false);
    }

    public T GetInstance()
    {
        T toReturn = _instances.Find(x => !x.gameObject.activeInHierarchy);
        if (toReturn == null)
        {
            AddInstances(10);
            toReturn = _instances.Find(x => !x.gameObject.activeInHierarchy);
        }

        toReturn.gameObject.SetActive(true);
        return toReturn;
    }

    public void RecycleInstance(T toRecycle)
    {
        toRecycle.gameObject.SetActive(false);
    }
}

public class ProjectilePool : Pool<Projectile>
{
    public ProjectilePool(Projectile prefab, int numberOfInstance) : base(prefab, numberOfInstance)
    {
    }
}
