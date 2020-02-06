using System;
using UnityEngine;

internal class CompetenceButtonManagerController
{
    private ICompetenceButtonManager _view;

    public CompetenceButtonManagerController(ICompetenceButtonManager view)
    {
        _view = view;
    }

    internal void PlaceButton()
    {
        IElementUI newElement = _view.workers[_view.workers.Count - 1];

        RectTransform rectTransformButton = newElement.rectTransform;
        RectTransform rectTransformParent = _view.parentOfInstance;

        float widthButton = rectTransformButton.rect.width;

        rectTransformButton.position = rectTransformParent.position + new Vector3(rectTransformParent.rect.width, 0, 0);
        rectTransformParent.sizeDelta += new Vector2(widthButton, 0.0f);
    }
}