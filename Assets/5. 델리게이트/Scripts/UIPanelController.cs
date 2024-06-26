using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    public Transform panelParent;

    public void AddPanelButtonClick()
    {
        var child = new GameObject("Image");
        child.transform.SetParent(panelParent);
        var childImage = child.AddComponent<Image>();

        childImage.color = Color.white;

        DayNightManager.instance.onDayComesUp +=
            (isDay) =>
            {
                childImage.color = isDay ? Color.black : Color.white;
            };
    }
}
