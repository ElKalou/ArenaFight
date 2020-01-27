using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CompetenceButtonFactory
{
    RectTransform _parentTransform;
    CompetenceButton _buttonPrefab;

    public CompetenceButtonFactory(IUnitUI unitUI)
    {
        _parentTransform = unitUI.parentTransform;
        _buttonPrefab = unitUI.buttonPrefab;
    }

    public List<CompetenceButton> SpawnCompetenceButtons(List<Competence> competences)
    {
        List<CompetenceButton> toReturn = new List<CompetenceButton>();
        for (int i = 0; i < competences.Count; i++)
        {
            CompetenceButton newButton = (CompetenceButton)PrefabUtility.InstantiatePrefab(_buttonPrefab, _parentTransform);
            PlaceButton(newButton, i);
            newButton.Init(competences[i]);
            toReturn.Add(newButton);
        }
        return toReturn;
    }

    private void PlaceButton(CompetenceButton newButton, int i)
    {
        RectTransform rectTransformButton = newButton.GetComponent<RectTransform>();
        RectTransform rectTransformParent = _parentTransform.GetComponent<RectTransform>();

        float widthButton = rectTransformButton.rect.width;

        rectTransformButton.position = rectTransformParent.position + new Vector3(rectTransformParent.rect.width, 0, 0);
        rectTransformParent.sizeDelta += new Vector2(widthButton, 0.0f);
    }
}
