using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEmitter : MonoBehaviour
{
    [Header("Key/Event")]
    [SerializeField] private List<KeyInputPair> keyInputPairs = null;

    private static float multipleClickDelay = 0.5f;
    private static float previousClickTime;

    void Update()
    {
        for (int i = 0; i < keyInputPairs.Capacity; i++)
        {
            if (Input.GetKeyDown(keyInputPairs[i].key))
                keyInputPairs[i].inputEvent.Raise();
        }
    }

    public static int MultipleMouseClick(int previousClicked)
    {
        int clicked = previousClicked;
        if (clicked == 0)
        {
            clicked++;
            previousClickTime = Time.time;
        }
        else if (clicked >= 1 && Time.time - previousClickTime < multipleClickDelay)
        {
            clicked++;
            previousClickTime = Time.time;
        }
        else if (Time.time - previousClickTime >= multipleClickDelay)
        {
            clicked = 1;
            previousClickTime = Time.time;
        }

        return clicked;
    }


}
