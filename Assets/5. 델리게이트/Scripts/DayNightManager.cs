using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager instance { get; private set; }

    public Transform lightTransform;

    private bool isDay = true; // 낮이면 true, 밤이면 false

    // observer Pattern을 부분적으로 구현
    public Action<bool> onDayComesUp;

    private void Awake()
    {
        instance = this;

        onDayComesUp = (isDay) =>
        {
            lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0);
        };
    }

    public void DayToggleButtonClick() // 밤낮 토글 버튼이 호출
    {
        isDay = !isDay;

        onDayComesUp?.Invoke(isDay);
    }
}
