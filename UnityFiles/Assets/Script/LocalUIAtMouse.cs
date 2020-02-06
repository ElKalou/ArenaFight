using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalUIAtMouse : MonoBehaviour
{

    [Header("Component in children")]
    [SerializeField] private Image image = null;
    
    public void SetImage(Competence competence)
    {
        image.gameObject.SetActive(true);
        image.sprite = competence.template.icon;
    }

    public void DisbaleLocalUI()
    {
        image.gameObject.SetActive(false);
    }
    
}
