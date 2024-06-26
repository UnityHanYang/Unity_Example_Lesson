using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyToggleTest : MonoBehaviour
{
    public Color changeColor;

    public Image targetImage;

    // 이 함수는 toggle이 on Value Change 이벤트로 호출 할 겁니다.
    public void OnToggleValueChange(bool isOn)
    {
        if(isOn)
        {
            targetImage.color = changeColor;
            print($"{name} toggle is on");
        }
        else
        {
            print($"{name} toggle is off");
        }
    }
}
