using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/CompetenceEvent")]
public class CompetenceEvent : EventBase
{
    private List<CompetenceEventListener> listListeners = new List<CompetenceEventListener>();
    public Competence dataToSend { get; set; }

    public void Register(CompetenceEventListener listenerToRegister)
    {
        listListeners.Add(listenerToRegister);
    }

    public void DeRegister(CompetenceEventListener listenerToRegister)
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
}
