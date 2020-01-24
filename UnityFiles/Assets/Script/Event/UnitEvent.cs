using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/UnitEvent")]
public class UnitEvent : EventBase
{
    private List<UnitEventListener> listListeners = new List<UnitEventListener>();
    public UnitInfo dataToSend { get; set; }

    public void Register(UnitEventListener listenerToRegister)
    {
        listListeners.Add(listenerToRegister);
    }

    public void DeRegister(UnitEventListener listenerToRegister)
    {
        listListeners.Remove(listenerToRegister);
    }

    public override void Raise()
    {
        for (int i = listListeners.Count - 1; i >= 0; i--)
        {
            listListeners[i].OnReceiveEvent(this);
        }
    }

    public void ResetEvent()
    {
        listListeners = new List<UnitEventListener>();
        dataToSend = null;
    }


}
