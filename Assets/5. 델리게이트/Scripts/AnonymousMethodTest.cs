using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AnonymousMethodTest : MonoBehaviour
{

    // 무명 메서드란
    // 클래스 내가 아닌 메서드 내에서 정의되는 메서드
    // 메서드에 이름이 없으며, Delegate에 할당하기 위해서는
    // 해당 Delegate와 매개변수와 반환형의 타입이 일치해야 함.
    Action someAction;
    Action<int, float> autoCastPlus;
    Func<int, string> someFunc;
    Func<int, int, string> someFunc2;

    // 무명메서드의 장점 : 1회성으로 사용되는 함수의 정의를 따로 함수 밖에서 할 필요가 없어 각독성이
    // 증가하는 측면이 있다. 또한 지역적으로 사용되는 델리게이트 변수에 할당하는 식으로 사용될 경우
    // 해당 포커스가 종료되면 메모리 할당을 해제 하므로 불필요하게 함수가 메모리를 점유하는 것이 지할 수 있음.

    // 무명메서드의 단점 : 델리게이트 체이닝을 사용할 때, 해당 메서드만 체인에서 제거하는 것이 불가능.
    // 또환, 한 메서드에서 많은 무명메서드 정의 시에 오히려 가독성이 떨어질 수 있다.

    // 람다식 : 무명메서드의 축약식 표현

    private void Awake()
    {
        someAction = delegate () { print("Anonymous Method Called."); };

        autoCastPlus = delegate (int a, float b)
        {
            int result = a + (int)b;
            print(result);
        };

        // 무명 메서드 할당에서 매개변수 참조가 불필요할 경우 생략이 가능하다.
        autoCastPlus = delegate
        {
            print("Calc Finished");
        };

        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("입력된 파라미터는 ");
            sb.Append(a);
            sb.Append(" 입니다.");

            return sb.ToString();
        };


        // 람다식 표현 방법
        someAction += (/*파라미터*/) => { /*함수 본문*/ };

        someFunc += (a) => { return a + " is intager"; };
        // 파라미터의 자료형 생략 가능, 리턴, 중괄호도 생략 가능
        someFunc += (a) => a + " is intager";
        // 파라미터가 1개 일 때 소괄호 생략 가능
        someFunc += a => a + " is intager";

        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";
    }

    private void Start()
    {

        someAction?.Invoke();
        someAction?.Invoke();

        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc.Invoke(923));
    }
}
