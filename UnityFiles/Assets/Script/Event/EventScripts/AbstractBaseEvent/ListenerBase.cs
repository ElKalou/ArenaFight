using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class ListenerBase<Data> : MonoBehaviour
{

    public abstract EventBase<Data> eventToReact { get; set; }
    public abstract UnityEvent<Data> onReceiveEvent { get; set; }

    public void OnReceiveEvent(Data receivedData)
    {
        onReceiveEvent.Invoke(receivedData);
    }

    protected void OnDisable()
    {
        eventToReact.DeRegister(this);
    }

    protected void OnEnable()
    {
        if (eventToReact == null)
            return;

        eventToReact.Register(this);
    }

    public static IEnumerator WaitForPossibleEvent(int frameToWait)
    {
        int i = 0;
        while (i < frameToWait)
        {
            i++;
            yield return null;
        }
    }

    [Serializable]
    public abstract class BindEvent<T> : UnityEvent<T> { }

}


