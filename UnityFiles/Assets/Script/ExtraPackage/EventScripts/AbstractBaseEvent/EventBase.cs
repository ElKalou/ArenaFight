using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EventBase<Data> : ScriptableObject
{
    public Data dataToSend { get; set; }

    protected List<ListenerBase<Data>> listListeners = new List<ListenerBase<Data>>();

    public void Raise()
    {
        for (int i = listListeners.Count - 1; i >= 0; i--)
        {
            listListeners[i].OnReceiveEvent(receivedData: dataToSend);
        }
    }

    public void Register(ListenerBase<Data> listenerToRegister)
    {
        listListeners.Add(listenerToRegister);
    }

    public void DeRegister(ListenerBase<Data> listenerToDeregister)
    {
        listListeners.Remove(listenerToDeregister);
    }

    public void ResetEvent()
    {
        listListeners = new List<ListenerBase<Data>>();
    }

}

