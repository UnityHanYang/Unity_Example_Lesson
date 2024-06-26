using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate (대리자)
// C++의 함수포인터와 유사한 기능
// 메서드를 변수처럼 가변적으로 활용할 수 있는 기능

// Delegate 선언 -> 일종의 (레퍼런스)자료형처럼 형식을 지정하도록 선언해야 한다.
// [지정자] delegate [반환형] [이름] ([매개변수 지정]);
// dselegate의 정의 선언 위치는 class, enum등과 동일.
public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);


public class DelegateTest : MonoBehaviour
{
    public float x;
    public float y;

    // delegate 필드 선언
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        //otherDelegate = PrintMessage;
        //otherDelegate = print; // 매개변수가 암시적 캐스팅이 가능한 경우에도 가능

        // Delegate도 인스턴스를 참조하는 형식으로 생성됨.
        otherDelegate = null;
        //otherDelegate("hello"); // null 오류
        //otherDelegate = new OtherDelegateMethod(PrintMessage);
        //otherDelegate("");
        otherDelegate?.Invoke("");
        // ?. 참조를 하면, ? 앞의 내용이 null일 경우 참조하지 않ㅇ므
    }

    public void CalcChange(int i)
    {
        switch(i)
        {
            case 0:
                someDelegate = Plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtonClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float  y)
    {
        return x - y;
    }

    public float Multiple(float a, float b)
    {
        return a * b;
    }

    public float Divide(float i, float j)
    {
        return i / j;
    }

    public void PrintMessage(string message)
    {
        print(message);
    }
}
