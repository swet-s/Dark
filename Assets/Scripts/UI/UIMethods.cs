using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class UIMethods
{
   public static void PositionUI(RectTransform toBeResized, RectTransform desiredSize, GameObject parent)
    {
        toBeResized.transform.SetParent(parent.transform);
        toBeResized.sizeDelta = desiredSize.sizeDelta;
        toBeResized.localScale = desiredSize.localScale;
        toBeResized.position = desiredSize.position;
    }
}
