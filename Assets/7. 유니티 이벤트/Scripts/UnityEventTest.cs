using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    private float maxHp = 100;
    private float currentHp = 100;
    private float hpCache = 100;

    // 유니티 이벤트 (UnityEvent)
    // 유니티 Inspector에서 델리게이트와 같이 특정 함수를 등록하여 호출 할 수 있도록 만들어진 클래스
    public UnityEvent someEvent;
    public UnityEvent<float> onHPChange;
    public UnityEvent<string> onHPChangeString;

    public void SomeMethod()
    {
        print("Some Event Called.");
        
    }

    private void Start()
    {
        someEvent?.Invoke();
        onHPChange.AddListener(PrintCurrentHP);
    }

    public void PrintCurrentHP(float value)
    {
        print($"current Hp Amout is : {value}");
    }

    public void OnValueChanged(float value)
    {
        print(value);
    }

    public void OnPositionChange(Vector2 value)
    {
        this.transform.position = value;  
    }

    public void OnDamageButtonClick()
    {
        currentHp -= 10;
    }

    private void Update()
    {
        if(hpCache != currentHp)
        {
            onHPChange?.Invoke(currentHp/maxHp);
            onHPChangeString?.Invoke(currentHp.ToString()+"%");
            hpCache = currentHp;
        }
    }
}
