using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
{
    public RectTransform target;

    public void RoofMove(Vector2 vec)
    {
        target.localPosition = vec * 70;
    }
}
